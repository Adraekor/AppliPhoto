using System.IO;

namespace ApplicationPhoto
{
    class DossierImage
    {
        static string imagePath = @"c:\monApplicationPhoto\Images";

        public DossierImage()
        {
        }


        public static void CreateFolder()
        {
            if (!Directory.Exists(imagePath))
                Directory.CreateDirectory(imagePath);
        }   

    }
}
