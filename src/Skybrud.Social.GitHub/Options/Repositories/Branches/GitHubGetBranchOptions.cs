using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

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
        public string Repository { get; set; }

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
        /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repository"/> slug and branch <paramref name="name"/>.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <param name="name">The name of the branch.</param>
        public GitHubGetBranchOptions(string owner, string repository, string name) {
            Owner = owner;
            Repository = repository;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/> and branch <paramref name="name"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="name">The name of the branch.</param>
        public GitHubGetBranchOptions(GitHubRepositoryBase repository, string name) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            Owner = repository.Owner.Login;
            Repository = repository.Name;
            Name = name;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Validate required parameters
            if (string.IsNullOrWhiteSpace(Owner)) throw new PropertyNotSetException(nameof(Owner));
            if (string.IsNullOrWhiteSpace(Repository)) throw new PropertyNotSetException(nameof(Repository));
            if (string.IsNullOrWhiteSpace(Name)) throw new PropertyNotSetException(nameof(Name));

            // Initialize the request
            return HttpRequest
                .Get($"/repos/{Owner}/{Repository}/branches/{Name}")
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}