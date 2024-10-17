using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScientificReviews.Bibtex
{
    public class BibtexEntry
    {
        public string Type { get; set; }
        public string Key { get; set; }
        public BibtexTag[] Tags { get; set; }

        public string GetTagKey (string key)
        {
            if (Tags == null || Tags.Length == 0)
                return null;
            else
            {
                foreach (var tag in Tags)
                {
                    if (tag.Key == key)
                        return tag.Value;
                }
                return null;
            }
        }
        public override string ToString()
        {
            if (Tags == null || Tags.Length == 0)
                return Key;
            else
            {
                foreach (var tag in Tags)
                {
                    if (tag.Key == "title")
                        return tag.Value;
                }
                return Key;
            }
        }

    }

    public class BibtexTag
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
