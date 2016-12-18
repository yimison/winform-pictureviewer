using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureViewer
{
   public class ImageInfo
    {
        //路径
        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        //延迟
        private int delay;

        public int Delay
        {
            get { return delay; }
            set { delay = value; }
        }
    }
}
