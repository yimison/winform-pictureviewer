using PictureViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureManage
{
    public partial class PictureList : Form
    {
        List<ImageModel> list = null;
        public PictureList()
        {
            InitializeComponent();
        }
        public PictureList(string type)
        {
            InitializeComponent();
            LoadListByType(type);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void LoadListByType(string type)
        {
            imageList1.Images.Clear();
            lstPictureView.Clear();

            //往数据库去图片列表
            PictureDal dal = new PictureDal();
             list = dal.GetImageInfoListByType(type);

            for (int i = 0; i < list.Count; i++)
            {
                MemoryStream ms = new MemoryStream(list[i].image);
                ms.Position = 0;
                Image obj = Image.FromStream(ms);
                imageList1.Images.Add(obj);
                lstPictureView.Items.Add(list[i].PictureName, i);
                lstPictureView.Items[i].ImageIndex = i;
                lstPictureView.Items[i].Name = list[i].PictureName;
                imageList1.ImageSize = new Size(100, 100);
            }
            lstPictureView.LargeImageList = imageList1;
            //初始化imagelist

            //初始化listview
        }

        private void lstPictureView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //list
            ListViewItem item = lstPictureView.GetItemAt(e.X, e.Y);

            if (item != null)
            {
                var PictureDetail = new PictureDetail(list,lstPictureView.SelectedItems[0].Index);
                var obj = PictureDetail.ShowDialog();
            }
        }
    }
}
