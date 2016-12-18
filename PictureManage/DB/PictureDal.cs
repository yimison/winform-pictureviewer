using ChenKH.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureManage
{
    public class PictureDal
    {
        /// <summary>
        /// 获取相册
        /// </summary>
        /// <returns></returns>
        public List<AlbumForDropdownList> GetImageTypeList()
        {
            List<AlbumForDropdownList> list = new List<AlbumForDropdownList>();
            //get album
            string sql = "select * from _Album ";
            var dt=SqlHelper.ExecuteDatatableText(sql, null);
            foreach (DataRow item in dt.Rows)
            {
                AlbumForDropdownList obj = new AlbumForDropdownList();
                obj.AlbumCode =int.Parse( item["Id"].ToString());
                obj.AlbumName = item["Name"].ToString();

                string _sql = "select image from _Image where AlbumCode="+ item["Id"].ToString();
                var bytes = SqlHelper.ExecuteScalarText(_sql, null);
                if (bytes!=null)
                {
                    obj.image =(byte[]) bytes;
                }
                else
                {
                    obj.image =ImageHelper.ImageToBytes(Image.FromFile(@"images\\NoExistPics.png"), ImageFormat.Png);
                }
                 _sql = "select count(1) from _Image where AlbumCode=" + item["Id"].ToString();
                var count = SqlHelper.ExecuteScalarText(_sql, null);
                obj.PicsCount = int.Parse(count.ToString());
                list.Add(obj);
            }

            return list;
        }
        /// <summary>
        /// 获取相册的图片
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<ImageModel> GetImageInfoListByAlbumCode(int albumCode)
        {
            List<ImageModel> list = new List<ImageModel>();

            string sql = "select * from _Image where AlbumCode="+albumCode;
            var dt = SqlHelper.ExecuteDatatableText(sql, null);
            foreach (DataRow item in dt.Rows)
            {
                ImageModel model = new ImageModel();
                model.Id =int.Parse( item["Id"].ToString());
                model.AlbumName = item["AlbumName"].ToString();
                model.AlbumCode = albumCode;
                model.PictureName = item["PictureName"].ToString();
                model.image = (byte[])item["image"];
                list.Add(model);
            }
                return list;
        }
        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int SaveImage(ImageModel list)
        {
            return 0;
        }

       
        /// <summary>
        /// 新增图片
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int Insert(ImageModel input)
        {
            string sql = "insert into _Image(AlbumCode,AlbumName,PictureName,image) values(@AlbumCode,@AlbumName,@PictureName,@image)";


            var special = new SqlParameter("@image", SqlDbType.Image);
            special.Value = input.image;
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@AlbumCode",input.AlbumCode),
                new SqlParameter("@AlbumName",input.AlbumName),
                new SqlParameter("@PictureName",input.PictureName),
                special
            };
            
           
            int result = SqlHelper.ExecteNonQueryText(sql, paras);
            return result;
        }
        /// <summary>
        /// 批量新增图片
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public int BulkInsert(List<ImageModel> input)
        {
            int success = 0;
            foreach (var item in input)
            {
                if (Insert(item) > 0)
                {
                    success++;
                }
            }
            return success;
        }
        /// <summary>
        /// 新增相册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertAlbum(Album model)
        {
            string sql = "insert into _Album(Name) values(@Name)";
            SqlParameter par = new SqlParameter("@Name", SqlDbType.NVarChar);
            par.Value = model.Name;
            int result = SqlHelper.ExecteNonQueryText(sql, par);
            return result;
        }
    }
}
