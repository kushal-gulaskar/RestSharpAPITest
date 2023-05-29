using SpecFlowReqRes.Specs.Support;

namespace SpecFlowReqRes.Specs.StepDefinitions
{
    [Binding]
    public sealed class UsersStepDefinitions : BaseStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public UsersStepDefinitions(ScenarioContext scenarioContext)
            => _scenarioContext = scenarioContext;

        [Given(@"The list of users is requested")]
        public void GivenTheListOfUsersIsRequested()
        {
            var url = $"{BaseUrl}/api/users";
            var client = new RestClient(url);
            var request = new RestRequest();

            var totalUsers = DatabaseService.GetTotalUsers(); // Suggested ways to avoid hardcoding
            request.AddParameter("per_page", $"{totalUsers}");
            var response = client.Get(request);
            var content = response.Content;
            var userList = JsonSerializer.Deserialize<UserList>(content);

            _scenarioContext.Add("userList", userList);
        }

        [When(@"The name '(.*)' '(.*)' is searched")]
        public void WhenTheNameIsSearched(string firstName, string lastName)
        {
            var userList = _scenarioContext["userList"] as UserList;
            var isFound = userList.Data.Exists(
                e =>
                    e.FirstName.Equals(firstName)
                        && e.LastName.Equals(lastName)
            );

            _scenarioContext.Add("isFound", isFound);
            _scenarioContext.Add("firstName", firstName);
            _scenarioContext.Add("lastName", lastName);
        }

        [Then(@"The user exists")]
        public void ThenTheUserExists()
        {
            var isFound = _scenarioContext["isFound"] as bool?;
            var firstName = _scenarioContext["firstName"] as string;
            var lastName = _scenarioContext["lastName"] as string;

            Assert.IsTrue(isFound.Value, $"{firstName} {lastName} not found.");
        }

        [Given(@"A user is requested with id as '(.*)'")]
        public void GivenAUserIsRequestedWithIdAs(string id)
        {
            var url = $"{BaseUrl}/api/users";
            var client = new RestClient(url);
            var request = new RestRequest();

            request.AddParameter("id", id);
            var response = client.Get(request);

            _scenarioContext.Add("id", id);
            _scenarioContext.Add("response", response);
        }

        [Then(@"The request is not found")]
        public void ThenTheRequestIsNotFound()
        {
            var response = _scenarioContext["response"] as RestResponse;
            var statusCode = response.StatusCode;

            Assert.AreEqual(HttpStatusCode.NotFound, statusCode);
        }

        [Given(@"A user with name as '(.*)' and job as '(.*)' is requested")]
        public void GivenAUserWithNameAsAndJobAsIsRequested(string name, string job)
        {
            var url = $"{BaseUrl}/api/users";
            var client = new RestClient(url);
            var request = new RestRequest();
            var user = new User
            {
                Name = name,
                Job = job
            };

            request.AddJsonBody(user);
            var response = client.Post(request);

            _scenarioContext.Add("response", response);
        }

        [Then(@"The request is created")]
        public void ThenTheRequestIsCreated()
        {
            var response = _scenarioContext["response"] as RestResponse;
            var statusCode = response.StatusCode;

            Assert.AreEqual(HttpStatusCode.Created, statusCode);
        }
    }
}
