using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDojo.Client.Shared
{
    //Armand
    public class FAQ
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }

    //Teboho
    public class Job
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Company { get; set; }

        public decimal? Compensation { get; set; }

        public int? MinimumExperience { get; set; }

        public string Location { get; set; }

        public string Department { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
