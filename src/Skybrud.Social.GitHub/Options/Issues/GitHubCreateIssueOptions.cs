using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Options.Issues {

    /// <summary>
    /// Class with options for creating a new issue.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/issues#create-an-issue</cref>
    /// </see>
    public class GitHubCreateIssueOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the alias of the parent user or organization.
        /// </summary>
        public string OwnerAlias { get; set; }

        /// <summary>
        /// Gets or sets the alias of the repository to which the issue will be added.
        /// </summary>
        public string RepositoryAlias { get; set; }

        /// <summary>
        /// Gets or sets the title of the issue.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the body of the issue.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the labels to be added to the issue.
        /// </summary>
        public List<string> Labels { get; set; }

        /// <summary>
        /// Gets or sets the usernames of the users the issue should be assigned to the issue.
        /// </summary>
        public List<string> Assignees { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubCreateIssueOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="owner">The alias (login) of the owner.</param>
        /// <param name="repositoryAlias">The slug of the repository.</param>
        public GitHubCreateIssueOptions(string owner, string repositoryAlias) {
            OwnerAlias = owner;
            RepositoryAlias = repositoryAlias;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repositoryAlias"/>, <paramref name="title"/> and <paramref name="body"/>.
        /// </summary>
        /// <param name="owner">The alias (login) of the owner.</param>
        /// <param name="repositoryAlias">The slug of the repository.</param>
        /// <param name="title">The title of the issue.</param>
        /// <param name="body">The body of the issue.</param>
        public GitHubCreateIssueOptions(string owner, string repositoryAlias, string title, string body) {
            OwnerAlias = owner;
            RepositoryAlias = repositoryAlias;
            Title = title;
            Body = body;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public GitHubCreateIssueOptions(GitHubRepositoryBase repository) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            OwnerAlias = repository.Owner.Login;
            RepositoryAlias = repository.Name;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/>, <paramref name="title"/> and <paramref name="body"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="title">The title of the issue.</param>
        /// <param name="body">The body of the issue.</param>
        public GitHubCreateIssueOptions(GitHubRepositoryBase repository, string title, string body) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            OwnerAlias = repository.Owner.Login;
            RepositoryAlias = repository.Name;
            Title = title;
            Body = body;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Validate required parameters
            if (string.IsNullOrWhiteSpace(Title)) throw new PropertyNotSetException(nameof(Title));

            // Construct the API URL
            string url = $"/repos/{OwnerAlias}/{RepositoryAlias}/issues";

            // Initialize the request body
            JObject body = new JObject {
                {"title", Title },
                {"body", Body ?? string.Empty }
            };

            // Append optional parameters
            if (Labels != null && Labels.Count > 0) body.Add("labels", new JArray(Labels));
            if (Assignees != null && Assignees.Count > 0) body.Add("assignees", new JArray(Assignees));

            // Initialize a new POST request
            return HttpRequest
                .Post(url, body)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}