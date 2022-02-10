using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Options.Issues {

    /// <summary>
    /// Options for getting a single GitHub issue.
    /// </summary>
    public class GitHubGetIssueOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the username (login) of the owner of the repository.
        /// </summary>
        public string OwnerAlias { get; set; }

        /// <summary>
        /// Gets or sets the slug of the repository.
        /// </summary>
        public string RepositoryAlias { get; set; }

        /// <summary>
        /// Gets or sets the number of the issue.
        /// </summary>
        public int Number { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubGetIssueOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repositoryAlias"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repositoryAlias">The slug of the repository.</param>
        /// <param name="number">The number of the issue.</param>
        public GitHubGetIssueOptions(string owner, string repositoryAlias, int number) {
            OwnerAlias = owner;
            RepositoryAlias = repositoryAlias;
            Number = number;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="number">The number of the issue.</param>
        public GitHubGetIssueOptions(GitHubRepositoryBase repository, int number) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            OwnerAlias = repository.Owner.Login;
            RepositoryAlias = repository.Name;
            Number = number;
        }

        #endregion

        #region Memberm mehtods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {
            
            // Validate required parameters
            if (string.IsNullOrWhiteSpace(OwnerAlias)) throw new PropertyNotSetException(nameof(OwnerAlias));
            if (string.IsNullOrWhiteSpace(RepositoryAlias)) throw new PropertyNotSetException(nameof(RepositoryAlias));
            if (Number == 0) throw new PropertyNotSetException(nameof(Number));
            
            // Initialize a new GET request
            return HttpRequest
                .Get($"/repos/{OwnerAlias}/{RepositoryAlias}/issues/{Number}")
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}