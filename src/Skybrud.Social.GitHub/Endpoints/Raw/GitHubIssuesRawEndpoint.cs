using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Issues;
using Skybrud.Social.GitHub.Options.Issues.Comments;

namespace Skybrud.Social.GitHub.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw <strong>Issues</strong> endpoint.
    /// </summary>
    public class GitHubIssuesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal GitHubIssuesRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a list of issues assigned to the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetIssues() {
            return Client.DoHttpGetRequest("/issues");
        }

        /// <summary>
        /// Gets a list of issues assigned to the authenticated user.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetIssues(GitHubGetIssuesOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpGetRequest("/issues", options);
        }

        /// <summary>
        /// Gets a list of issues for the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/>.
        /// </summary>
        /// <param name="owner">The alias of the parent user or organization.</param>
        /// <param name="repository">The alias of the repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetIssues(string owner, string repository) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return Client.DoHttpGetRequest($"/repos/{owner}/{repository}/issues");
        }

        /// <summary>
        /// Gets a list of issues for the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetIssues(GitHubGetRepositoryIssuesOptions options) {
            if (string.IsNullOrWhiteSpace(options.Owner)) throw new ArgumentNullException(nameof(options.Owner));
            if (string.IsNullOrWhiteSpace(options.Repository)) throw new PropertyNotSetException(nameof(options.Repository));
            return Client.DoHttpGetRequest($"/repos/{options.Owner}/{options.Repository}/issues", options);
        }

        /// <summary>
        /// Adds a new comment to the issue matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse AddComment(GitHubAddIssueCommentOptions options) {

            if (options == null) throw new ArgumentNullException(nameof(options));
            if (string.IsNullOrWhiteSpace(options.Owner)) throw new PropertyNotSetException(nameof(options.Owner));
            if (string.IsNullOrWhiteSpace(options.Repository)) throw new PropertyNotSetException(nameof(options.Repository));
            if (options.Number == 0) throw new PropertyNotSetException(nameof(options.Number));
            if (string.IsNullOrWhiteSpace(options.Body)) throw new PropertyNotSetException(nameof(options.Body));

            // Generate the payload for the request body
            JObject body = new JObject {
                {"body", options.Body}
            };

            // Make the request to the API
            return Client.DoHttpPostRequest($"/repos/{options.Owner}/{options.Repository}/issues/{options.Number}/comments", body);

        }

        /// <summary>
        /// Gets the events of the issue matching the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="number">The number of the issue to which the comment should be added.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetEvents(string owner, string repository, int number) {
            return null;
        }

        #endregion

    }

}