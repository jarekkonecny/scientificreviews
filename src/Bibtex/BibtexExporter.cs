using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientificReviews.Bibtex
{
    public class BibtexExporter
    {
        public string EntryToString(BibtexEntry entry)
        {
            string ret = $"@{entry.Type}{{{entry.Key},{Environment.NewLine}";
            foreach (var tag in entry.Tags)
            {
                ret += $"    {tag.Key} = {{{tag.Value}}}{Environment.NewLine}";
            }
            ret += $"}}{Environment.NewLine}{Environment.NewLine}";
            return ret;
        }

        public string EntriesToString(BibtexEntry[] entries)
        {
            string ret = string.Empty;
            foreach (var entry in entries)
            {
                ret += EntryToString(entry);
            }
            return ret;
        }

        public string[] GetDois(BibtexEntry[] entries)
        {
            List<string> ret = new List<string>();
            foreach (var entry in entries)
            {
                string doi = entry.GetTagValue("doi");
                if (doi != null)
                {
                    ret.Add(doi);
                }
                else
                {

                }
            }
            return ret.ToArray();
        }

    }
}
