using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;

namespace Skybrud.Social.GitHub.Options.Users {
    
    /// <summary>
    /// Class reprensting the options for getting information about a GitHub user.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/users#get-a-user</cref>
    /// </see>
    public class GitHubGetUserOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string Username { get; set; }

        #endregion
        
        #region Constructors

        /// <summary>
        /// Initialize a new instance with default options.
        /// </summary>
        public GitHubGetUserOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public GitHubGetUserOptions(int userId) {
            UserId = userId;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        public GitHubGetUserOptions(string username) {
            Username = username;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Make sure we have either a user ID or a username
            if (UserId == 0 && string.IsNullOrWhiteSpace(Username)) throw new PropertyNotSetException(nameof(Username));

            // Construct the URL
            string url = string.IsNullOrWhiteSpace(Username) ? $"/user/{UserId}" : $"/users/{Username}";

            // Initialize and configure the request
            return HttpRequest
                .Get(url)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}