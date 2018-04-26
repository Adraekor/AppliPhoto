using System.Collections.Generic;

namespace ApplicationPhoto
{
    public class ImageData
    {
        enum eCommentActionType { Add, Delete }

        public string fileName { set; get; }
        public List<string> tags { set; get; }

        public ImageData( string filename, List< string > tagList )
        {
            fileName = filename;
            tags = tagList;
        }

        private void ModifyTagList( string tag, eCommentActionType action )
        {
            if( action == eCommentActionType.Add )
            {
                if( !tags.Contains( tag ) )
                    tags.Add( tag );
            }
            else
            {
                tags.RemoveAll( s => s.Equals( tag ) );
            }
        }

        private List<string> readTagsOfPicture() => tags;
    }
}
