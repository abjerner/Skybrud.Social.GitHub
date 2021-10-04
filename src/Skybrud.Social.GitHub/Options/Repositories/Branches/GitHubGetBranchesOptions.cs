using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models;

namespace Skybrud.Social.GitHub.Options.Repositories.Branches {

    /// <summary>
    /// Options for getting the branches of a GitHub repository.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#list-branches</cref>
    /// </see>
    public class GitHubGetBranchesOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the alias of the owner.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Gets or sets the alias/slug of the repository.
        /// </summary>
        public string Repo { get; set; }

        /// <summary>
        /// Setting to <see cref="GitHubBoolean.True"/> returns only protected branches. When set to
        /// <see cref="GitHubBoolean.False"/>, only unprotected branches are returned. Omitting this parameter (aka
        /// <see cref="GitHubBoolean.Unspecified"/>) returns all branches.
        /// </summary>
        public GitHubBoolean Protected { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of labels to returned by each page. Maximum is <c>100</c>.
        /// </summary>
        public int PerPage { get; set; }

        /// <summary>
        /// Gets or sets the page to be returned.
        /// </summary>
        public int Page { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize a new instance with default options.
        /// </summary>
        public GitHubGetBranchesOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repo"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repo">The alias/slug of the repository.</param>
        public GitHubGetBranchesOptions(string owner, string repo) {
            Owner = owner;
            Repo = repo;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repo"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repo">The alias/slug of the repository.</param>
        /// <param name="perPage">The maximum amount of branches to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        public GitHubGetBranchesOptions(string owner, string repo, int perPage, int page) {
            Owner = owner;
            Repo = repo;
            PerPage = perPage;
            Page = page;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {
            
            // Validate required parameters
            if (string.IsNullOrWhiteSpace(Owner)) throw new PropertyNotSetException(nameof(Owner));
            if (string.IsNullOrWhiteSpace(Repo)) throw new PropertyNotSetException(nameof(Repo));
            
            // Initialize and construct the query string
            IHttpQueryString query = new HttpQueryString();
            if (Protected != GitHubBoolean.Unspecified) query.Add("protected", Protected.ToLower());
            if (PerPage > 0) query.Add("per_page", PerPage);
            if (Page > 0) query.Add("page", Page);
            
            // Initialize the request
            return HttpRequest
                .Get($"/repos/{Owner}/{Repo}/branches", query)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}