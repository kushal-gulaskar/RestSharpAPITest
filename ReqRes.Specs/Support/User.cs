namespace SpecFlowReqRes.Specs.Support
{
    public partial class User
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("job")]
        public string Job { get; set; }
    }
}
