using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScientificReviews.Bibtex
{
    public class BibtexUtils
    {

        public static List<BibtexEntry> RemoveDuplicateEntriesByTag(List<BibtexEntry> entries, string tagName)
        {
            var uniqueEntries = new List<BibtexEntry>();
            var seenTitles = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var uniqueEntriesDic = new Dictionary<string,BibtexEntry>();
            foreach (var entry in entries)
            {
                var titleTag = entry.Tags.FirstOrDefault(tag => tag.Key.Equals(tagName, StringComparison.OrdinalIgnoreCase));
                if (titleTag != null && !seenTitles.Contains(titleTag.Value))
                {
                    seenTitles.Add(titleTag.Value);
                    uniqueEntries.Add(entry);
                    uniqueEntriesDic.Add(titleTag.Value.ToLower(), entry);
                }
                else
                {
                    Merge(entry, uniqueEntriesDic[titleTag.Value.ToLower()]);
                }
            }

            return uniqueEntries;
        }

        private static void Merge(BibtexEntry entry1, BibtexEntry entry2)
        {
            List<BibtexTag> mergedTags = entry1.Tags.ToList();
            Dictionary<string, BibtexTag> tagsDictionary = mergedTags.ToDictionary(tag => tag.Key);

            foreach (var tag in entry2.Tags)
            {
                if (!tagsDictionary.ContainsKey(tag.Key))
                {
                    mergedTags.Add(tag);
                }
            }

            entry1.Tags = mergedTags.ToArray();
            entry2.Tags = mergedTags.ToArray();

        }

        public static void UpdatePages(List<BibtexEntry> entries)
        {
            foreach (var entry in entries)
            {
                var tag = entry.GetTag("pages");
                if ( tag != null)
                {
                    string[] numbers = Regex.Split(tag.Value, "[^0-9]+");
                    int length = numbers.Length;
                    string ret = string.Empty;
                    for (int i = 0; i < length; i++)
                    {
                        ret += numbers[i];
                        if (i + 1 != length)
                        {
                            ret += "--";
                        }
                    }   
                    tag.Value = ret;
                }
            }                       
        }

        public static string RemoveLatex(string value)
        {
            value = value.Replace("\\&", "&");
            value = value.Replace("{", "");
            value = value.Replace("}", "");
            return value;
        }
    }
}
