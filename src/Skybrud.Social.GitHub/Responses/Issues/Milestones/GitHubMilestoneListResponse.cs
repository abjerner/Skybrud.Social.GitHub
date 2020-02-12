using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Milestones;

namespace Skybrud.Social.GitHub.Responses.Issues.Milestones {
    
    /// <summary>
    /// Class representing a response with a list of milestones.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/issues/milestones/#list-milestones-for-a-repository</cref>
    /// </see>
    public class GitHubMilestoneListResponse : GitHubListResponse<GitHubMilestone> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubMilestoneListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubMilestone.Parse);
        }

        #endregion

    }

}