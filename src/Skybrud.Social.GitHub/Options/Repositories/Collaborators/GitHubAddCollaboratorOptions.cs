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
        public string Owner { get; set; }

        /// <summary>
        /// Gets or set alias/slug of the repository.
        /// </summary>
        public string Repository { get; set; }

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

            if (string.IsNullOrWhiteSpace(Owner)) throw new PropertyNotSetException(nameof(Owner));
            if (string.IsNullOrWhiteSpace(Repository)) throw new PropertyNotSetException(nameof(Repository));
            if (string.IsNullOrWhiteSpace(Username)) throw new PropertyNotSetException(nameof(Username));

            JObject body = new JObject();
            if (!string.IsNullOrWhiteSpace(Permission)) body.Add("permission", Permission);

            return HttpRequest
                .Put($"/repos/{Owner}/{Repository}/collaborators/{Username}", body)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}