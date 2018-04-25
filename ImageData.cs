using System.Collections.Generic;

namespace ApplicationPhoto
{
    public class ImageData
    {
        public string fileName { set; get; }
        public List<string> tags;

        public ImageData(string filename, List<string> tagList)
        {
            fileName = filename;
            tags = tagList;
        }
    }
}
