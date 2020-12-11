using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.GitHub.Http;

namespace Skybrud.Social.GitHub.Options.Issues {

    /// <summary>
    /// Options for getting a single GitHub issue.
    /// </summary>
    public class GitHubGetIssueOptions : GitHubHttpOptionsBase, IHttpRequestOptions {

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
        /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="number">The number of the issue.</param>
        public GitHubGetIssueOptions(string owner, string repository, int number) {
            Owner = owner;
            Repository = repository;
            Number = number;
        }

        #endregion

        #region Memberm mehtods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            if (string.IsNullOrWhiteSpace(Owner)) throw new PropertyNotSetException(nameof(Owner));
            if (string.IsNullOrWhiteSpace(Repository)) throw new PropertyNotSetException(nameof(Repository));
            if (Number == 0) throw new PropertyNotSetException(nameof(Number));

            return HttpRequest
                .Get($"/repos/{Owner}/{Repository}/issues/{Number}")
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}