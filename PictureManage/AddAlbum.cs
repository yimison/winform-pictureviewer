using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureManage
{
    public partial class AddAlbum : Form
    {
        public AddAlbum()
        {
            InitializeComponent();
        }

        private void btnAddAlbum_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbAlbumName.Text))
            {
                MessageBox.Show("请填写相册名称");
                return;
            }
            PictureDal dal = new PictureDal();
            Album model = new Album()
            {
                Name = txbAlbumName.Text
            };
           int result= dal.InsertAlbum(model);
            if (result!=1)
            {
                MessageBox.Show("新增相册失败");
            }
            this.Close();
        }
    }
}
