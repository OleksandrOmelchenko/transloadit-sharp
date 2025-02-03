using System.Collections.Generic;

namespace Transloadit
{
    public class PaginatedList<T>
    {
        public int Count { get; set; }

        public List<T> Items { get; set; }
    }
}
