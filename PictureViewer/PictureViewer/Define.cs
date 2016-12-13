using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    class Define
    {
        public const string APP_NAME = "图片浏览器-V1.1";//程序名称
        public const int MIN_SCALE = 1;//图片缩小的最小比例
        public const int MAX_SCALE = 1000;//图片放大的最大比例
        public const int SCALE_DIFF = 1;//图片放大、缩小一次比例变化量
        public static string tempPath = Application.StartupPath + "\\Temp";//临时图片保存位置 
        public static bool isClearTemp = true;//是否清除临时文件夹数据  
        public const string TEMP_FILE_HEAD = "PictureView_";//临时文件夹前缀

        //Config设置
        public const string CONFIG_SETTING = "Setting";//设置保存节点
        public const string CONFIG_SKIN_PATH = "SkinPath";//皮肤路径
        public const string CONFIG_IS_CLEAR_TEMP = "IsClearTemp";//关闭程序后是否清除临时文件
        public const string CONFIG_TEMP_PATH = "TempPath";//临时文件位置
    }
}
