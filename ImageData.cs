using System.Collections.Generic;

namespace AppliPhoto
{
    public class ImageData
    {
        public string fileName { set; get; }
        public List<string> tags { set; get; }

        public ImageData( string filename, List< string > tagList )
        {
            fileName = filename;
            tags = tagList;
        }

        public void AddTag( string tag )
        {
            tag = tag.Trim();
            if (!tags.Contains(tag))
                tags.Add(tag);
        }

        public void DeleteTag(string tag)
        {
            tags.Remove(tag.Trim());
        }

        public void ModifyTagList( string newTag, string oldTag )
        {
            tags[ tags.IndexOf( oldTag.Trim() ) ] = newTag.Trim();
        }
    }
}
