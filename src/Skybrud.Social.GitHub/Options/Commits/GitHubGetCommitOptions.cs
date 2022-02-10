using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Options.Commits {

    /// <summary>
    /// Class representing the options for getting a single commit.
    /// </summary>
    public class GitHubGetCommitOptions : GitHubHttpRequestOptions {

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
        /// Gets or sets the SHA of the commit.
        /// </summary>
        public string Sha { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubGetCommitOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="owner">The alias (login) of the owner.</param>
        /// <param name="repositoryAlias">The slug of the repository.</param>
        /// <param name="sha">The SHA hash of the commit.</param>
        public GitHubGetCommitOptions(string owner, string repositoryAlias, string sha) {
            OwnerAlias = owner;
            RepositoryAlias = repositoryAlias;
            Sha = sha;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="sha">The SHA hash of the commit.</param>
        public GitHubGetCommitOptions(GitHubRepositoryBase repository, string sha) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            OwnerAlias = repository.Owner.Login;
            RepositoryAlias = repository.Name;
            Sha = sha;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Validate required parameters
            if (string.IsNullOrWhiteSpace(OwnerAlias)) throw new PropertyNotSetException(nameof(OwnerAlias));
            if (string.IsNullOrWhiteSpace(RepositoryAlias)) throw new PropertyNotSetException(nameof(RepositoryAlias));
            if (string.IsNullOrWhiteSpace(Sha)) throw new PropertyNotSetException(nameof(Sha));

            // Declare the URL to request
            string url = $"/repos/{OwnerAlias}/{RepositoryAlias}/commits/{Sha}";

            // Initialize the request
            return HttpRequest
                .Get(url)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}