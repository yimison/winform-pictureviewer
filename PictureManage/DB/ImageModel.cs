namespace PictureManage
{
    public class ImageModel
    {
        public int Id { get; set; }
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
}