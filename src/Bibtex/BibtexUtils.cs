using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientificReviews.Bibtex
{
    public class BibtexUtils
    {
        public static List<BibtexEntry> RemoveDuplicateEntriesByTitle(List<BibtexEntry> entries)
        {
            var uniqueEntries = new List<BibtexEntry>();
            var seenTitles = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var entry in entries)
            {
                var titleTag = entry.Tags.FirstOrDefault(tag => tag.Key.Equals("title", StringComparison.OrdinalIgnoreCase));
                if (titleTag != null && !seenTitles.Contains(titleTag.Value))
                {
                    seenTitles.Add(titleTag.Value);
                    uniqueEntries.Add(entry);
                }
            }

            return uniqueEntries;
        }
    }
}
