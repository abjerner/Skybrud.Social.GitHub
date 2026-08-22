using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Search;

/// <summary>
/// Class representing the result of a code search.
/// </summary>
public class GitHubSearchCodeResult : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets the total amount of files returned by the search.
    /// </summary>
    public int TotalCount { get; }

    /// <summary>
    /// Gets the items of the returned page.
    /// </summary>
    public IReadOnlyList<GitHubSearchCodeItem> Items { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> representing the repository.</param>
    protected GitHubSearchCodeResult(JObject json) : base(json) {
        TotalCount = json.GetRequiredInt32("total_count");
        Items = json.GetRequiredArray("items", GitHubSearchCodeItem.Parse);
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubSearchCodeResult"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubSearchCodeResult"/>.</returns>
    public static GitHubSearchCodeResult Parse(JObject json) {
        return new GitHubSearchCodeResult(json);
    }

    #endregion

}