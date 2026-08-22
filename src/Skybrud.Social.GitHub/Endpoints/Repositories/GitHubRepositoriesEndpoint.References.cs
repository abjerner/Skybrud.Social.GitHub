using System.Threading.Tasks;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Options.Repositories.References;
using Skybrud.Social.GitHub.Responses.Repositories.References;

namespace Skybrud.Social.GitHub.Endpoints.Repositories;

public partial class GitHubRepositoriesEndpoint {

    #region CreateReference(...)

    /// <summary>
    /// Creates a new Git reference in the repository matching the specified <paramref name="owner"/>, <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="owner">The alias of the user or organization who own the repository.</param>
    /// <param name="repositoryAlias">The alias/slug of the repository.</param>
    /// <param name="ref">The name of the fully qualified reference (ie: <c>refs/heads/master</c>). If it doesn't start with 'refs' and have at least two slashes, it will be rejected.</param>
    /// <param name="sha">The SHA1 value for this reference.</param>
    /// <returns>An instance of <see cref="GitHubReferenceResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/git#create-a-reference</cref>
    /// </see>
    public async Task<GitHubReferenceResponse> CreateReference(string owner, string repositoryAlias, string @ref, string sha) {
        return new GitHubReferenceResponse(await Raw.CreateReference(owner, repositoryAlias, @ref, sha));
    }

    /// <summary>
    /// Creates a new Git reference in the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="ref">The name of the fully qualified reference (ie: <c>refs/heads/master</c>). If it doesn't start with 'refs' and have at least two slashes, it will be rejected.</param>
    /// <param name="sha">The SHA1 value for this reference.</param>
    /// <returns>An instance of <see cref="GitHubReferenceResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/git#create-a-reference</cref>
    /// </see>
    public async Task<GitHubReferenceResponse> CreateReference(GitHubRepositoryBase repository, string @ref, string sha) {
        return new GitHubReferenceResponse(await Raw.CreateReference(repository, @ref, sha));
    }

    /// <summary>
    /// Creates a new Git reference with the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubReferenceResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/git#create-a-reference</cref>
    /// </see>
    public async Task<GitHubReferenceResponse> CreateReference(GitHubCreateReferenceOptions options) {
        return new GitHubReferenceResponse(await Raw.CreateReference(options));
    }

    #endregion

}