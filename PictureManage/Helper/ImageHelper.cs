using PictureViewer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChenKH.Tools
{
    class ImageHelper
    {
        /// <summary>
        /// 放大或缩小图片
        /// </summary>
        /// <param name="img">源图片</param>
        /// <param name="newSize">新尺寸</param>
        /// <returns></returns>
        public static Image Scale(Image img, Size newSize)
        {
            return new Bitmap(img, newSize);
        }

        /// <summary>
        /// 顺时针旋转90度
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static void Rotate90(Image img)
        {            
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }

        /// <summary>
        /// 顺时针旋转90度
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static void Rotate180(Image img)
        {            
            img.RotateFlip(RotateFlipType.Rotate180FlipNone);
        }

        /// <summary>
        /// 顺时针旋转90度
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static void Rotate270(Image img)
        {            
            img.RotateFlip(RotateFlipType.Rotate270FlipNone);
        }

        /// <summary>
        /// 水平翻转
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static void FlipX(Image img)
        {            
            img.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }
        /// <summary>
        /// 垂直翻转
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static void FlipY(Image img)
        {            
            img.RotateFlip(RotateFlipType.RotateNoneFlipY);
        }

        /// <summary>
        /// 将动态图片转成单张图片，并记录延迟时间
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<ImageInfo> GifToList(string path)
        {
            List<ImageInfo> lstGif = new List<ImageInfo>();
            Image gif = Image.FromFile(path);
            FrameDimension fd = new FrameDimension(gif.FrameDimensionsList[0]);
            string savePath = Define.tempPath + "\\"  + Define.TEMP_FILE_HEAD + DateTime.Now.Ticks;
            //保存图片路径
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);
            //获取图片的帧数
            int count = gif.GetFrameCount(fd);
            for (int i = 0; i < count; i++)
            {
                //保存每一帧的图片
                gif.SelectActiveFrame(fd, i);

                gif.Save(savePath + "\\" + i + ".png", ImageFormat.Png);
                bool flag = false;
                foreach (PropertyItem item in gif.PropertyItems)
                {
                    if (item.Id == 0x5100)//延时时间 
                    {
                        flag = true;
                        ImageInfo gifInfo = new ImageInfo();
                        gifInfo.Delay = BitConverter.ToInt32(item.Value, 0) * 10;
                        gifInfo.Delay = gifInfo.Delay == 0 ? 100 : gifInfo.Delay;//延时时间为0，设为100ms
                        gifInfo.Path = savePath + "\\" + i + ".png";
                        lstGif.Add(gifInfo);
                    }
                }
                //无延时时间，静态图
                if (!flag)
                {
                    ImageInfo gifInfo = new ImageInfo();
                    gifInfo.Delay = 100;
                    gifInfo.Path = savePath + "\\" + i + ".png";
                    lstGif.Add(gifInfo);
                }
            }
            return lstGif;
        }

    }
}
