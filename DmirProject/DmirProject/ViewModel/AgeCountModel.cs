using BusinessLayer;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DmirProject.ViewModel
{
    public class AgeCountModel
    {
        public int Pages { get; set; }
        public IEnumerable<AgeCount> AgeCounts { get; set; }
        public int TotalCount { get; set; }
    }
}