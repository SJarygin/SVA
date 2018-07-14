using System;
using System.IO;

namespace SVA
{
    public class FileItem
    {
        public string FileName;
        public string UserName;
        public DateTime DtStart;
        public TimeSpan Duration;
        public TimeSpan BeginOffset;
        public TimeSpan EndOffset;
        //0         1         2         3         4         5
        //0123456789012345678901234567890123456789012345678901234567890
        //2018-06-28_15-05-10-805$8bbd4bd2-b04b-480e-a43b-693658a954e6.MP4
        public FileItem(string AFileName)
        {
            FileName = AFileName;
            var parts = Path.GetFileNameWithoutExtension(AFileName).Split('$');
            var dtParts = parts[0].Split('-', '_');
            DtStart = new DateTime(
                int.Parse(dtParts[0])
                , int.Parse(dtParts[1])
                , int.Parse(dtParts[2])
                , int.Parse(dtParts[3])
                , int.Parse(dtParts[4])
                , int.Parse(dtParts[5])
                , int.Parse(dtParts[6]));

            UserName = parts[1].ToUpper();
        }

        public string StrData()
        {
            var temp = $"{ControlExtensions.TimeSpanToString(BeginOffset)}-{ControlExtensions.TimeSpanToString(EndOffset)} {Path.GetFileName(FileName)}";
            return temp;
        }
    }
}
