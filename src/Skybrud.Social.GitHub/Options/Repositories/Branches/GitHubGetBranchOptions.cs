using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;

namespace Skybrud.Social.GitHub.Options.Repositories.Branches {

    /// <summary>
    /// Options for getting a single branch of a GitHub repository.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#get-a-branch</cref>
    /// </see>
    public class GitHubGetBranchOptions : GitHubHttpRequestOptions {

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
        /// Gets or sets the name of the label.
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize a new instance with default options.
        /// </summary>
        public GitHubGetBranchOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repo"/> slug and branch <paramref name="name"/>.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repo">The alias/slug of the repository.</param>
        /// <param name="name">The name of the branch.</param>
        public GitHubGetBranchOptions(string owner, string repo, string name) {
            Owner = owner;
            Repo = repo;
            Name = name;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Validate required parameters
            if (string.IsNullOrWhiteSpace(Owner)) throw new PropertyNotSetException(nameof(Owner));
            if (string.IsNullOrWhiteSpace(Repo)) throw new PropertyNotSetException(nameof(Repo));
            if (string.IsNullOrWhiteSpace(Name)) throw new PropertyNotSetException(nameof(Name));

            // Initialize the request
            return HttpRequest
                .Get($"/repos/{Owner}/{Repo}/branches/{Name}")
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}