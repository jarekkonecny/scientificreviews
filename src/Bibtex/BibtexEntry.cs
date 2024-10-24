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

        public string GetTagValue (string key)
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

        public BibtexTag GetTag(string key)
        {
            if (Tags == null || Tags.Length == 0)
                return null;
            else
            {
                foreach (var tag in Tags)
                {
                    if (tag.Key == key)
                        return tag;
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

        internal void RemoveIfExists(string key)
        {
            List<BibtexTag> toDelete = new List<BibtexTag>();
            foreach(var tag in Tags)
            {
                if (tag.Key  == key)
                {
                    toDelete.Add(tag);
                }
            }
            var list = Tags .ToList();
            foreach (var tag in toDelete)
            {
                list.Remove(tag);
            }
            Tags = list.ToArray();
        }
    }

    public class BibtexTag
    {
        public BibtexTag()
        {
                
        }

        public BibtexTag(string key, string value)
        {
            Key = key;
            Value = value;
        }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
