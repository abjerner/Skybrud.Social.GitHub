using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;

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