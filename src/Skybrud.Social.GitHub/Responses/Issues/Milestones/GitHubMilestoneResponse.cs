using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Milestones;

namespace Skybrud.Social.GitHub.Responses.Issues.Milestones {
    
    /// <summary>
    /// Class representing a response with a single milestones.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/issues/milestones/#list-milestones-for-a-repository</cref>
    /// </see>
    public class GitHubMilestoneResponse : GitHubResponse<GitHubMilestone> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubMilestoneResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubMilestone.Parse);
        }

        #endregion

    }

}