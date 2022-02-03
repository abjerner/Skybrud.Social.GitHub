using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Options.Repositories.Labels {

    /// <summary>
    /// Options for getting the labels of a GitHub repository.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/issues#list-labels-for-a-repository</cref>
    /// </see>
    public class GitHubGetLabelsOptions : GitHubHttpRequestOptions {

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
        public GitHubGetLabelsOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repo"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repo">The alias/slug of the repository.</param>
        public GitHubGetLabelsOptions(string owner, string repo) {
            Owner = owner;
            Repo = repo;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repo"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repo">The alias/slug of the repository.</param>
        /// <param name="perPage">The maximum amount of labels to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        public GitHubGetLabelsOptions(string owner, string repo, int perPage, int page) {
            Owner = owner;
            Repo = repo;
            PerPage = perPage;
            Page = page;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public GitHubGetLabelsOptions(GitHubRepositoryItem repository) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            Owner = repository.Owner.Login;
            Repo = repository.Name;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="perPage">The maximum amount of labels to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        public GitHubGetLabelsOptions(GitHubRepositoryItem repository, int perPage, int page) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            Owner = repository.Owner.Login;
            Repo = repository.Name;
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
            if (PerPage > 0) query.Add("per_page", PerPage);
            if (Page > 0) query.Add("page", Page);

            // Initialize the request
            return HttpRequest
                .Get($"/repos/{Owner}/{Repo}/labels", query)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}