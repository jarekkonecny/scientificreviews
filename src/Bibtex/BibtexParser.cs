using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientificReviews.Bibtex
{
    public class BibtexParser
    {

        enum EntryState
        {
            NotInEntry,
            EntryType,
            EntryKey,
            TagKey,
            TagValue
        }

        public BibtexEntry[] ParseFile(string content)
        {
            content = Preprocess(content);

            int length = content.Length;
            EntryState entryState = EntryState.NotInEntry;

            List<BibtexEntry> entries = new List<BibtexEntry>();

            string entryType = string.Empty;
            string entryKey = string.Empty;
            string tagKey = string.Empty;
            string tagValue = string.Empty;
            BibtexTag tag = null;
            List<BibtexTag> tagList = new List<BibtexTag>();

            int esc = 0;
            for (int i = 0; i < length; i++)
            {
                char c = content[i];

                switch (entryState)
                {
                    case EntryState.NotInEntry:
                        if (c != '@')
                            continue;
                        entryState = EntryState.EntryType;
                        break;

                    case EntryState.EntryType:
                        if (c == '{')
                        {
                            entryType = entryType.ToLower().Trim();
                            entryState = EntryState.EntryKey;
                        }
                        else
                        {
                            entryType += c;
                        }
                        break;

                    case EntryState.EntryKey:
                        if (c == ',')
                        {
                            entryKey = entryKey.ToLower().Trim();
                            entryState = EntryState.TagKey;
                        }
                        else
                        {
                            entryKey += c;
                        }
                        break;

                    case EntryState.TagKey:
                        if (tag == null)
                        {
                            tag = new BibtexTag();
                            tagKey = string.Empty;
                            tagValue = string.Empty;
                        }
                        if (c == '}')
                        {
                            entries.Add(new BibtexEntry()
                            {
                                Key = entryKey,
                                Tags = tagList.ToArray(),
                                Type = entryType,
                            });
                            entryKey = string.Empty;
                            tagList.Clear();
                            tag = null;
                            entryType = string.Empty;
                            entryState = EntryState.NotInEntry;

                        }
                        else if (c == '=')
                        {
                            // Nothing
                        }
                        else if (c == '{')
                        {
                            tag.Key = tagKey.Trim(' ', ',').ToLower();                            
                            entryState = EntryState.TagValue;
                        }
                        else
                        {
                            tagKey += c;
                        }
                        break;

                    case EntryState.TagValue:
                        if (c == '}' && esc == 0)
                        {
                            tag.Value = tagValue.Trim();
                            tagList.Add(tag);
                            tag = null;
                            entryState = EntryState.TagKey;
                        }
                        else
                        {
                            if (c == '{')
                                esc++;
                            if (c == '}')
                                esc--;
                            tagValue += c;
                        }
                        break;
                }

            }
            return entries.ToArray();

        }

        private string Preprocess(string content)
        {
            content = content.Replace('\r',' ');
            content = content.Replace('\n', ' ');
            content = content.Replace('\t', ' ');
            while (content.IndexOf("  ") != -1)
            {
                content = content.Replace("  ", " ");
            }
            return content;
        }
    }
}
