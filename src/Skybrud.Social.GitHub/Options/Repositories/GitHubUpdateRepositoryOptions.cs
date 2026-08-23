using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Reflection;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Responses.Repositories;

namespace Skybrud.Social.GitHub.Options.Repositories;

/// <summary>
/// Options describing a request to update a GitHub repository.
/// </summary>
public class GitHubUpdateRepositoryOptions : GitHubHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the alias of the repository owner.
    /// </summary>
    [JsonIgnore]
#if NET8_0_OR_GREATER
    public required string OwnerAlias { get; set; }
#else
    public string? OwnerAlias { get; set; }
#endif

    /// <summary>
    /// Gets or sets the alias of the repository.
    /// </summary>
    [JsonIgnore]
#if NET8_0_OR_GREATER
    public required string RepositoryAlias { get; set; }
#else
    public string? RepositoryAlias { get; set; }
#endif

    /// <summary>
    /// Gets or sets the name of the repository.
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public GitHubPatchValue<string>? Name { get; set; }

    /// <summary>
    /// Gets or sets a short description of the repository.
    /// </summary>
    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public GitHubPatchValue<string?>? Description { get; set; }

    /// <summary>
    /// Gets or sets a URL with more information about the repository.
    /// </summary>
    [JsonProperty("homepage", NullValueHandling = NullValueHandling.Ignore)]
    public GitHubPatchValue<string?>? Homepage { get; set; }

    /// <summary>
    /// Gets or sets the default branch.
    /// </summary>
    [JsonProperty("default_branch", NullValueHandling = NullValueHandling.Ignore)]
    public GitHubPatchValue<string>? DefaultBranch { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public GitHubUpdateRepositoryOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="ownerAlias"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="ownerAlias">The alias (login) of the repository owner.</param>
    /// <param name="repositoryAlias">The alias (name/slug) of the repository.</param>
    [SetsRequiredMembers]
    public GitHubUpdateRepositoryOptions(string ownerAlias, string repositoryAlias) {
        OwnerAlias = ownerAlias;
        RepositoryAlias = repositoryAlias;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    [SetsRequiredMembers]
    public GitHubUpdateRepositoryOptions(GitHubRepositoryBase repository) {
        OwnerAlias = repository.Owner.Login;
        RepositoryAlias = repository.Name;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        // Validate required parameters
        if (string.IsNullOrWhiteSpace(OwnerAlias)) throw new PropertyNotSetException(nameof(OwnerAlias));
        if (string.IsNullOrWhiteSpace(RepositoryAlias)) throw new PropertyNotSetException(nameof(RepositoryAlias));

        // Initialize the request body
        JObject body = JObject.FromObject(this);

        // Initialize the request
        return HttpRequest
            .Patch($"/repos/{OwnerAlias}/{RepositoryAlias}", body)
            .SetAcceptHeader(MediaTypes);

    }

    /// <summary>
    /// Sends the request to the GitHub API and returns the response.
    /// </summary>
    /// <param name="client">An instance of <see cref="GitHubOAuthClient"/>.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the updated repository.</returns>
    public async Task<GitHubRepositoryResponse> GetResponse(GitHubOAuthClient client) {
        return new GitHubRepositoryResponse(await client.GetResponseAsync(GetRequest()));
    }

    /// <summary>
    /// Sets the value of the property identified by the specified <paramref name="selector"/>.
    /// </summary>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="selector">A lambda expression identifying the property.</param>
    /// <param name="value">The value to set.</param>
    /// <returns>The current instance.</returns>
    public GitHubUpdateRepositoryOptions Set<TProperty>(Expression<Func<GitHubUpdateRepositoryOptions, TProperty>> selector, TProperty value) {

        PropertyInfo property = ReflectionUtils.GetPropertyInfo(selector);

        property.SetValue(this, value);

        return this;

    }

    /// <summary>
    /// Unsets the value of the property identified by the specified <paramref name="selector"/> by setting it to <c>null</c>.
    /// </summary>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="selector">A lambda expression identifying the property.</param>
    /// <returns>The current instance.</returns>
    public GitHubUpdateRepositoryOptions Unset<TProperty>(Expression<Func<GitHubUpdateRepositoryOptions, TProperty>> selector) {

        PropertyInfo property = ReflectionUtils.GetPropertyInfo(selector);

        property.SetValue(this, null);

        return this;

    }

    #endregion

    #region Static methods

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="ownerAlias"/> and <paramref name="repositoryAlias"/>.
    /// </summary>
    /// <param name="ownerAlias">The alias (login) of the repository owner.</param>
    /// <param name="repositoryAlias">The alias (name/slug) of the repository.</param>
    public static GitHubUpdateRepositoryOptions Create(string ownerAlias, string repositoryAlias) {
        return new GitHubUpdateRepositoryOptions(ownerAlias, repositoryAlias);
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="repository"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    public static GitHubUpdateRepositoryOptions Create(GitHubRepositoryBase repository) {
        return new GitHubUpdateRepositoryOptions(repository);
    }

    #endregion

}