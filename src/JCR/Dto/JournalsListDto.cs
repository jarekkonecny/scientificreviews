using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientificReviews.JCR.Dto
{
    public class JournalsListDto
    {
        public MetadataDto Metadata { get; set; }
        public List<JournalHitDto> Hits { get; set; }
    }

    public class MetadataDto
    {
        public int Page { get; set; }
        public int Limit { get; set; }
    }

    public class JournalHitDto
    {
        public string Id { get; set; }
        public string Self { get; set; }
        public string Name { get; set; }
    }

}
