using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Options.Repositories.Forks {

    /// <summary>
    /// Class with options for creating a new fork of a GitHub repository.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-a-fork</cref>
    /// </see>
    public class GitHubCreateForkOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the alias of the user or organization who owns the repository.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Gets or set alias/slug of the repository.
        /// </summary>
        public string Repository { get; set; }

        /// <summary>
        /// Gets or sets the alias of the organization for which the fork will be created. If not specified, the fork
        /// will be created for the authenticated user.
        /// </summary>
        public string Organization { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize a new instance with default options.
        /// </summary>
        public GitHubCreateForkOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repository"/> alias.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        public GitHubCreateForkOptions(string owner, string repository) {
            Owner = owner;
            Repository = repository;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="organization"/>.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <param name="organization">The alias of the organization for which the fork will be created.</param>
        public GitHubCreateForkOptions(string owner, string repository, string organization) {
            Owner = owner;
            Repository = repository;
            Organization = organization;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public GitHubCreateForkOptions(GitHubRepositoryBase repository) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            Owner = repository.Owner.Login;
            Repository = repository.Name;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/> and <paramref name="organization"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="organization">The alias of the organization for which the fork will be created.</param>
        public GitHubCreateForkOptions(GitHubRepositoryBase repository, string organization) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            Owner = repository.Owner.Login;
            Repository = repository.Name;
            Organization = organization;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            if (string.IsNullOrWhiteSpace(Owner)) throw new PropertyNotSetException(nameof(Owner));
            if (string.IsNullOrWhiteSpace(Repository)) throw new PropertyNotSetException(nameof(Repository));

            JObject body = new JObject();
            if (!string.IsNullOrWhiteSpace(Organization)) body.Add("organization", Organization);

            return HttpRequest
                .Post($"/repos/{Owner}/{Repository}/forks", body)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}