using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Tags; 

/// <summary>
/// Class describing a GitHub tag.
/// </summary>
public class GitHubTagItem : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets the name of the tag.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the zipball URL of the tag.
    /// </summary>
    public string ZipballUrl { get; }

    /// <summary>
    /// Gets the tarball URL of the tag.
    /// </summary>
    public string TarballUrl { get; }

    /// <summary>
    /// Gets a reference to the commit the tag is based on.
    /// </summary>
    public GitHubTagCommit Commit { get; }

    /// <summary>
    /// Gets the node ID of the tag.
    /// </summary>
    public string NodeId { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> representing the tag.</param>
    protected GitHubTagItem(JObject json) : base(json) {
        Name = json.GetRequiredString("name");
        ZipballUrl = json.GetRequiredString("zipball_url");
        TarballUrl = json.GetRequiredString("tarball_url");
        Commit = json.GetRequiredObject("commit", GitHubTagCommit.Parse);
        NodeId = json.GetRequiredString("node_id");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> into an instance of <see cref="GitHubTagItem"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubTagItem"/>.</returns>
    public static GitHubTagItem Parse(JObject json) {
        return new GitHubTagItem(json);
    }

    #endregion

}