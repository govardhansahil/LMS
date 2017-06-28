using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class BookHistoryModel
    {
        public int BookID { get; set; }

        public int UserID { get; set; }

        public DateTime OperationPerformedAt { get; set; }

        public DateTime ReturnedAt { get; set; }

        public string Remarks { get; set; }

        public int PerformedByID { get; set; }

        // Issue, all feilds will be filled
        // Disable, UserID will be null
        public string Operation { get; set; }
    }
}
