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
        public string Owner { get; set; }

        /// <summary>
        /// Gets or set alias/slug of the repository.
        /// </summary>
        public string Repository { get; set; }

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
        /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repository"/>,
        /// <paramref name="ref"/> and <paramref name="sha"/>.
        /// </summary>
        /// <param name="owner">The alias of the user or organization who own the repository.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <param name="ref">The name of the fully qualified reference (ie: <c>refs/heads/master</c>). If it doesn't start with 'refs' and have at least two slashes, it will be rejected.</param>
        /// <param name="sha">The SHA1 value for this reference.</param>
        public GitHubCreateReferenceOptions(string owner, string repository, string @ref, string sha) {
            Owner = owner;
            Repository = repository;
            Ref = @ref;
            Sha = sha;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public GitHubCreateReferenceOptions(GitHubRepositoryItem repository) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            Owner = repository.Owner.Login;
            Repository = repository.Name;
        }
        
        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="repository"/>, <paramref name="ref"/> and
        /// <paramref name="sha"/>.
        /// </summary>
        /// <param name="repository">The the repository.</param>
        /// <param name="ref">The name of the fully qualified reference (ie: <c>refs/heads/master</c>). If it doesn't start with 'refs' and have at least two slashes, it will be rejected.</param>
        /// <param name="sha">The SHA1 value for this reference.</param>
        public GitHubCreateReferenceOptions(GitHubRepositoryItem repository, string @ref, string sha) { 
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            Owner = repository.Owner.Login;
            Repository = repository.Name;
            Ref = @ref;
            Sha = sha;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            // Input validation
            if (string.IsNullOrWhiteSpace(Owner)) throw new PropertyNotSetException(nameof(Owner));
            if (string.IsNullOrWhiteSpace(Repository)) throw new PropertyNotSetException(nameof(Repository));
            if (string.IsNullOrWhiteSpace(Ref)) throw new PropertyNotSetException(nameof(Ref));
            if (string.IsNullOrWhiteSpace(Sha)) throw new PropertyNotSetException(nameof(Sha));

            // Initialize the request body
            JObject body = new JObject {
                {"ref", Ref},
                {"sha", Sha}
            };

            // Initialize a new POST request
            return HttpRequest
                .Post($"/repos/{Owner}/{Repository}/git/refs", body)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}