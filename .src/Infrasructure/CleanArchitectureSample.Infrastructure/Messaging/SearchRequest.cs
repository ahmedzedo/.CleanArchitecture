using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureSample.Infrastructure.Messaging
{
    public class SearchRequest<T> : Request<T>
    {
        public int PageIndex { get; set; } = 0;

        public int PageSize { get; set; }

        public int PagePerPages { get; set; }

        public SearchRequest()
        {

        }
        public SearchRequest(int pageSize = 10, int pagePerPages = 10)
        {
            this.PageSize = pageSize;
            this.PagePerPages = pagePerPages;
        }
    }
}
