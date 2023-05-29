using SpecFlowReqRes.Specs.Support;

namespace SpecFlowReqRes.Specs.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions : BaseStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public LoginStepDefinitions(ScenarioContext scenarioContext)
            => _scenarioContext = scenarioContext;

        [Given(@"The user logs in with valid email and password")]
        public void GivenTheUserLogsInWithValidEmailAndPassword()
        {
            var url = $"{BaseUrl}/api/login";
            var client = new RestClient(url);
            var request = new RestRequest();
            var authentication = new Authentication
            {
                Email = Email,
                Password = Password,
            };

            request.AddJsonBody(authentication);
            var response = client.Post(request);

            _scenarioContext.Add("response", response);
        }

        [Then(@"The request succeeds")]
        public void ThenTheRequestSucceeds()
        {
            var response = _scenarioContext["response"] as RestResponse;
            var statusCode = response.StatusCode;

            Assert.AreEqual(HttpStatusCode.OK, statusCode);
        }

        [Given(@"The user logs in with missing password")]
        public void GivenTheUserLogsInWithMissingPassword()
        {
            var url = $"{BaseUrl}/api/login";
            var client = new RestClient(url);
            var request = new RestRequest();
            var authentication = new Authentication
            {
                Email = Email,
            };

            request.AddJsonBody(authentication);

            _scenarioContext.Add("client", client);
            _scenarioContext.Add("request", request);
        }

        [Then(@"The request fails")]
        public void ThenTheRequestFails()
        {
            var client = _scenarioContext["client"] as RestClient;
            var request = _scenarioContext["request"] as RestRequest;

            Assert.Throws<HttpRequestException>(() => client.Post(request));
        }
    }
}
