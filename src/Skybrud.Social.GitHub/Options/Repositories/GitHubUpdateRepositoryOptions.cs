using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;

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

    #endregion

}