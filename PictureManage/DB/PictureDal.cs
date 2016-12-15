using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureManage
{
    public class PictureDal
    {

        public List<ImageModel> GetImageTypeList()
        {
            List<ImageModel> list = new List<ImageModel>();
          
            for (int i = 0; i < 5; i++)
            {
                FileStream fs = null;
                try
                {
                    
                    string strFileName = "pics\\test"+(i+1)+".jpg";
                    ImageModel obj = new ImageModel();
                    obj.Id = i;
                    obj.AlbumName = "test type "+i.ToString();
                    obj.PictureName = strFileName;
                    fs = File.OpenRead(strFileName);
                    byte[] imageb = new byte[fs.Length];
                    fs.Read(imageb, 0, imageb.Length);

                    obj.image = imageb;
                    list.Add(obj);
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }
            return list;
        }
        public List<ImageModel> GetImageInfoListByType(string type)
        {
            List<ImageModel> list = new List<ImageModel>();

            for (int i = 0; i < 5; i++)
            {
                FileStream fs = null;
                try
                {
                    string strFileName = "pics\\test" + (i + 1) + ".jpg";
                    ImageModel obj = new ImageModel();
                    obj.Id = i;
                    obj.AlbumName = type;
                    obj.PictureName = strFileName;
                    fs = File.OpenRead(strFileName);
                    byte[] imageb = new byte[fs.Length];
                    fs.Read(imageb, 0, imageb.Length);

                    obj.image = imageb;
                    list.Add(obj);
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }
            return list;
        }

        public int SaveImage(ImageModel list)
        {
            return 0;
        }

        public void imgToDB(string sql)
        { //参数sql中要求保存的imge变量名称为@images
          //调用方法如：imgToDB("update UserPhoto set Photo=@images where UserNo='" + temp + "'");
          //FileStream fs = File.OpenRead(t_photo.Text);
          //byte[] imageb = new byte[fs.Length];
          //fs.Read(imageb, 0, imageb.Length);
          //fs.Close();
          //SqlCommand com3 = new SqlCommand(sql, con);
          //com3.Parameters.Add("@images", SqlDbType.Image).Value = imageb;
          //if (com3.Connection.State == ConnectionState.Closed)
          //    com3.Connection.Open();
          //try
          //{
          //    com3.ExecuteNonQuery();
          //}
          //catch
          //{ }
          //finally
          //{ com3.Connection.Close(); }
        }

        public int Insert(ImageModel input)
        {
            //insert 
            return 0;
        }

        public int BulkInsert( List<ImageModel> input)
        {
            int success = 0;
            foreach (var item in input)
            {
                if (Insert(item)>0)
                {
                    success++;
                }
            }
            return success;
        }
    }
}
