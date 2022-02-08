using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Options.Repositories.References {

    /// <summary>
    /// Class with options for creating a new Git reference.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/git#create-a-reference</cref>
    /// </see>
    public class GitHubCreateReferenceOptions : GitHubHttpRequestOptions {

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
        /// Gets or sets the name of the fully qualified reference (ie: <c>refs/heads/master</c>). If it doesn't start
        /// with 'refs' and have at least two slashes, it will be rejected.
        /// </summary>
        public string Ref { get; set; }

        /// <summary>
        /// Gets or sets the SHA1 value for this reference.
        /// </summary>
        public string Sha { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubCreateReferenceOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repositoryAlias"/>,
        /// <paramref name="ref"/> and <paramref name="sha"/>.
        /// </summary>
        /// <param name="owner">The alias of the user or organization who own the repository.</param>
        /// <param name="repositoryAlias">The alias/slug of the repository.</param>
        /// <param name="ref">The name of the fully qualified reference (ie: <c>refs/heads/master</c>). If it doesn't start with 'refs' and have at least two slashes, it will be rejected.</param>
        /// <param name="sha">The SHA1 value for this reference.</param>
        public GitHubCreateReferenceOptions(string owner, string repositoryAlias, string @ref, string sha) {
            OwnerAlias = owner;
            RepositoryAlias = repositoryAlias;
            Ref = @ref;
            Sha = sha;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public GitHubCreateReferenceOptions(GitHubRepositoryBase repository) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            OwnerAlias = repository.Owner.Login;
            RepositoryAlias = repository.Name;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/>, <paramref name="ref"/> and
        /// <paramref name="sha"/>.
        /// </summary>
        /// <param name="repository">The the repository.</param>
        /// <param name="ref">The name of the fully qualified reference (ie: <c>refs/heads/master</c>). If it doesn't start with 'refs' and have at least two slashes, it will be rejected.</param>
        /// <param name="sha">The SHA1 value for this reference.</param>
        public GitHubCreateReferenceOptions(GitHubRepositoryBase repository, string @ref, string sha) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            OwnerAlias = repository.Owner.Login;
            RepositoryAlias = repository.Name;
            Ref = @ref;
            Sha = sha;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Input validation
            if (string.IsNullOrWhiteSpace(OwnerAlias)) throw new PropertyNotSetException(nameof(OwnerAlias));
            if (string.IsNullOrWhiteSpace(RepositoryAlias)) throw new PropertyNotSetException(nameof(RepositoryAlias));
            if (string.IsNullOrWhiteSpace(Ref)) throw new PropertyNotSetException(nameof(Ref));
            if (string.IsNullOrWhiteSpace(Sha)) throw new PropertyNotSetException(nameof(Sha));

            // Initialize the request body
            JObject body = new JObject {
                {"ref", Ref},
                {"sha", Sha}
            };

            // Initialize a new POST request
            return HttpRequest
                .Post($"/repos/{OwnerAlias}/{RepositoryAlias}/git/refs", body)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}