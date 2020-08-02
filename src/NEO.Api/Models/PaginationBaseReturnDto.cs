using System.Collections.Generic;

namespace NEO.Api.Models
{
    public class PaginationBaseDto<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int PagesTotal { get; set; }
        public long ItensTotal { get; set; }
    }
}
