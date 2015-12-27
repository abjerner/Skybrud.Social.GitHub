using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Endpoints.Raw {
    
    public class GitHubUsersRawEndpoint {

        #region Properties

        public GitHubOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal GitHubUsersRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        public SocialHttpResponse GetUser(string username) {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/users/" + username);
        }

        public SocialHttpResponse GetRepositories(string username) {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/users/" + username + "/repos");
        }

        public SocialHttpResponse GetOrganizations(string username) {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/users/" + username + "/orgs");
        }

        #endregion

    }

}
