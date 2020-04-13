using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PagedListRenderOptions = X.PagedList.Mvc.Core.Common.PagedListRenderOptions;

namespace eDnevnik.Helper
{
    public class PaginationStyling : PagedListRenderOptions
    {
        public PaginationStyling() : base()
        {
            LiElementClasses = new string[] { "page-item" };
            PageClasses = new string[] { "page-link" };
            DisplayLinkToIndividualPages = true;
            LinkToPreviousPageFormat = "< Nazad";
            LinkToNextPageFormat = "Naprijed >";
        }
    }
}
