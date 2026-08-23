using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Topics;

namespace Skybrud.Social.GitHub.Responses.Topics;

/// <summary>
/// Class representing the response with a list of GitHub topic names.
/// </summary>
public class GitHubTopicListResponse : GitHubResponse<GitHubTopicList> {

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The raw response the instance should be based on.</param>
    public GitHubTopicListResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonObject(response.Body, GitHubTopicList.Parse);
    }

}