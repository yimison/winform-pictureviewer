using ChenKH.Tools;
using PictureManage;
//using Gif.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class PictureDetail : Form
    {
        #region 变量
        private int imgSelectedIndex;

        public int ImgSelectedIndex
        {
            get { return imgSelectedIndex; }
            set { 
                imgSelectedIndex = value;
                //InitGifInfo();
            }
        } //当前显示第X张图片
      //  private List<string> lstImgPath;//当前文件夹所有的图片信息
        private List<ImageModel> lstImage;//当前文件夹所有的图片
        private List<ImageInfo> lstGifInfo = null;//当前显示的动态图切换成单张图片的信息
        private int gifSelectedIndex = 0;//显示动态图的第X张图片信息
        private Stopwatch gifStopwatch = new Stopwatch();//用来统计动态图的延迟
        private int showMilliSecond = 0;//显示提示信息的时间
        //图片放大、缩小、旋转、翻转
        private int imgScale = 100;//图片比例%
        private int scaleButtonClickFlag;//判断按钮是否按下 0未按下，1放大按钮，-1缩小按钮
        private int imgRotate = 0;//图片旋转角度
        private bool imgFlipX = false;//是否水平翻转
        private bool imgFlipY = false;//是否垂直翻转
        //按下鼠标移动图片
        private bool isMouseDown;//标志鼠标是否按下
        private Point mousePoint, picturePoint;//移动图片时的鼠标位置，图片位置
        //提示功能
        private ToolTip toolTip = null;
        #endregion

      
        public PictureDetail(List<ImageModel> lst,int selectIndex)
        {
            InitializeComponent();
            ImgSelectedIndex = selectIndex;
            InitData();
            if (lst.Count > 0)
            {
                InitImage(lst);
            }
        }

        private void PictureDetail_Load(object sender, EventArgs e)
        {

        }

        #region 初始化数据
        /// <summary>
        /// 初始化基本数据
        /// </summary>
        private void InitData()
        {
            picBox.SendToBack();
            this.Text = Define.APP_NAME;
            lblScale.Visible = false;
            showMilliSecond = 0;
            scaleButtonClickFlag = 0;
           // lstImgPath = new List<string>();
            lstImage = new List<ImageModel>();

            lstGifInfo = new List<ImageInfo>();
            this.MouseWheel += new MouseEventHandler(MouseWheelEvent);
            pnlBottom.Visible = false;
            pnlTop.Visible = false;
            pnlImage.BackColor = Color.Gainsboro;
            pnlBottom.BackColor = Color.Gainsboro;
            tmrGetMousePosition.Start();
            InitToolTip();
            InitConfigSetting();
        }

        /// <summary>
        /// 初始化设置
        /// </summary>
        private void InitConfigSetting()
        {
            //初始化皮肤
            string file = ConfigHelper.GetValue(Define.CONFIG_SETTING, Define.CONFIG_SKIN_PATH);
          //  SkinHelper.SetSkin(file);
            //退出后是否清除缓存
            if (ConfigHelper.GetValue(Define.CONFIG_SETTING, Define.CONFIG_IS_CLEAR_TEMP) == "false")
                Define.isClearTemp = false;
            else
                Define.isClearTemp = true;
            //缓存目录获取
            string tmp = ConfigHelper.GetValue(Define.CONFIG_SETTING, Define.CONFIG_TEMP_PATH);
            if (tmp != "" && Directory.Exists(tmp))
                Define.tempPath = tmp;
        }

        /// <summary>
        /// 初始化提示功能
        /// </summary>
        private void InitToolTip()
        {
            toolTip = new ToolTip();
            toolTip.AutomaticDelay = 100;
            toolTip.AutoPopDelay = 10000;
            toolTip.InitialDelay = 100;
            toolTip.ReshowDelay = 100;

            toolTip.SetToolTip(picBoxSubtract, "缩小");
            toolTip.SetToolTip(picBoxAdd, "放大");
            toolTip.SetToolTip(picBoxFlipY, "垂直翻转");
            toolTip.SetToolTip(picBoxFlipX, "水平翻转");
            toolTip.SetToolTip(picBoxRotate270, "逆时针旋转90度");
            toolTip.SetToolTip(picBoxRotate90, "顺时针旋转90度");
            toolTip.SetToolTip(picBoxLeft, "上一张图片");
            toolTip.SetToolTip(picBoxRight, "下一张图片");
            toolTip.SetToolTip(picBoxReset, "还原图片");
            
        }

        /// <summary>
        /// 初始化图片
        /// </summary>
        /// <param name="path">图片路径</param>
        private void InitImage(List<ImageModel> lst)
        {
            //btnOpenImage.Visible = false;
            pnlTop.Enabled = true;
            pnlBottom.Enabled = true;

            //ImgSelectedIndex = 0;

            lstImage.Clear();
            lstImage = lst;
           
            tmrAddFolderImages.Start();
        }

        /// <summary>
        /// 添加图片到缩略图中
        /// </summary>
        /// <param name="path"></param>
        /// <param name="index"></param>
        private void AddFolderImages()
        {
            //btnOpenImage.Visible = false;
            pnlImage.Controls.Clear();

            Image.GetThumbnailImageAbort myCallback =
                new Image.GetThumbnailImageAbort(ThumbnailCallback);
            StringBuilder sb = new StringBuilder();
            for (int i = lstImage.Count - 1; i >= 0; i--)
            {
                try
                {
                    Panel pnl = new Panel();
                    pnl.Size = new Size(pnlImage.Height, pnlImage.Height);
                    pnl.BackgroundImageLayout = ImageLayout.Zoom;
                    pnl.Tag = i;
                    pnl.Padding = new System.Windows.Forms.Padding(3);
                    pnl.Dock = DockStyle.Left;

                    PictureBox pic = new PictureBox();
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    pic.Dock = DockStyle.Fill;
                    pic.Click += pic_Click;
                    pnl.Controls.Add(pic);

                    Image img =ImageHelper.ByteArrayToImage(lstImage[i].image);
                    pic.Image = img.GetThumbnailImage(32, 32, myCallback, IntPtr.Zero);
                    img.Dispose();
                    img = null;

                    pnlImage.Controls.Add(pnl);
                   // toolTip.SetToolTip(pic, lstImgPath[i]);
                    //ShowNotify("加载图片 " + (lstImgPath.Count - i) + "/" + lstImgPath.Count);

                    Application.DoEvents();
                }
                catch (Exception ex)//
                {
                  //  LogHelper.WriteError(ex);
                  //  sb.AppendLine(lstImgPath[i]);
                }
            }
            if (sb.ToString().Length > 0)
                MessageBox.Show(sb.ToString() + "\n" + "加载失败，该图片可能已损坏");
            else
                ShowNotify("加载结束");
            RefreshShowImage();
        }

        private bool ThumbnailCallback()
        {
            return false;
        }


        private void tmrShowGif_Tick(object sender, EventArgs e)
        {
            tmrShowGif.Stop();
            if (gifSelectedIndex == -1)
                return;
            long ticks = gifStopwatch.ElapsedMilliseconds;
            long delay = (long)lstGifInfo[gifSelectedIndex].Delay;
            if (delay <= ticks)
            {
                gifSelectedIndex++;
                gifSelectedIndex %= lstGifInfo.Count;
                RefreshShowImage();
                gifStopwatch.Restart();
            }
            tmrShowGif.Start();
        }

        private void tmrAddFolderImages_Tick(object sender, EventArgs e)
        {
            tmrAddFolderImages.Stop();
            AddFolderImages();
        }
        #endregion

        #region 图片移动
        private void picBox_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            mousePoint = MousePosition;
            picturePoint = picBox.Location;
        }

        private void picBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void picBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                int diffX = MousePosition.X - mousePoint.X;
                int diffY = MousePosition.Y - mousePoint.Y;
                picBox.Location = new Point(picturePoint.X + diffX, picturePoint.Y + diffY);
            }
        }
        #endregion

        #region 图片放大缩小

        /// <summary>
        /// 设置图片比例
        /// </summary>
        /// <param name="scale"></param>
        private void SetImageScale(int scale)
        {
            //放大比例限制在 1%-1000%之间
            if (scale < Define.MIN_SCALE)
                imgScale = Define.MIN_SCALE;
            else if (scale > Define.MAX_SCALE)
                imgScale = Define.MAX_SCALE;
            else
                imgScale = scale;
            ShowNotify(imgScale + "%");
            RefreshShowImage();
        }

        /// <summary>
        /// 显示当前比例一段时间后，隐藏Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrScaleShowTime_Tick(object sender, EventArgs e)
        {
            showMilliSecond -= 100;
            if (showMilliSecond <= 0)
            {
                lblScale.Visible = false;
                tmrScaleShowTime.Stop();
            }
        }

        #region 滚轮滚动事件，每次放大或缩小当前图片大小的10%
        /// <summary>
        /// 鼠标滚轮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseWheelEvent(object sender, MouseEventArgs e)
        {
            int scale = this.imgScale;
            int diff = 0;
            diff = (int)(scale * 0.1);
            diff = diff < 1 ? 1 : diff;
            if (e.Delta > 0)
                scale += diff;
            else
                scale -= diff;
            SetImageScale(scale);
        }
        #endregion

        #region 点击放大、缩小按钮，点击一次放大或缩小原图的1%
        private void picBoxSubtract_Click(object sender, EventArgs e)
        {
            SetImageScale(imgScale - Define.SCALE_DIFF);
        }

        private void picBoxAdd_Click(object sender, EventArgs e)
        {
            SetImageScale(imgScale + Define.SCALE_DIFF);
        }
        #endregion

        #region 按住放大、缩小按钮  放大缩小图片 每0.1秒放大或缩小原图的1%
        private void tmrScaleButtonClickTime_Tick(object sender, EventArgs e)
        {
            if (scaleButtonClickFlag == 1)
                SetImageScale(imgScale + Define.SCALE_DIFF);
            else if (scaleButtonClickFlag == -1)
                SetImageScale(imgScale - Define.SCALE_DIFF);
        }

        private void picBoxSubtract_MouseDown(object sender, MouseEventArgs e)
        {
            scaleButtonClickFlag = -1;
            tmrScaleButtonClickTime.Start();
        }

        private void picBoxSubtract_MouseUp(object sender, MouseEventArgs e)
        {
            scaleButtonClickFlag = 0;
            tmrScaleButtonClickTime.Stop();
        }

        private void picBoxAdd_MouseDown(object sender, MouseEventArgs e)
        {
            scaleButtonClickFlag = 1;
            tmrScaleButtonClickTime.Start();

        }

        private void picBoxAdd_MouseUp(object sender, MouseEventArgs e)
        {
            scaleButtonClickFlag = 0;
            tmrScaleButtonClickTime.Stop();
        }
        #endregion

        #endregion

        #region 旋转、翻转
        private void picBoxFlipX_Click(object sender, EventArgs e)
        {
            imgFlipX = !imgFlipX;
            RotateOrFlip("水平翻转");
        }

        private void picBoxFlipY_Click(object sender, EventArgs e)
        {
            imgFlipY = !imgFlipY;
            RotateOrFlip("垂直翻转");
        }

        private void picBoxRotate90_Click(object sender, EventArgs e)
        {
            imgRotate += 90;
            imgRotate %= 360;
            RotateOrFlip("顺时针旋转90°");
        }

        private void picBoxRotate270_Click(object sender, EventArgs e)
        {
            imgRotate += 270;
            imgRotate %= 360;
            RotateOrFlip("逆时针旋转90°");
        }

        /// <summary>
        /// 旋转、翻转后的图片
        /// </summary>
        /// <param name="msg">提示内容</param>
        private void RotateOrFlip(string msg)
        {
            ShowNotify(msg);
            RefreshShowImage();
        }
        #endregion


        #region 切换显示图片

        void pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            Control control = pic.Parent;
            ImgSelectedIndex = int.Parse(control.Tag.ToString());
            ShowNotify((ImgSelectedIndex + 1) + "/" + lstImage.Count);
            RefreshShowImage();
        }

        private void picBoxLeft_Click(object sender, EventArgs e)
        {
            if (ImgSelectedIndex <= 0)
            {
                ShowNotify("已经是第一张");
            }
            else
            {
                ImgSelectedIndex--;
                ShowNotify((ImgSelectedIndex + 1) + "/" + lstImage.Count);
                RefreshShowImage();
            }

        }

        private void picBoxRight_Click(object sender, EventArgs e)
        {
            if (ImgSelectedIndex >= lstImage.Count -1)
            {
                ShowNotify("已经是最后一张");
            }
            else
            {
                ImgSelectedIndex++;
                ShowNotify((ImgSelectedIndex + 1) + "/" + lstImage.Count);
                RefreshShowImage();
            }
        }

        /// <summary>
        /// 将缩略图滚动条滚动到该控件可见处
        /// </summary>
        private void ScrollControlIntoView()
        {
            foreach (Control control in pnlImage.Controls)
            {
                if (control.Tag.ToString() == ImgSelectedIndex.ToString())
                {
                    pnlImage.ScrollControlIntoView(control);
                }
            }
        }
        #endregion

        #region 其它
        private void picBoxSave_Click(object sender, EventArgs e)
        {
            //pnlBottom.Enabled = false;
            //pnlTop.Enabled = false;
            //if (lstImgPath[ImgSelectedIndex].EndsWith(".gif", true, null))
            //    SaveGifImage();
            //else
            //    SaveImage();
            //pnlBottom.Enabled = true;
            //pnlTop.Enabled = true;
        }

        private void picBoxReset_Click(object sender, EventArgs e)
        {
            ResetImage();
        }

        /// <summary>
        /// 中间显示提示
        /// </summary>
        /// <param name="msg"></param>
        private void ShowNotify(string msg)
        {
            lblScale.Text = msg;
            lblScale.BringToFront();
            lblScale.Visible = true;
            showMilliSecond = 1000;//显示一秒     
            tmrScaleShowTime.Start();
        }

        /// <summary>
        /// 重置图片
        /// </summary>
        private void ResetImage()
        {
            imgScale = 100;
            imgRotate = 0;
            imgFlipX = false;
            imgFlipY = false;
            ShowNotify("重置图片");
            RefreshShowImage();
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        //private void SaveImage()
       // {
            //Image img = ImageHelper.Scale(picBox.Image, picBox.Size);
            //SaveFileDialog sfd = GetSaveFileDialog();
            //if (sfd.ShowDialog() == DialogResult.OK)
            //{
            //    img.Save(sfd.FileName);
            //    MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
      //  }

        /// <summary>
        /// 获取保存对话框
        /// </summary>
        /// <returns></returns>
        //private SaveFileDialog GetSaveFileDialog()
        //{
        //    int sepIndex = lstImgPath[ImgSelectedIndex].LastIndexOf('\\');
        //    SaveFileDialog sfd = new SaveFileDialog();
        //    sfd.InitialDirectory = lstImgPath[ImgSelectedIndex].Substring(0, sepIndex);
        //    string fileName = lstImgPath[ImgSelectedIndex].Substring(sepIndex + 1);
        //    int dotIndex = fileName.LastIndexOf('.');
        //    string suffix = fileName.Substring(dotIndex + 1).ToLower();
        //    sfd.FileName = fileName.Substring(0, dotIndex) + "_副本." + suffix;
        //    if (suffix == "gif")
        //    {
        //        sfd.Filter = "GIF图片|*.gif";
        //    }
        //    else
        //    {
        //        sfd.Filter = "JPG图片|*.jpg|PNG图片|*.png|BMP图片|*.bmp";

        //        if (suffix == "jpg")
        //            sfd.FilterIndex = 0;
        //        else if (suffix == "png")
        //            sfd.FilterIndex = 1;
        //        else if (suffix == "bmp")
        //            sfd.FilterIndex = 2;
        //    }
        //    return sfd;
        //}

        /// <summary>
        /// 保存GIF图片
        /// </summary>
        /// <param name="path"></param>
        private void SaveGifImage()
        {
            //SaveFileDialog sfd = GetSaveFileDialog();
            //if (sfd.ShowDialog() == DialogResult.OK)
            //{
            //    AnimatedGifEncoder e = new AnimatedGifEncoder();
            //    e.Start(sfd.FileName);
            //    //-1:不重复,0:重复播放
            //    e.SetRepeat(0);
            //    for (int i = 0; i < lstGifInfo.Count; i++)
            //    {
            //        e.SetDelay(lstGifInfo[i].Delay);
            //        e.AddFrame(GetChangeImage(lstGifInfo[i].Path));
            //        ShowNotify("保存中 " + i + "/" + lstGifInfo.Count);
            //        Application.DoEvents();
            //    }
            //    e.Finish();
            //    MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }


        /// <summary>
        /// 显示经过放大、缩小、旋转、翻转后的图片
        /// </summary>
        private void RefreshShowImage()
        {
            try
            {
                lblImgText.Text = "同目录下所有图片 " + (ImgSelectedIndex + 1) + "/" + lstImage.Count;
               
                picBox.Image = GetChangeImage(lstImage[imgSelectedIndex].image);
                //当图片宽度或高度小于窗体时，修改图片位置
                if (this.Width >= picBox.Width && this.Height >= picBox.Height)
                    picBox.Location = new Point(this.Width / 2 - picBox.Width / 2, this.Height / 2 - picBox.Height / 2);
                else if (this.Width >= picBox.Width)
                    picBox.Location = new Point(this.Width / 2 - picBox.Width / 2, this.Height / 2 - picBox.Height / 2);
                //else if (this.Height >= picBox.Height)
                //    picBox.Location = new Point(picBox.Location.X, this.Height / 2 - picBox.Height / 2);
                string str = string.Format("尺寸{1}×{2} 比例{3}% 顺时针旋转{4}° {5} {6}"
                    , "", picBox.Image.Width, picBox.Image.Height, imgScale, imgRotate, imgFlipX ? "水平翻转" : "", imgFlipY ? "垂直翻转" : "");
                lblMsg.Text = str;
                //选中的缩略图添加背景颜色
                foreach (Control c in pnlImage.Controls)
                {
                    if (c.Tag.ToString() == ImgSelectedIndex.ToString())
                        c.BackColor = Color.Blue;
                    else
                        c.BackColor = SystemColors.Control;
                }
                ScrollControlIntoView();
            }
            catch (Exception ex)
            {
                ShowNotify("该图片可能已损坏");
                LogHelper.WriteError(ex);
            }
        }

        /// <summary>
        /// 获取变形后的图片
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private Image GetChangeImage(string path)
        {
            Image imgNew = Image.FromFile(path);
            //放大、缩小  
            //Image imgNew = Image.FromFile(path);
            int w = imgNew.Width * imgScale / 100;
            int h = imgNew.Height * imgScale / 100;
            w = w == 0 ? 1 : w;
            h = h == 0 ? 1 : h;
            imgNew = ImageHelper.Scale(imgNew, new Size(w, h));
            //旋转
            if (imgRotate == 90)
                ImageHelper.Rotate90(imgNew);
            else if (imgRotate == 180)
                ImageHelper.Rotate180(imgNew);
            else if (imgRotate == 270)
                ImageHelper.Rotate270(imgNew);
            //翻转
            if (imgFlipX)
                ImageHelper.FlipX(imgNew);
            if (imgFlipY)
                ImageHelper.FlipY(imgNew);
            return imgNew;
        }

        private Image GetChangeImage(byte[] bytes)
        {
            Image imgNew = ImageHelper.ByteArrayToImage(bytes);
            //放大、缩小  
            //Image imgNew = Image.FromFile(path);
            int w = imgNew.Width * imgScale / 100;
            int h = imgNew.Height * imgScale / 100;
            w = w == 0 ? 1 : w;
            h = h == 0 ? 1 : h;
            imgNew = ImageHelper.Scale(imgNew, new Size(w, h));
            //旋转
            if (imgRotate == 90)
                ImageHelper.Rotate90(imgNew);
            else if (imgRotate == 180)
                ImageHelper.Rotate180(imgNew);
            else if (imgRotate == 270)
                ImageHelper.Rotate270(imgNew);
            //翻转
            if (imgFlipX)
                ImageHelper.FlipX(imgNew);
            if (imgFlipY)
                ImageHelper.FlipY(imgNew);
            return imgNew;
        }

        private void PictureDetail_SizeChanged(object sender, EventArgs e)
        {
         
            lblScale.Location = new Point(this.Width / 2 - lblScale.Width / 2, this.Height / 2 - lblScale.Height / 2);
        }

        private void picBoxSetting_Click(object sender, EventArgs e)
        {
          //  new Frm_Setting().ShowDialog();
        }

       

        /// <summary>
        /// 打开一张图片
        /// </summary>
        //private void OpenFile()
        //{
        //    OpenFileDialog ofd = new OpenFileDialog();
        //    ofd.Filter = "图片文件|*.gif;*.bmp;*.jpg;*.png";
        //    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        InitImage(ofd.FileName);
        //    }
        //}

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            //OpenFile();
        }

        private void PictureDetail_MouseMove(object sender, MouseEventArgs e)
        {
            //被PictureBox挡住后无效，改用Timer定时检测鼠标位置
            return;
            if (e.Y < 100 || e.Y >= this.Height - 150)
            {
                pnlTop.Visible = true;
                pnlBottom.Visible = true;
            }
            else
            {
                pnlBottom.Visible = false;
                pnlTop.Visible = false;
            }

        }

        private void PictureDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //清除缓存
                if (Define.isClearTemp)
                {
                    string[] directories = Directory.GetDirectories(Define.tempPath);
                    foreach (string dir in directories)
                    {
                        if (dir.StartsWith(Define.tempPath + "\\" + Define.TEMP_FILE_HEAD))
                            Directory.Delete(dir, true);
                    }
                }
            }
            catch { }
        }
        
        private void tmrGetMousePosition_Tick(object sender, EventArgs e)
        {
            if (MousePosition.X >= this.Location.X && MousePosition.X <= this.Location.X + this.Width
                && MousePosition.Y >= this.Location.Y && MousePosition.Y <= this.Location.Y + this.Height
                && (MousePosition.Y < this.Location.Y + 150 || MousePosition.Y >= this.Location.Y + this.Height - 150)
                )
            {
                pnlTop.Visible = true;
                pnlBottom.Visible = true;
            }
            else
            {
                pnlBottom.Visible = false;
                pnlTop.Visible = false;
            }
        }

        #endregion




    }
}
