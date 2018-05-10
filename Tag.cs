using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AppliPhoto
{
    public class Tag
    {
        public string name;
        public List< string > tags = new List<string>();

        public Tag( string iName )
        {
            name = iName;
        }

        public void AddSubTag( string iSubTag )
        {
            tags.Add(iSubTag);
        }


    }
}
