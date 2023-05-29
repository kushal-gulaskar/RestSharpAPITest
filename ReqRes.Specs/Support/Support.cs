namespace SpecFlowReqRes.Specs.Support
{
    public partial class Support
    {
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
