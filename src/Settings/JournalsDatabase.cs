using ScientificReviews.JCR.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientificReviews.Settings
{
    public class JournalsDatabase
    {
        public JournalsDatabase()
        {
            //Journals = new List<JournalHitDto>();
            JournalReports = new List<JournalReportsDto>();
        }
        //public List<JournalHitDto> Journals { get; set; }
        public List<JournalReportsDto> JournalReports { get; set; }
    }
}
