namespace SpecFlowReqRes.Specs.Support
{
    public class DatabaseService
    {
        // Mocks a query to the db that returns total users
        // Allows to return all users in a single payload
        // A separate endpoint that returns total users can also be used
        public static int GetTotalUsers() => 12;
    }
}
