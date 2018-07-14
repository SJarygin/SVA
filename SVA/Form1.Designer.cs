using Vlc.DotNet.Forms;

namespace SVA
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.vlc1 = new Vlc.DotNet.Forms.VlcControl();
            this.vlc2 = new Vlc.DotNet.Forms.VlcControl();
            this.vlc3 = new Vlc.DotNet.Forms.VlcControl();
            this.vlc4 = new Vlc.DotNet.Forms.VlcControl();
            this.vlc5 = new Vlc.DotNet.Forms.VlcControl();
            this.vlc6 = new Vlc.DotNet.Forms.VlcControl();
            this.vlc7 = new Vlc.DotNet.Forms.VlcControl();
            this.vlc8 = new Vlc.DotNet.Forms.VlcControl();
            this.vlc9 = new Vlc.DotNet.Forms.VlcControl();
            this.bStart = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.bPause = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.vlx = new Vlc.DotNet.Forms.VlcControl();
            this.label10 = new System.Windows.Forms.Label();
            this.vlc10 = new Vlc.DotNet.Forms.VlcControl();
            ((System.ComponentModel.ISupportInitialize)(this.vlc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc10)).BeginInit();
            this.SuspendLayout();
            // 
            // vlc1
            // 
            this.vlc1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vlc1.BackColor = System.Drawing.Color.Black;
            this.vlc1.ForeColor = System.Drawing.SystemColors.Control;
            this.vlc1.Location = new System.Drawing.Point(468, 12);
            this.vlc1.Name = "vlc1";
            this.vlc1.Size = new System.Drawing.Size(359, 276);
            this.vlc1.Spu = -1;
            this.vlc1.TabIndex = 0;
            this.vlc1.Text = "vlc1";
            this.vlc1.VlcLibDirectory = null;
            this.vlc1.VlcMediaplayerOptions = null;
            this.vlc1.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.OnVlcControlNeedLibDirectory);
            this.vlc1.Click += new System.EventHandler(this.vlc1_Click);
            // 
            // vlc2
            // 
            this.vlc2.BackColor = System.Drawing.Color.Black;
            this.vlc2.Location = new System.Drawing.Point(12, 12);
            this.vlc2.Name = "vlc2";
            this.vlc2.Size = new System.Drawing.Size(137, 88);
            this.vlc2.Spu = -1;
            this.vlc2.TabIndex = 1;
            this.vlc2.Text = "vlcControl1";
            this.vlc2.VlcLibDirectory = null;
            this.vlc2.VlcMediaplayerOptions = null;
            this.vlc2.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.OnVlcControlNeedLibDirectory);
            // 
            // vlc3
            // 
            this.vlc3.BackColor = System.Drawing.Color.Black;
            this.vlc3.Location = new System.Drawing.Point(168, 12);
            this.vlc3.Name = "vlc3";
            this.vlc3.Size = new System.Drawing.Size(136, 88);
            this.vlc3.Spu = -1;
            this.vlc3.TabIndex = 2;
            this.vlc3.Text = "vlcControl2";
            this.vlc3.VlcLibDirectory = null;
            this.vlc3.VlcMediaplayerOptions = null;
            this.vlc3.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.OnVlcControlNeedLibDirectory);
            // 
            // vlc4
            // 
            this.vlc4.BackColor = System.Drawing.Color.Black;
            this.vlc4.Location = new System.Drawing.Point(327, 12);
            this.vlc4.Name = "vlc4";
            this.vlc4.Size = new System.Drawing.Size(137, 88);
            this.vlc4.Spu = -1;
            this.vlc4.TabIndex = 3;
            this.vlc4.Text = "vlcControl3";
            this.vlc4.VlcLibDirectory = null;
            this.vlc4.VlcMediaplayerOptions = null;
            this.vlc4.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.OnVlcControlNeedLibDirectory);
            // 
            // vlc5
            // 
            this.vlc5.BackColor = System.Drawing.Color.Black;
            this.vlc5.Location = new System.Drawing.Point(12, 106);
            this.vlc5.Name = "vlc5";
            this.vlc5.Size = new System.Drawing.Size(137, 88);
            this.vlc5.Spu = -1;
            this.vlc5.TabIndex = 4;
            this.vlc5.Text = "vlcControl4";
            this.vlc5.VlcLibDirectory = null;
            this.vlc5.VlcMediaplayerOptions = null;
            this.vlc5.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.OnVlcControlNeedLibDirectory);
            // 
            // vlc6
            // 
            this.vlc6.BackColor = System.Drawing.Color.Black;
            this.vlc6.Location = new System.Drawing.Point(167, 106);
            this.vlc6.Name = "vlc6";
            this.vlc6.Size = new System.Drawing.Size(137, 88);
            this.vlc6.Spu = -1;
            this.vlc6.TabIndex = 5;
            this.vlc6.Text = "vlcControl5";
            this.vlc6.VlcLibDirectory = null;
            this.vlc6.VlcMediaplayerOptions = null;
            this.vlc6.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.OnVlcControlNeedLibDirectory);
            // 
            // vlc7
            // 
            this.vlc7.BackColor = System.Drawing.Color.Black;
            this.vlc7.Location = new System.Drawing.Point(327, 106);
            this.vlc7.Name = "vlc7";
            this.vlc7.Size = new System.Drawing.Size(137, 88);
            this.vlc7.Spu = -1;
            this.vlc7.TabIndex = 6;
            this.vlc7.Text = "vlcControl6";
            this.vlc7.VlcLibDirectory = null;
            this.vlc7.VlcMediaplayerOptions = null;
            this.vlc7.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.OnVlcControlNeedLibDirectory);
            // 
            // vlc8
            // 
            this.vlc8.BackColor = System.Drawing.Color.Black;
            this.vlc8.Location = new System.Drawing.Point(12, 200);
            this.vlc8.Name = "vlc8";
            this.vlc8.Size = new System.Drawing.Size(137, 88);
            this.vlc8.Spu = -1;
            this.vlc8.TabIndex = 7;
            this.vlc8.Text = "vlcControl7";
            this.vlc8.VlcLibDirectory = null;
            this.vlc8.VlcMediaplayerOptions = null;
            this.vlc8.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.OnVlcControlNeedLibDirectory);
            // 
            // vlc9
            // 
            this.vlc9.BackColor = System.Drawing.Color.Black;
            this.vlc9.Location = new System.Drawing.Point(167, 200);
            this.vlc9.Name = "vlc9";
            this.vlc9.Size = new System.Drawing.Size(137, 88);
            this.vlc9.Spu = -1;
            this.vlc9.TabIndex = 8;
            this.vlc9.Text = "vlcControl8";
            this.vlc9.VlcLibDirectory = null;
            this.vlc9.VlcMediaplayerOptions = null;
            this.vlc9.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.OnVlcControlNeedLibDirectory);
            // 
            // bStart
            // 
            this.bStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bStart.Location = new System.Drawing.Point(590, 339);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 9;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bStop
            // 
            this.bStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bStop.Enabled = false;
            this.bStop.Location = new System.Drawing.Point(752, 339);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(75, 23);
            this.bStop.TabIndex = 10;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // bPause
            // 
            this.bPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bPause.Location = new System.Drawing.Point(671, 339);
            this.bPause.Name = "bPause";
            this.bPause.Size = new System.Drawing.Size(75, 23);
            this.bPause.TabIndex = 11;
            this.bPause.Text = "Pause";
            this.bPause.UseVisualStyleBackColor = true;
            this.bPause.Visible = false;
            this.bPause.Click += new System.EventHandler(this.bPause_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(12, 291);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(815, 45);
            this.trackBar1.TabIndex = 12;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(95, 308);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(359, 54);
            this.rtbLog.TabIndex = 13;
            this.rtbLog.Text = "";
            this.rtbLog.Visible = false;
            this.rtbLog.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(471, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(328, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(173, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "label9";
            // 
            // vlx
            // 
            this.vlx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.vlx.BackColor = System.Drawing.Color.Black;
            this.vlx.Location = new System.Drawing.Point(12, 317);
            this.vlx.Name = "vlx";
            this.vlx.Size = new System.Drawing.Size(64, 45);
            this.vlx.Spu = -1;
            this.vlx.TabIndex = 23;
            this.vlx.Text = "vlx";
            this.vlx.Visible = false;
            this.vlx.VlcLibDirectory = null;
            this.vlx.VlcMediaplayerOptions = null;
            this.vlx.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.OnVlcControlNeedLibDirectory);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(333, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "label10";
            // 
            // vlc10
            // 
            this.vlc10.BackColor = System.Drawing.Color.Black;
            this.vlc10.Location = new System.Drawing.Point(327, 200);
            this.vlc10.Name = "vlc10";
            this.vlc10.Size = new System.Drawing.Size(137, 88);
            this.vlc10.Spu = -1;
            this.vlc10.TabIndex = 24;
            this.vlc10.Text = "vlcControl8";
            this.vlc10.VlcLibDirectory = null;
            this.vlc10.VlcMediaplayerOptions = null;
            this.vlc10.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.OnVlcControlNeedLibDirectory);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 368);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.vlc10);
            this.Controls.Add(this.vlx);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.bPause);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.vlc9);
            this.Controls.Add(this.vlc8);
            this.Controls.Add(this.vlc7);
            this.Controls.Add(this.vlc6);
            this.Controls.Add(this.vlc5);
            this.Controls.Add(this.vlc4);
            this.Controls.Add(this.vlc3);
            this.Controls.Add(this.vlc2);
            this.Controls.Add(this.vlc1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.vlc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VlcControl vlc1;
        private VlcControl vlc2;
        private VlcControl vlc3;
        private VlcControl vlc4;
        private VlcControl vlc5;
        private VlcControl vlc6;
        private VlcControl vlc7;
        private VlcControl vlc8;
        private VlcControl vlc9;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bPause;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private VlcControl vlx;
        private System.Windows.Forms.Label label10;
        private VlcControl vlc10;
    }
}

