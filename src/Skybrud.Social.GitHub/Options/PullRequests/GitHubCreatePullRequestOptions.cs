using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Options.PullRequests {

    /// <summary>
    /// Class with options for creating a new pull request.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/pulls#create-a-pull-request</cref>
    /// </see>
    public class GitHubCreatePullRequestOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the alias of the user or organization who own the repository.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Gets or set alias/slug of the repository.
        /// </summary>
        public string Repository { get; set; }

        /// <summary>
        /// Gets or sets the title of the new pull request.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the name of the branch where your changes are implemented. For cross-repository pull requests
        /// in the same network, namespace <c>head</c> with a user like this: <c>username:branch</c>.
        /// </summary>
        public string Head { get; set; }

        /// <summary>
        /// Gets or sets the name of the branch you want the changes pulled into. This should be an existing branch on
        /// the current repository. You cannot submit a pull request to one repository that requests a merge to a base of another repository.
        /// </summary>
        public string Base { get; set; }

        /// <summary>
        /// Gets or sets the content of the pull request.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets whether maintainers can modify the pull request.
        /// </summary>
        public bool? MaintainerCanModify { get; set; }

        /// <summary>
        /// Gets or sets whether the pull request is a draft.
        /// </summary>
        public bool IsDraft { get; set; }

        /// <summary>
        /// Gets or sets the issue number of a related issue.
        /// </summary>
        public int Issue { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubCreatePullRequestOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repository"/>,
        /// <paramref name="title"/>, <paramref name="head"/>, <paramref name="base"/> and <paramref name="body"/>.
        /// </summary>
        /// <param name="owner">The alias of the user or organization who own the repository.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <param name="title">The title of the repository.</param>
        /// <param name="head">The name of the branch where your changes are implemented. For cross-repository pull
        /// requests in the same network, namespace <c>head</c> with a user like this: <c>username:branch</c>.</param>
        /// <param name="base">The name of the branch you want the changes pulled into. This should be an existing
        /// branch on the current repository. You cannot submit a pull request to one repository that requests a merge
        /// to a base of another repository.</param>
        /// <param name="body">The content of the pull request.</param>
        public GitHubCreatePullRequestOptions(string owner, string repository, string title, string head, string @base, string body) {
            Owner = owner;
            Repository = repository;
            Title = title;
            Head = head;
            Base = @base;
            Body = body;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/>, <paramref name="title"/>,
        /// <paramref name="head"/>, <paramref name="base"/> and <paramref name="body"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="title">The title of the repository.</param>
        /// <param name="head">The name of the branch where your changes are implemented. For cross-repository pull
        /// requests in the same network, namespace <c>head</c> with a user like this: <c>username:branch</c>.</param>
        /// <param name="base">The name of the branch you want the changes pulled into. This should be an existing
        /// branch on the current repository. You cannot submit a pull request to one repository that requests a merge
        /// to a base of another repository.</param>
        /// <param name="body">The content of the pull request.</param>
        public GitHubCreatePullRequestOptions(GitHubRepositoryBase repository, string title, string head, string @base, string body) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            Owner = repository.Owner.Login;
            Repository = repository.Name;
            Title = title;
            Head = head;
            Base = @base;
            Body = body;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Input validation
            if (string.IsNullOrWhiteSpace(Owner)) throw new PropertyNotSetException(nameof(Owner));
            if (string.IsNullOrWhiteSpace(Repository)) throw new PropertyNotSetException(nameof(Repository));
            if (string.IsNullOrWhiteSpace(Title)) throw new PropertyNotSetException(nameof(Title));
            if (string.IsNullOrWhiteSpace(Head)) throw new PropertyNotSetException(nameof(Head));
            if (string.IsNullOrWhiteSpace(Base)) throw new PropertyNotSetException(nameof(Base));

            // Initialize the response body
            JObject body = new JObject {
                {"title", Title},
                {"head", Head},
                {"base", Base}
            };

            // Append any optional parameters
            if (Body.HasValue()) body.Add("body", Body);
            if (MaintainerCanModify != null) body.Add("maintainer_can_modify", MaintainerCanModify.Value);
            if (IsDraft) body.Add("draft", "true");
            if (Issue > 0) body.Add("issue", Issue);

            // Initialize a new PUT request
            return HttpRequest
                .Post($"/repos/{Owner}/{Repository}/pulls", body)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}