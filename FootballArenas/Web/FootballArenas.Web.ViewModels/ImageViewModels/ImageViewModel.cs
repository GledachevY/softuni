namespace FootballArenas.Web.ViewModels.ImageViewModels
{
    public class ImageViewModel
    {
        public string Id { get; set; }

        public bool IsDelete { get; set; }

        public string Extension { get; set; }

        public bool IsMainImage { get; set; }

        public string Path => $"/images/sportComplexes/{this.Id}.{this.Extension}";
    }
}
