using Skybrud.Social.GitHub.Options.Issues.Milestones;
using Skybrud.Social.GitHub.Responses.Issues.Milestones;

namespace Skybrud.Social.GitHub.Endpoints.Issues.Milestones {

    /// <summary>
    /// Class representing the <strong>Issues/Milestones</strong> endpoint.
    /// </summary>
    public class GitHubMilestonesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubMilestonesRawEndpoint Raw => Service.Client.Issues.Milestones;

        #endregion

        #region Constructors

        internal GitHubMilestonesEndpoint(GitHubService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new milestone with <paramref name="title"/> in the repository matching the specified
        /// <paramref name="owner"/> and <paramref name="repository"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="title">The title of the milestone.</param>
        /// <returns>An instance of <see cref="GitHubMilestoneResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/milestones/#create-a-milestone</cref>
        /// </see>
        public GitHubMilestoneResponse CreateMilestone(string owner, string repository, string title) {
            return new GitHubMilestoneResponse(Raw.CreateMilestone(owner, repository, title));
        }

        /// <summary>
        /// Creates a new milestone in the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubMilestoneResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/milestones/#create-a-milestone</cref>
        /// </see>
        public GitHubMilestoneResponse CreateMilestone(GitHubCreateMilestoneOptions options) {
            return new GitHubMilestoneResponse(Raw.CreateMilestone(options));
        }

        /// <summary>
        /// Gets the milestone matching the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="number">The number of the milestone.</param>
        /// <returns>An instance of <see cref="GitHubMilestoneResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/milestones/#get-a-single-milestone</cref>
        /// </see>
        public GitHubMilestoneResponse GetMilestone(string owner, string repository, int number) {
            return new GitHubMilestoneResponse(Raw.GetMilestone(owner, repository, number));
        }

        /// <summary>
        /// Gets the milestone matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubMilestoneResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/milestones/#get-a-single-milestone</cref>
        /// </see>
        public GitHubMilestoneResponse GetMilestone(GitHubGetMilestoneOptions options) {
            return new GitHubMilestoneResponse(Raw.GetMilestone(options));
        }

        /// <summary>
        /// Gets the milestones of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubMilestoneListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/milestones/#list-milestones-for-a-repository</cref>
        /// </see>
        public GitHubMilestoneListResponse GetMilestones(GitHubGetMilestonesOptions options) {
            return new GitHubMilestoneListResponse(Raw.GetMilestones(options));
        }

        #endregion

    }

}