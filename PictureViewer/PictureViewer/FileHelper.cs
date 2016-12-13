using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChenKH.Tools
{
    class FileHelper
    {
        enum Suffix
        {
            B,KB,MB,GB,TB,PB,EB,ZB,YB,DB,NB
        }
        /// <summary>
        /// 将文件长度转成字符串    1024  ->  1KB
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string LengthToString(long length)
        {
            Suffix suffix = Suffix.B;
            float f = (float)length;
            while (f > 1024f)
            {
                f /= 1024f;
                suffix++;
            }
            return f.ToString("f2") + suffix.ToString();
        }
    }
}
