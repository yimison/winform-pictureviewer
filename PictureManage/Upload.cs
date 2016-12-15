using ChenKH.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureManage
{
    public partial class Upload : Form
    {
        List<ImageModel> list = null;
        public Upload()
        {
            InitializeComponent();
            InitTypeDropDownList();
            list = new List<ImageModel>();

        }

        /// <summary>
        /// 初始化相册列表
        /// </summary>
        void InitTypeDropDownList()
        {
            //get type list
            PictureDal dal = new PictureDal();
            List<ImageModel> list = dal.GetImageTypeList();
            //bind list control
            foreach (var item in list)
            {
                cmbImageList.Items.Add(new MyItem(item.AlbumName, ImageHelper.ByteArrayToImage(item.image)));
            }

            //默认选中项索引
            cmbImageList.SelectedIndex = 0;
            //自绘组合框需要设置的一些属性
            cmbImageList.ComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            cmbImageList.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbImageList.ComboBox.ItemHeight = 30;
            cmbImageList.ComboBox.Width = 170;
            //添加DrawItem事件处理函数
            cmbImageList.ComboBox.DrawItem += comboBox_DrawItem;
            cmbImageList.ComboBox.SelectedIndexChanged += comboBox_SelectedChange;
        }

        private void comboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if ((e.State & DrawItemState.Selected) != 0)//鼠标选中在这个项上
            {
                //渐变画刷
                LinearGradientBrush brush = new LinearGradientBrush(e.Bounds, Color.FromArgb(255, 251, 237),
                                                 Color.FromArgb(255, 236, 181), LinearGradientMode.Vertical);
                //填充区域
                Rectangle borderRect = new Rectangle(3, e.Bounds.Y -1, e.Bounds.Width - 5, e.Bounds.Height - 2);

                e.Graphics.FillRectangle(brush, borderRect);
                //画边框
                Pen pen = new Pen(Color.FromArgb(229, 195, 101));
                e.Graphics.DrawRectangle(pen, borderRect);
            }
            else
            {
                SolidBrush brush = new SolidBrush(Color.FromArgb(217, 223, 230));
                e.Graphics.FillRectangle(brush, e.Bounds);
            }
            //获得项图片,绘制图片
            MyItem item = (MyItem)cmbImageList.Items[e.Index];
            Image img = item.Img;
            //图片绘制的区域
            Rectangle imgRect = new Rectangle(6, e.Bounds.Y -3, 25, 25);
            e.Graphics.DrawImage(img, imgRect);
            //文本内容显示区域
            Rectangle textRect =
                new Rectangle(imgRect.Right-2, imgRect.Y, e.Bounds.Width - imgRect.Width, e.Bounds.Height - 2);
            //获得项文本内容,绘制文本
            String itemText = cmbImageList.Items[e.Index].ToString();
            //文本格式垂直居中
            StringFormat strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(itemText, new Font("宋体", 12), Brushes.Black, textRect, strFormat);
        }

        private void comboBox_SelectedChange(object sender, EventArgs e)
        {
            MessageBox.Show("index:"+((MyItem)cmbImageList.ComboBox.SelectedItem).ToString());
        }

        public void DoUpload()
        {
            PictureDal dal = new PictureDal();
            //init list
            

            //insert db
            int success=dal.BulkInsert(list);

            MessageBox.Show("成功上传:"+success+" 个图片.");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            PictureBoxClick(pb);
        }

        public void PictureBoxClick(PictureBox pb)
        {
            //get the location
            var col_index = tableLayoutPanel1.GetColumn(pb);
            var row_index = tableLayoutPanel1.GetColumn(pb);
          
            //get image
            OpenFileDialog ofdl = new OpenFileDialog();
            ofdl.Filter = "(*.jpg,*.png,*.jpeg,*.bmp,*.gif)|*.jgp;*.png;*.jpeg;*.bmp;*.gif";
            var result = ofdl.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            string strFileName = ofdl.FileName;
            Image image = Image.FromFile(strFileName);
            //change image
            pb.Image = image;
            pb.Enabled = false;

            //create addicon
            PictureBox newPB = new PictureBox();
            newPB.Cursor = System.Windows.Forms.Cursors.Hand;
            newPB.Image = Image.FromFile("images\\addicon1.png");
            newPB.Location = new System.Drawing.Point(3, 3);
            newPB.Name = "pictureBox"+new Random(1);
            newPB.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            newPB.Size = new System.Drawing.Size(187, 136);
            newPB.TabIndex = 0;
            newPB.TabStop = false;
            newPB.Location = new Point(pb.Location.X+100,pb.Location.Y);
            newPB.Click += new System.EventHandler(this.pictureBox_Click);
            tableLayoutPanel1.Controls.Add(newPB);
            if (row_index==4)
            {
                tableLayoutPanel1.SetColumn(newPB, 0);
                tableLayoutPanel1.SetColumn(newPB, row_index+1);
            }
            else
            {
                tableLayoutPanel1.SetColumn(newPB, col_index + 1);
                tableLayoutPanel1.SetColumn(newPB, row_index);
            }

            //add to the list
            ImageModel im = new ImageModel();
            im.AlbumName = ((MyItem)cmbImageList.ComboBox.SelectedItem).Text;
            im.PictureName = Path.GetFileName(strFileName);

            ImageFormat obj;
            string extendName = Path.GetExtension(strFileName).Substring(1).ToLower();
            if (extendName=="png")
            {
                obj = ImageFormat.Png;
            }
            else if (extendName == "jpg")
            {
                obj = ImageFormat.Jpeg;
            }
            else if (extendName == "jpeg")
            {
                obj = ImageFormat.Jpeg;
            }
            else if (extendName == "Bmp")
            {
                obj = ImageFormat.Bmp;
            }
            else
            {
                obj = ImageFormat.Jpeg;

            }
            im.image = ImageHelper.ImageToBytes(image, obj);
            list.Add(im);
        }
    }


    public class MyItem
    {
        //项文本内容
        public String Text { get; set; }
        //项图片
        public Image Img;
        public MyItem(String text, Image img)
        {
            Text = text;
            Img = img;
        }
        //重写ToString函数，返回项文本
        public override string ToString()
        {
            return Text;
        }
    }
}
