namespace SpecFlowReqRes.Specs.Support
{
    public partial class UserList
    {
        [JsonPropertyName("page")]
        public long Page { get; set; }

        [JsonPropertyName("per_page")]
        public long PerPage { get; set; }

        [JsonPropertyName("total")]
        public long Total { get; set; }

        [JsonPropertyName("total_pages")]
        public long TotalPages { get; set; }

        [JsonPropertyName("data")]
        public List<Datum> Data { get; set; }

        [JsonPropertyName("support")]
        public Support Support { get; set; }
    }

    public partial class Datum
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("avatar")]
        public Uri Avatar { get; set; }
    }
}
