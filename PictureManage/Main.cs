﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace PictureManage
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }


        protected override void OnLoad(EventArgs e)
        {
            LoadTypeList();
            base.OnLoad(e);
        }
        //加载相册
        private void LoadTypeList()
        {
            imageList1.Images.Clear();
            lstPictureView.Clear();

            //往数据库去图片列表
            PictureDal dal = new PictureDal();
            var list = dal.GetImageTypeList();
            for (int i = 0; i < list.Count; i++)
            {
                MemoryStream ms = new MemoryStream(list[i].image);
                ms.Position = 0;
                Image obj = Image.FromStream(ms);
                imageList1.Images.Add(obj);
                lstPictureView.Items.Add(list[i].AlbumName + " 共:" + list[i].PicsCount + " 张", i);
                lstPictureView.Items[i].ImageIndex = i;
                lstPictureView.Items[i].Name = list[i].AlbumCode.ToString();
               // lstPictureView.Items[i].Text = list[i].AlbumCode.ToString();
                imageList1.ImageSize = new Size(100,100);

            }
            lstPictureView.LargeImageList = imageList1;
            //初始化imagelist

            //初始化listview
        }

        
        private void lstPictureView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var me = (MouseEventArgs)e;
            ListViewItem item = lstPictureView.GetItemAt(me.X, me.Y);

            if (item != null)
            {
                //弹出图片列表窗体
                var form = new PictureList(item.Name);
                form.ShowDialog();
            }
            else
            { }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //跳到上传的窗体
            var frm = new Upload();
            if (frm.ShowDialog()==DialogResult.None)
            {

            }
            LoadTypeList();
        }
    }
}
