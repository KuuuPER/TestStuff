using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DmirProject.Infrastructure
{
    public class PageConfig
    {
        public PageConfig(string elemsPerPage)
        {
            //Default value
            int count = 30;

            int.TryParse(elemsPerPage, out count);
            
            ElementsPerPage = count;
        }

        public int ElementsPerPage { get; private set; }
    }
}