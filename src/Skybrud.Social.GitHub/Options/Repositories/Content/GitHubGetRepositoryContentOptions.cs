using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Options.Repositories.Content {

    /// <summary>
    /// Class with options for getting the contents of a file in a GitHub repository.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
    /// </see>
    public class GitHubGetRepositoryContentOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the alias of the user or organization who own the repository.
        /// </summary>
        public string OwnerAlias { get; set; }

        /// <summary>
        /// Gets or set alias/slug of the repository.
        /// </summary>
        public string RepositoryAlias { get; set; }

        /// <summary>
        /// Gets or sets the path to the file or directory.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the name of the commit/branch/tag. Uses the the default branch if not specified.
        /// </summary>
        public string Ref { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubGetRepositoryContentOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public GitHubGetRepositoryContentOptions(GitHubRepositoryBase repository) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            OwnerAlias = repository.Owner.Login;
            RepositoryAlias = repository.Name;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            if (string.IsNullOrWhiteSpace(OwnerAlias)) throw new PropertyNotSetException(nameof(OwnerAlias));
            if (string.IsNullOrWhiteSpace(RepositoryAlias)) throw new PropertyNotSetException(nameof(RepositoryAlias));
            if (string.IsNullOrWhiteSpace(Path)) throw new PropertyNotSetException(nameof(Path));

            IHttpQueryString query = new HttpQueryString();
            if (!string.IsNullOrWhiteSpace(Ref)) query.Add("ref", Ref);

            return HttpRequest
                .Get($"/repos/{OwnerAlias}/{RepositoryAlias}/contents/{Path}", query)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}