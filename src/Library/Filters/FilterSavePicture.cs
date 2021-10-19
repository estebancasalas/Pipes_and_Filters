namespace CompAndDel.Filters
{
    public class FilterSavePicture : IFilter
    {
        public IPicture Filter(IPicture image)
        {

            PictureProvider provider1 = new PictureProvider();
            provider1.SavePicture(image, @"filteredluke.jpg");
            return image;
        }
    }
}