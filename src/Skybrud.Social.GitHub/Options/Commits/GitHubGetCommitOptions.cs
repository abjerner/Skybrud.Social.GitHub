using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;

namespace Skybrud.Social.GitHub.Options.Commits {

    /// <summary>
    /// Class representing the options for getting a single commit.
    /// </summary>
    public class GitHubGetCommitOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the username (login) of the owner of the repository.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Gets or sets the slug of the repository.
        /// </summary>
        public string Repository { get; set; }

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
        /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repository"/>.
        /// </summary>
        /// <param name="owner">The alias (login) of the owner.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="sha">The SHA hash of the commit.</param>
        public GitHubGetCommitOptions(string owner, string repository, string sha) {
            Owner = owner;
            Repository = repository;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Validate required parameters
            if (string.IsNullOrWhiteSpace(Owner)) throw new PropertyNotSetException(nameof(Owner));
            if (string.IsNullOrWhiteSpace(Repository)) throw new PropertyNotSetException(nameof(Repository));
            if (string.IsNullOrWhiteSpace(Sha)) throw new PropertyNotSetException(nameof(Sha));

            // Declare the URL to request
            string url = $"/repos/{Owner}/{Repository}/commits/{Sha}";

            // Initialize the request
            return HttpRequest
                .Get(url)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion



    }

}