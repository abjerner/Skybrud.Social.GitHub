using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Models.Search;

/// <summary>
/// Class representing an item of a code search.
/// </summary>
public class GitHubSearchCodeItem : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets the name of the file.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the path of the file.
    /// </summary>
    public string Path { get; }

    /// <summary>
    /// Gets the SHA1 hash of the file.
    /// </summary>
    public string Sha { get; }

    /// <summary>
    /// Gets the API URL of the file.
    /// </summary>
    public string Url { get; }

    /// <summary>
    /// Gets the Git URL of the file.
    /// </summary>
    public string GitUrl { get; }

    /// <summary>
    /// Gets the HTML URL of the file.
    /// </summary>
    public string HtmlUrl { get; }

    /// <summary>
    /// Gets a reference to the parent repository.
    /// </summary>
    public GitHubRepositoryItem Repository { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> representing the repository.</param>
    protected GitHubSearchCodeItem(JObject json) : base(json) {
        Name = json.GetRequiredString("name");
        Path = json.GetRequiredString("path");
        Sha = json.GetRequiredString("sha");
        Url = json.GetRequiredString("url");
        GitUrl = json.GetRequiredString("git_url");
        HtmlUrl = json.GetRequiredString("html_url");
        Repository = json.GetRequiredObject("repository", GitHubRepositoryItem.Parse);
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubSearchCodeItem"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubSearchCodeItem"/>.</returns>
    public static GitHubSearchCodeItem Parse(JObject json) {
        return new GitHubSearchCodeItem(json);
    }

    #endregion

}