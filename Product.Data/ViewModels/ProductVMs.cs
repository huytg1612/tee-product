using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.ViewModels
{
    public class ProductCreateVMs
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }
    }
    public class ProductUpdateVMs
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }
    }
}
