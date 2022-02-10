using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Options.Repositories.Collaborators {

    /// <summary>
    /// Class with options for adding a new collaborator to a GitHub repository.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/collaborators#add-a-repository-collaborator</cref>
    /// </see>
    public class GitHubAddCollaboratorOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the alias of the user or organization who owns the repository.
        /// </summary>
        public string OwnerAlias { get; set; }

        /// <summary>
        /// Gets or set alias/slug of the repository.
        /// </summary>
        public string RepositoryAlias { get; set; }

        /// <summary>
        /// Gets or sets the username of the user to be added as a collaborator.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets a the permission to grant the collaborator.
        /// </summary>
        public string Permission { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubAddCollaboratorOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repositoryAlias"/> and <paramref name="username"/>.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repositoryAlias">The alias/slug of the repository.</param>
        /// <param name="username">The the username of the user to be added as a collaborator.</param>
        public GitHubAddCollaboratorOptions(string owner, string repositoryAlias, string username) {
            OwnerAlias = owner;
            RepositoryAlias = repositoryAlias;
            Username = username;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/> and <paramref name="username"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="username">The username of the user to be added as a collaborator.</param>
        public GitHubAddCollaboratorOptions(GitHubRepositoryBase repository, string username) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            OwnerAlias = repository.Owner.Login;
            RepositoryAlias = repository.Name;
            Username = username;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/> and <paramref name="user"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="user">The user to be added as a collaborator.</param>
        public GitHubAddCollaboratorOptions(GitHubRepositoryBase repository, GitHubUserBase user) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (user == null) throw new ArgumentNullException(nameof(user));
            OwnerAlias = repository.Owner.Login;
            RepositoryAlias = repository.Name;
            Username = user.Login;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            if (string.IsNullOrWhiteSpace(OwnerAlias)) throw new PropertyNotSetException(nameof(OwnerAlias));
            if (string.IsNullOrWhiteSpace(RepositoryAlias)) throw new PropertyNotSetException(nameof(RepositoryAlias));
            if (string.IsNullOrWhiteSpace(Username)) throw new PropertyNotSetException(nameof(Username));

            JObject body = new JObject();
            if (!string.IsNullOrWhiteSpace(Permission)) body.Add("permission", Permission);

            return HttpRequest
                .Put($"/repos/{OwnerAlias}/{RepositoryAlias}/collaborators/{Username}", body)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}