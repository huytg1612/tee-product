using Newtonsoft.Json;

namespace Product.API.Response
{
    public class ApiResult<T>
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class PaginationResult<T>
    {
        [JsonProperty("totalPage")]
        public int TotalPage { get; set; }
        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }
        [JsonProperty("data")]
        public List<T> Data { get; set;}
    }
}
