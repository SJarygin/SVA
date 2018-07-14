using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace SVA
{
    public class UserItem
    {
        public string Name;
        public VlcControl Vlc;
        public Label Label;
        public List<FileItem> FileItems = new List<FileItem>();

        public FileItem CurrentFile;
        public void Play(FileItem AFileItem, int APosition)
        {
            if (CurrentFile == null || CurrentFile.FileName != AFileItem.FileName)
            {
                Program.Logger.Debug("Play: {0} [{1}]", Vlc.Name, AFileItem.StrData());
                //Console.WriteLine($"Play ${Name} {AFileItem}");
                ThreadPool.QueueUserWorkItem((AData) => Vlc.Play(new FileInfo(AFileItem.FileName)));
                //  Vlc.Play(new FileInfo(AFileItem.FileName));
                CurrentFile = AFileItem;
            }
            //_logger.Debug("Play: {0} >{1} [{2}]", Vlc.Name, Form1.TimeSpanToString(new TimeSpan(0, 0, 0, APosition)), AFileItem.StrData());

            //if (!Vlc.IsPlaying)
            //{
            //    Vlc.Play();
            //}
            if (APosition >= 0)
                Vlc.Time = APosition;
        }
    }
}
