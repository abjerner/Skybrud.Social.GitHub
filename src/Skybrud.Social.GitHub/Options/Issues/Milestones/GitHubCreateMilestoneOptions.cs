using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Http;

namespace Skybrud.Social.GitHub.Options.Issues.Milestones;

/// <summary>
/// Options for a request to create a new milestone.
/// </summary>
/// <see>
///     <cref>https://developer.github.com/v3/issues/milestones/#create-a-milestone</cref>
/// </see>
public class GitHubCreateMilestoneOptions : GitHubHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the username (login) of the owner of the repository.
    /// </summary>
    [JsonIgnore]
#if NET8_0_OR_GREATER
    public required string Owner { get; set; }
#else
    public string? Owner { get; set; }
#endif

    /// <summary>
    /// Gets or sets the slug of the repository.
    /// </summary>
    [JsonIgnore]
#if NET8_0_OR_GREATER
    public required string Repository { get; set; }
#else
    public string? Repository { get; set; }
#endif

    /// <summary>
    /// Gets or sets the title of the milestone.
    /// </summary>
    [JsonProperty("title")]
#if NET8_0_OR_GREATER
    public required string Title { get; set; }
#else
    public string? Title { get; set; }
#endif

    /// <summary>
    /// Gets or sets the state of the milestone. Default is <see cref="GitHubMilestoneState.Open"/>.
    /// </summary>
    [JsonProperty("state", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public GitHubMilestoneState State { get; set; }

    /// <summary>
    /// Gets or sets the description of the milestone.
    /// </summary>
    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the due date of the milestone.
    /// </summary>
    [JsonProperty("due_on", NullValueHandling = NullValueHandling.Ignore)]
    public EssentialsTime? DueOn { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public GitHubCreateMilestoneOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repository"/>.
    /// </summary>
    /// <param name="owner">The username (login) of the owner of the repository.</param>
    /// <param name="repository">The slug of the repository.</param>
    /// <param name="title">The title of the milestone.</param>
    [SetsRequiredMembers]
    public GitHubCreateMilestoneOptions(string owner, string repository, string title) {
        Owner = owner;
        Repository = repository;
        Title = title;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns a new <see cref="IHttpRequest"/> instance for this options instance.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpRequest"/>.</returns>
    public override IHttpRequest GetRequest() {

        // Validate required parameters
        if (string.IsNullOrWhiteSpace(Owner)) throw new PropertyNotSetException(nameof(Owner));
        if (string.IsNullOrWhiteSpace(Repository)) throw new PropertyNotSetException(nameof(Repository));
        if (string.IsNullOrWhiteSpace(Title)) throw new PropertyNotSetException(nameof(Title));

        // Generate the payload for the request body
        JObject body = JObject.FromObject(this);

        // Initialize the request
        return HttpRequest
            .Post($"/repos/{Owner}/{Repository}/milestones", body)
            .SetAcceptHeader(MediaTypes);

    }

    #endregion

}