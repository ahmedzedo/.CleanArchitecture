using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureSample.Infrastructure.Messaging
{
    public class SearchResponse<T> : Response<T>
    {
        public int PageIndex { get; set; }

        public int TotalItemsCount { get; set; } = 0;
    }
}
