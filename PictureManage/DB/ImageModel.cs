using System;
using System.Collections.Generic;

namespace PictureManage
{
    public class ImageModel
    {
        public int Id { get; set; }
        public int AlbumCode { get; set; }
        /// <summary>
        /// 相册名
        /// </summary>
        public string AlbumName { get; set; }
        /// <summary>
        /// 图片名
        /// </summary>
        public string PictureName { get; set; }

        public byte[] image { get; set; }
    }
    /// <summary>
    /// 下拉列表显示的相册模型
    /// </summary>
    public class AlbumForDropdownList
    {
        public int AlbumCode { get; set; }
        public string AlbumName { get; set; }
        public byte[] image { get; set; }
        /// <summary>
        /// 图片数量
        /// </summary>
        public int PicsCount { get; set; }

    }
   
    public class Album
    {
        /// <summary>
        /// 相册ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 相册名称
        /// </summary>
        public string Name { get; set; }
    }
}