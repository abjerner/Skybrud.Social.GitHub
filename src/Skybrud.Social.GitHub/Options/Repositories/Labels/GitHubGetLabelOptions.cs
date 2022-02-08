using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Options.Repositories.Labels {

    /// <summary>
    /// Options for getting a single label of a GitHub repository.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/issues#get-a-label</cref>
    /// </see>
    public class GitHubGetLabelOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the alias of the owner.
        /// </summary>
        public string OwnerAlias { get; set; }

        /// <summary>
        /// Gets or sets the alias/slug of the repository.
        /// </summary>
        public string RepositoryAlias { get; set; }

        /// <summary>
        /// Gets or sets the name of the label.
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize a new instance with default options.
        /// </summary>
        public GitHubGetLabelOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repositoryAlias"/> and label <paramref name="name"/>.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repositoryAlias">The alias/slug of the repository.</param>
        /// <param name="name">The name of the label.</param>
        public GitHubGetLabelOptions(string owner, string repositoryAlias, string name) {
            OwnerAlias = owner;
            RepositoryAlias = repositoryAlias;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/> and label <paramref name="name"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="name">The name of the label.</param>
        public GitHubGetLabelOptions(GitHubRepositoryBase repository, string name) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            OwnerAlias = repository.Owner.Login;
            RepositoryAlias = repository.Name;
            Name = name;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Validate required parameters
            if (string.IsNullOrWhiteSpace(OwnerAlias)) throw new PropertyNotSetException(nameof(OwnerAlias));
            if (string.IsNullOrWhiteSpace(RepositoryAlias)) throw new PropertyNotSetException(nameof(RepositoryAlias));
            if (string.IsNullOrWhiteSpace(Name)) throw new PropertyNotSetException(nameof(Name));

            // Initialize the request
            return HttpRequest
                .Get($"/repos/{OwnerAlias}/{RepositoryAlias}/labels/{Name}")
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}