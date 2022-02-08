using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Security;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Options.Repositories.Content {

    /// <summary>
    /// Class with options for creating a new file in a repository.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
    /// </see>
    public class GitHubCreateRepositoryContentOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the alias of the user or organization who own the repository.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Gets or set the alias/slug of the repository.
        /// </summary>
        public string Repository { get; set; }

        /// <summary>
        /// Gets or sets the path to the file or directory.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the commit message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the new file content, using Base64 encoding.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the name of the branch name. Uses the the default branch if not specified.
        /// </summary>
        public string Branch { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubCreateRepositoryContentOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public GitHubCreateRepositoryContentOptions(GitHubRepositoryBase repository) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            Owner = repository.Owner.Login;
            Repository = repository.Name;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Input validation
            if (string.IsNullOrWhiteSpace(Owner)) throw new PropertyNotSetException(nameof(Owner));
            if (string.IsNullOrWhiteSpace(Repository)) throw new PropertyNotSetException(nameof(Repository));
            if (string.IsNullOrWhiteSpace(Path)) throw new PropertyNotSetException(nameof(Path));
            if (string.IsNullOrWhiteSpace(Message)) throw new PropertyNotSetException(nameof(Message));
            if (string.IsNullOrWhiteSpace(Content)) throw new PropertyNotSetException(nameof(Content));

            // Initialize the request body
            JObject body = new JObject {
                {"message", Message},
                {"content", SecurityUtils.Base64Encode(Content)}
            };

            // Append any optional parameters
            if (Branch.HasValue()) body.Add("branch", Branch);

            // Initialize a new PUT request
            return HttpRequest
                .Put($"/repos/{Owner}/{Repository}/contents/{Path}", body)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}