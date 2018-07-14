using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace SVA
{
    public partial class Form1 : Form
    {
        private UserItem _mainUserItem;
        private FileItem _mainFileItem;
        public List<UserItem> _userItems = new List<UserItem>();
        public List<FileItem> _fileItems = new List<FileItem>();
        public int Divider = 1000;
        private int margin = 10;
        private double ratio = 2.0 / 3.0;
        private int[] posX = new[] { -1, 0, 1, 2, 0, 1, 2, 0, 1, 2 };
        private int[] posY = new[] { -1, 0, 0, 0, 1, 1, 1, 2, 2, 2 };
        private Config _config;
        private volatile bool _px;

        public Form1()
        {
            InitializeComponent();
            Text = "Архив коференций";
            _px = true;
            Verb((AVlc) =>
           {
               AVlc.BackColor = Color.LightGray;
               GetLabelByVlc(AVlc).InvokeIfRequired(l => l.Text = "--:--:--");
               AVlc.Stopped += (ASender, AEventArgs) =>
               {
                   var vlc = (VlcControl)ASender;
                   vlc.BackColor = Color.Gray;
                   GetLabelByVlc(vlc).InvokeIfRequired(l => l.Text = "--:--:--");
                   var anyPlaying = false;
                   Verb((AVlcx) =>
                   {
                       if (AVlcx.IsPlaying)
                           anyPlaying = true;
                       return true;
                   });
                   bStart.Enabled = !anyPlaying;
                   bStop.Enabled = anyPlaying;
                   trackBar1.Enabled = anyPlaying;
                   //_px = !anyPlaying;
               };
               AVlc.Paused += (ASender, AEventArgs) =>
               {
                   var vlc = (VlcControl)ASender;
                   GetLabelByVlc(vlc).InvokeIfRequired(l => l.Text = "Pause");
               };
               AVlc.PositionChanged += (ASender, AEventArgs) =>
               {
                   try
                   {
                       var vlc = (VlcControl)ASender;
                       var temp = vlc.GetCurrentMedia().Duration.Ticks * AEventArgs.NewPosition;
                       var currentPosition = new TimeSpan(Convert.ToInt64(temp));
                       GetLabelByVlc(vlc).InvokeIfRequired(l => l.Text = ControlExtensions.TimeSpanToString(currentPosition));
                       if (vlc != vlc1)
                           return;

                       trackBar1.InvokeIfRequired(AItem => AItem.Value = (int)vlc1.Time / 1000);

                       currentPosition = new TimeSpan(0, 0, 0, 0, (int)vlc1.Time);
                       if (_px)
                           return;
                       foreach (var userItem in _userItems.Where(AItem => AItem != _mainUserItem))
                       {
                           var fileItem = userItem.FileItems.FirstOrDefault(AItem => AItem.BeginOffset < currentPosition && currentPosition < AItem.EndOffset);
                           if (fileItem == null)
                           {
                               //Program.Logger.Debug(" {0} out of range", userItem.Vlc.Name);
                               if (userItem.CurrentFile != null)
                               {
                                   userItem.Vlc.BackColor = Color.Gray;
                                   if (userItem.Vlc.IsPlaying)
                                   {
                                       userItem.Vlc.Stop();
                                       Application.DoEvents();
                                       Thread.Sleep(100);
                                       Application.DoEvents();
                                   }
                                   userItem.CurrentFile = null;
                               }
                               continue;
                           }
                           //var offset = (int)(currentPosition - fileItem.BeginOffset).TotalMilliseconds;
                           // _logger.Debug(" File: {0} {1}", fileItem.StrData(), offset);
                           userItem.Vlc.BackColor = Color.Black;
                           userItem.Play(fileItem, -1);
                       }

                   }
                   catch (Exception)
                   {
                   }
               };
               return true;
           });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.Logger = LogManager.GetCurrentClassLogger();
            Program.Logger.Debug("Load");
            _config = Config.LoadFromFile();
            Top = _config.Top;
            Left = _config.Left;
            Width = _config.Width;
            Height = _config.Height;
            Form1_Resize(null, null);
        }

        private void OnVlcControlNeedLibDirectory(object sender, VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            if (currentDirectory == null)
                return;
            if (IntPtr.Size == 4)
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"lib\x86\"));
            else
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"lib\x64\"));

            if (!e.VlcLibDirectory.Exists)
            {
                var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
                folderBrowserDialog.Description = "Select Vlc libraries folder.";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderBrowserDialog.ShowNewFolderButton = true;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    e.VlcLibDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void Verb(Func<VlcControl, bool> AVerbAction)
        {
            foreach (var control in Controls)
            {
                var vlc = control as VlcControl;
                if (vlc == null) continue;
                if (!vlc.Name.StartsWith("vlc"))
                    continue;
                AVerbAction(vlc);
            }
        }

        private Label GetLabelByVlc(VlcControl AVlcControl)
        {
            var n = AVlcControl.Name.Replace("vlc", "");
            foreach (var control in Controls)
            {
                var label = control as Label;
                if (label == null) continue;
                if (label.Name == $"label{n}")
                {
                    return label;
                };
            }
            return null;
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            _fileItems.Clear();
            _userItems.Clear();
            Program.Logger.Debug("Start");
            var fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.SelectedPath = _config.LastPath;
            if (fbd.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                _config.LastPath = fbd.SelectedPath;
                SaveConfig();
                Text = $"Конференция: {Path.GetFileName(_config.LastPath.TrimEnd(Path.DirectorySeparatorChar))}";
                bStart.Enabled = false;
                bStop.Enabled = true;
                foreach (var fileName in Directory.GetFiles(
                    fbd.SelectedPath, "*.MP4"
                    , SearchOption.TopDirectoryOnly))
                {
                    if (new FileInfo(fileName).Length == 0)
                        continue;
                    var fileItem = new FileItem(fileName);
                    _fileItems.Add(fileItem);
                }
                var n = 1;
                foreach (var fileItem in _fileItems.OrderBy(Aitem => Aitem.DtStart))
                {
                    var userItem = _userItems.FirstOrDefault(AItem => AItem.Name == fileItem.UserName);
                    if (userItem == null)
                    {
                        userItem = new UserItem
                        {
                            Name = fileItem.UserName
                        };

                        Verb(AVlc =>
                        {
                            if (AVlc.Name == $"vlc{n}")
                            {
                                userItem.Vlc = AVlc;
                            }
                            return true;
                        });
                        n++;
                        _userItems.Add(userItem);
                    }
                    EventHandler<Vlc.DotNet.Core.VlcMediaPlayerLengthChangedEventArgs> tempEvent = (ASender, AEventArgs) =>
                    {
                        var newLength = new TimeSpan((long)AEventArgs.NewLength);
                        if (newLength > fileItem.Duration)
                            fileItem.Duration = newLength;
                    };
                    vlx.LengthChanged += tempEvent;
                    ThreadPool.QueueUserWorkItem((AData) => vlx.Play(new FileInfo(fileItem.FileName)));

                    while (true)
                    {
                        if (fileItem.Duration.Ticks > 0)
                            break;
                        Application.DoEvents();
                        Thread.Sleep(100);
                        Application.DoEvents();
                        //    Application.DoEvents();
                    }
                    vlx.Stop();
                    vlx.LengthChanged -= tempEvent;
                    userItem.FileItems.Add(fileItem);
                }
                _mainUserItem = _userItems.FirstOrDefault(AItem => AItem.Name.ToUpper() == "SURGERY");


                _mainFileItem = _fileItems.FirstOrDefault(AItem => AItem.UserName.ToUpper() == "SURGERY");
                foreach (var fileItem in _fileItems)
                {
                    if (fileItem == _mainFileItem)
                        continue;
                    fileItem.BeginOffset = fileItem.DtStart.Subtract(_mainFileItem.DtStart);
                    fileItem.EndOffset = fileItem.BeginOffset.Add(fileItem.Duration);
                }
                //_mainFileItem.Duration = _fileItems.Max(AItem => AItem.EndOffset);
                _mainFileItem.BeginOffset = new TimeSpan(0);
                _mainFileItem.EndOffset = _mainFileItem.BeginOffset.Add(_mainFileItem.Duration);

                foreach (var userItem in _userItems)
                {
                    Program.Logger.Debug("User: {0}", userItem.Name);
                    userItem.FileItems = userItem.FileItems.OrderBy(AItem => AItem.BeginOffset).ToList();
                    foreach (var fileItem in userItem.FileItems)
                    {
                        Program.Logger.Debug(" File: {0}", fileItem.StrData());
                    }
                }

                trackBar1.Minimum = 0;
                trackBar1.Maximum = (int)(_mainFileItem.Duration.TotalMilliseconds / 1000);
                trackBar1.Value = (int)_fileItems.Where(AItem => AItem != _mainFileItem).OrderBy(AItem => AItem.BeginOffset).First().BeginOffset.TotalSeconds + 1;
                trackBar1_Scroll(null, new EventArgs());
                trackBar1.Enabled = true;
            }
            catch (Exception exception)
            {
                Program.Logger.Error(exception);
            }
        }

        private void bPause_Click(object sender, EventArgs e)
        {
            Verb((AVlc) => { AVlc.Pause(); return true; });
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            Verb((AVlc) =>
            {
                if (AVlc.IsPlaying)
                {
                    AVlc.Stop();
                    Application.DoEvents();
                    Thread.Sleep(100);
                    Application.DoEvents();
                }
                return true;
            });
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void vlc1_Click(object sender, EventArgs e)
        {
            //var vlc = (VlcControl)sender;
            //if (!vlc.IsPlaying)
            //    vlc.Play();
        }

        private DateTime _lastScroll = DateTime.Now;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //if (DateTime.Now.Subtract(_lastScroll) < new TimeSpan(0, 0, 0, 0, 200))
            //  return;
            _px = true;
            var currentPosition = new TimeSpan(0, 0, 0, 0, trackBar1.Value * 1000);
            Program.Logger.Info("SetPosition: {0}", currentPosition);
            _mainUserItem.Play(_mainFileItem, (int)(currentPosition - _mainFileItem.BeginOffset).TotalMilliseconds);

            foreach (var userItem in _userItems.Where(AItem => AItem != _mainUserItem))
            {
                var fileItem = userItem.FileItems.FirstOrDefault(AItem => AItem.BeginOffset < currentPosition && currentPosition < AItem.EndOffset);
                if (fileItem == null)
                {
                    Program.Logger.Debug(" {0} out of range", userItem.Vlc.Name);
                    userItem.Vlc.BackColor = Color.Gray;
                    if (userItem.Vlc.IsPlaying)
                    {
                        userItem.Vlc.Stop();
                        Application.DoEvents();
                        Thread.Sleep(100);
                        Application.DoEvents();
                    }
                    userItem.CurrentFile = null;
                    continue;
                }
                var offset = (int)(currentPosition - fileItem.BeginOffset).TotalMilliseconds;
                Program.Logger.Debug(" File: {0} {1}", fileItem.StrData(), offset);
                userItem.Vlc.BackColor = Color.Black;
                userItem.Play(fileItem, offset);
            }
            _px = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
            e.Cancel = false;
            Verb((AVlc) =>
            {
                if (AVlc.IsPlaying)
                {
                    e.Cancel = true;
                }
                return true;
            });
            Application.DoEvents();
            if (e.Cancel)
            {
                bStop_Click(null, null);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            var p9Width = (int)(Width * ratio);
            var p1Width = Width - p9Width;

            vlc1.Width = p1Width - 3 * margin;
            vlc1.Left = Width - p1Width + margin;

            //Text = $"{trackBar1.Top}";
            vlc1.Height = trackBar1.Top - 2 * margin;
            vlc1.Top = margin;

            label1.Top = vlc1.Top + 2;
            label1.Left = vlc1.Left + 2;

            Verb((AVlc) =>
            {
                if (AVlc == vlc1)
                    return true;
                AVlc.Width = (p9Width - 4 * margin) / 3;
                AVlc.Height = (vlc1.Height - 4 * margin) / 3;

                var n = Convert.ToInt32(AVlc.Name.Replace("vlc", "")) - 1;
                AVlc.Left = margin + posX[n] * (AVlc.Width + margin);
                AVlc.Top = margin + posY[n] * (AVlc.Height + margin);

                var label = GetLabelByVlc(AVlc);
                label.Top = AVlc.Top + 2;
                label.Left = AVlc.Left + 2;

                return true;
            });
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void SaveConfig()
        {
            _config.Top = Top;
            _config.Left = Left;
            _config.Width = Width;
            _config.Height = Height;
            _config.SaveToFile();
        }
    }
}
