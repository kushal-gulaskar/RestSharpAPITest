namespace SpecFlowReqRes.Specs.StepDefinitions
{
    public class BaseStepDefinitions
    {
        protected Asserter Assert { get; } = new Asserter();

        protected static readonly string BaseUrl;
        protected static readonly string Email;
        protected static readonly string Password;

        private static readonly IConfiguration _config;

        static BaseStepDefinitions()
        {
            _config
                = new ConfigurationBuilder()
                    .AddJsonFile("env.json", optional: true)
                    .AddEnvironmentVariables().Build();

            BaseUrl = _config.GetSection("BASE_URL").Value;
            Email = _config.GetSection("EMAIL").Value;
            Password = _config.GetSection("PASSWORD").Value;
        }
    }
}
