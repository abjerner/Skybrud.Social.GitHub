using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Options.Commits {

    /// <summary>
    /// Class representing the options for getting a list of commits of a given repository.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/commits/#list-commits-on-a-repository</cref>
    /// </see>
    public class GitHubGetCommitsOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Mandatory: Gets or sets the username (login) of the owner of the repository.
        /// </summary>
        public string OwnerAlias { get; set; }

        /// <summary>
        /// Mandatory: Gets or sets the slug of the repository.
        /// </summary>
        public string RepositoryAlias { get; set; }

        /// <summary>
        /// Optional: Gets or sets the SHA or branch to start listing commits from.
        /// </summary>
        public string Sha { get; set; }

        /// <summary>
        /// Optional: Gets or sets the path of the request. Only commits containing this file path will be returned.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Optional: Gets or sets the GitHub login or email address by which to filter by commit author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Optional: Gets or sets the timestamp the returned commits should match. Only commits after this date will
        /// be returned.
        /// </summary>
        public EssentialsTime Since { get; set; }

        /// <summary>
        /// Optional: Gets or sets the timestamp the returned commits should match. Only commits before this date will
        /// be returned.
        /// </summary>
        public EssentialsTime Until { get; set; }

        /// <summary>
        /// Gets or sets the page to be returned.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of commits to be returned by each page. Maximum allowed value is <c>100</c>.
        /// </summary>
        public int PerPage { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubGetCommitsOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="owner">The alias (login) of the owner.</param>
        /// <param name="repositoryAlias">The slug of the repository.</param>
        public GitHubGetCommitsOptions(string owner, string repositoryAlias) {
            OwnerAlias = owner;
            RepositoryAlias = repositoryAlias;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public GitHubGetCommitsOptions(GitHubRepositoryBase repository) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            OwnerAlias = repository.Owner.Login;
            RepositoryAlias = repository.Name;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Validate required parameters
            if (string.IsNullOrWhiteSpace(OwnerAlias)) throw new PropertyNotSetException(nameof(OwnerAlias));
            if (string.IsNullOrWhiteSpace(RepositoryAlias)) throw new PropertyNotSetException(nameof(RepositoryAlias));

            // Initialize and construct the query string
            IHttpQueryString query = new HttpQueryString();
            if (!string.IsNullOrWhiteSpace(Sha)) query.Add("sha", Sha);
            if (!string.IsNullOrWhiteSpace(Path)) query.Add("path", Path);
            if (!string.IsNullOrWhiteSpace(Author)) query.Add("author", Author);
            if (Since != null) query.Add("since", Since.Iso8601);
            if (Until != null) query.Add("until", Until.Iso8601);
            if (Page > 0) query.Add("page", Page);
            if (PerPage > 0) query.Add("per_page", PerPage);

            // Declare the URL to request
            string url = $"/repos/{OwnerAlias}/{RepositoryAlias}/commits";

            // Initialize the request
            return HttpRequest
                .Get(url, query)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}