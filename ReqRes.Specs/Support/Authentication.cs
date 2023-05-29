namespace SpecFlowReqRes.Specs.Support
{
    public partial class Authentication
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
