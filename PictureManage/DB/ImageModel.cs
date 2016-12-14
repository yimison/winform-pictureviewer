namespace PictureManage
{
    public class ImageModel
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string TypeName { get; set; }

        public string FileName { get; set; }

        public byte[] image { get; set; }
    }
}