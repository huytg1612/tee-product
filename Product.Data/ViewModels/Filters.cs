using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.ViewModels
{
    public class Pagination
    {
        [JsonProperty("page")]
        public int Page { get; set; } = 1;
        [JsonProperty("pageSize")]
        public int PageSize { get; set; } = 5;
    }

    public enum SortDirection
    {
        ASC, DESC
    }
}
