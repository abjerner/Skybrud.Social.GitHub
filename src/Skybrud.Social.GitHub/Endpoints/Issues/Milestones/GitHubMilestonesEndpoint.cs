using Skybrud.Social.GitHub.Models.Milestones;
using Skybrud.Social.GitHub.Options.Issues.Milestones;
using Skybrud.Social.GitHub.Responses;
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
        public GitHubHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubMilestonesRawEndpoint Raw => Service.Client.Issues.Milestones;

        #endregion

        #region Constructors

        internal GitHubMilestonesEndpoint(GitHubHttpService service) {
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
        /// Updates the milestone with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubMilestoneResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/milestones/#update-a-milestone</cref>
        /// </see>
        public GitHubMilestoneResponse UpdateMilestone(GitHubUpdateMilestoneOptions options) {
            return new GitHubMilestoneResponse(Raw.UpdateMilestone(options));
        }

        /// <summary>
        /// Deletes the milestone matching the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="number">The number of the milestone.</param>
        /// <returns>An instance of <see cref="GitHubResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/milestones/#delete-a-milestone</cref>
        /// </see>
        public GitHubResponse DeleteMilestone(string owner, string repository, int number) {
            return new GitHubResponse(Raw.DeleteMilestone(owner, repository, number));
        }

        /// <summary>
        /// Deletes the specified <paramref name="milestone"/>.
        /// </summary>
        /// <param name="milestone">The milestone to be deleted.</param>
        /// <returns>An instance of <see cref="GitHubResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/milestones/#delete-a-milestone</cref>
        /// </see>
        public GitHubResponse DeleteMilestone(GitHubMilestone milestone) {
            return new GitHubResponse(Raw.DeleteMilestone(milestone));
        }

        /// <summary>
        /// Deletes the milestone matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/milestones/#delete-a-milestone</cref>
        /// </see>
        public GitHubResponse DeleteMilestone(GitHubDeleteMilestoneOptions options) {
            return new GitHubResponse(Raw.DeleteMilestone(options));
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