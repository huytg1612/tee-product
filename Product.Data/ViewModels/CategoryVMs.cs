using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.ViewModels
{
    public class CategoryCreateVMs
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
    }
    public class CategoryUpdateVMs
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
    }

    public class CategoryFilterVMs
    {
        [JsonProperty("search")]
        public string? Search { get; set; }
        [JsonProperty("slug")]
        public string? Slug { get; set; }
    }

    public class CategorySortBy
    {
        [JsonProperty("sortField")]
        public CategorySortField SortField { get; set; } = CategorySortField.Name;
        [JsonProperty("sortDirection")]
        public SortDirection SortDirection { get; set; } = SortDirection.ASC;
    }
    public enum CategorySortField
    {
        Name, Slug
    }

    public class CategoryGeneralModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
        [JsonProperty("products")]
        public List<ProductGeneralVMs> Products { get; set; }
    }

    public class CategoryResponseList
    {
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("totalPage")]
        public int TotalPage { get; set; }
        [JsonProperty("data")]
        public List<CategoryGeneralModel> Data { get; set; }
    }

    public class ProductGeneralVMs
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("slug")]
        public string Slug { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}
