using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Options.Repositories.References;

namespace Skybrud.Social.GitHub.Endpoints.Repositories {

    public partial class GitHubRepositoriesRawEndpoint {

        #region CreateReference(...)

        /// <summary>
        /// Creates a new Git reference in the repository matching the specified <paramref name="owner"/>, <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="owner">The alias of the user or organization who own the repository.</param>
        /// <param name="repositoryAlias">The alias/slug of the repository.</param>
        /// <param name="ref">The name of the fully qualified reference (ie: <c>refs/heads/master</c>). If it doesn't start with 'refs' and have at least two slashes, it will be rejected.</param>
        /// <param name="sha">The SHA1 value for this reference.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/git#create-a-reference</cref>
        /// </see>
        public IHttpResponse CreateReference(string owner, string repositoryAlias, string @ref, string sha) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            if (string.IsNullOrWhiteSpace(@ref)) throw new ArgumentNullException(nameof(@ref));
            if (string.IsNullOrWhiteSpace(sha)) throw new ArgumentNullException(nameof(sha));
            return CreateReference(new GitHubCreateReferenceOptions(owner, repositoryAlias, @ref, sha));
        }

        /// <summary>
        /// Creates a new Git reference in the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="ref">The name of the fully qualified reference (ie: <c>refs/heads/master</c>). If it doesn't start with 'refs' and have at least two slashes, it will be rejected.</param>
        /// <param name="sha">The SHA1 value for this reference.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/git#create-a-reference</cref>
        /// </see>
        public IHttpResponse CreateReference(GitHubRepositoryBase repository, string @ref, string sha) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (string.IsNullOrWhiteSpace(@ref)) throw new ArgumentNullException(nameof(@ref));
            if (string.IsNullOrWhiteSpace(sha)) throw new ArgumentNullException(nameof(sha));
            return CreateReference(new GitHubCreateReferenceOptions(repository, @ref, sha));
        }

        /// <summary>
        /// Creates a new Git reference with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/git#create-a-reference</cref>
        /// </see>
        public IHttpResponse CreateReference(GitHubCreateReferenceOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}