using Microsoft.Extensions.Primitives;

namespace RedCloud.Models.DataTableProcessing
{
    internal class Search
    {
        public StringValues Value { get; set; }
        public bool Regex { get; set; }
    }
}