using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Options.Repositories.Labels;
using Skybrud.Social.GitHub.Responses.Labels;

namespace Skybrud.Social.GitHub.Endpoints.Repositories {

    public partial class GitHubRepositoriesEndpoint {

        #region CreateLabel(...)

        /// <summary>
        /// Creates a new label with <paramref name="name"/> in the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <param name="name">The name of the label.</param>
        /// <returns>An instance of <see cref="GitHubLabelResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#create-a-label</cref>
        /// </see>
        public GitHubLabelResponse CreateLabel(string owner, string repository, string name) {
            return new GitHubLabelResponse(Raw.CreateLabel(owner, repository, name));
        }

        /// <summary>
        /// Creates a new label with <paramref name="name"/> in the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <param name="name">The name of the label.</param>
        /// <param name="color">The the hexadecimal color code for the label, without the leading <c>#</c>.</param>
        /// <param name="description">A short description of the label.</param>
        /// <returns>An instance of <see cref="GitHubLabelResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#create-a-label</cref>
        /// </see>
        public GitHubLabelResponse CreateLabel(string owner, string repository, string name, string color, string description) {
            return new GitHubLabelResponse(Raw.CreateLabel(owner, repository, name, color, description));
        }

        /// <summary>
        /// Creates a new label with <paramref name="name"/> in the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="name">The name of the label.</param>
        /// <returns>An instance of <see cref="GitHubLabelResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#create-a-label</cref>
        /// </see>
        public GitHubLabelResponse CreateLabel(GitHubRepositoryBase repository, string name) {
            return new GitHubLabelResponse(Raw.CreateLabel(repository, name));
        }

        /// <summary>
        /// Creates a new label with <paramref name="name"/> in the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="name">The name of the label.</param>
        /// <param name="color">The the hexadecimal color code for the label, without the leading <c>#</c>.</param>
        /// <param name="description">A short description of the label.</param>
        /// <returns>An instance of <see cref="GitHubLabelResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#create-a-label</cref>
        /// </see>
        public GitHubLabelResponse CreateLabel(GitHubRepositoryBase repository, string name, string color, string description) {
            return new GitHubLabelResponse(Raw.CreateLabel(repository, name, color, description));
        }

        /// <summary>
        /// Creates a new label in the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubLabelResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#create-a-label</cref>
        /// </see>
        public GitHubLabelResponse CreateLabel(GitHubCreateLabelOptions options) {
            return new GitHubLabelResponse(Raw.CreateLabel(options));
        }

        #endregion

        #region GetLabel(...)

        /// <summary>
        /// Returns a label matching the specified <paramref name="owner"/>, <paramref name="repository"/> slug and label <paramref name="name"/>.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <param name="name">The name of the label.</param>
        /// <returns>An instance of <see cref="GitHubLabelResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#get-a-label</cref>
        /// </see>
        public GitHubLabelResponse GetLabel(string owner, string repository, string name) {
            return new GitHubLabelResponse(Raw.GetLabel(owner, repository, name));
        }

        /// <summary>
        /// Returns a label matching the specified <paramref name="repository"/> and label <paramref name="name"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="name">The name of the label.</param>
        /// <returns>An instance of <see cref="GitHubLabelResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#get-a-label</cref>
        /// </see>
        public GitHubLabelResponse GetLabel(GitHubRepositoryBase repository, string name) {
            return new GitHubLabelResponse(Raw.GetLabel(repository, name));
        }

        /// <summary>
        /// Returns a label matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubLabelResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#get-a-label</cref>
        /// </see>
        public GitHubLabelResponse GetLabel(GitHubGetLabelOptions options) {
            return new GitHubLabelResponse(Raw.GetLabel(options));
        }

        #endregion

        #region UpdateLabel(...)

        /// <summary>
        /// Updates the label with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubLabelResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#update-a-label</cref>
        /// </see>
        public GitHubLabelResponse UpdateLabel(GitHubUpdateLabelOptions options) {
            return new GitHubLabelResponse(Raw.UpdateLabel(options));
        }

        #endregion

        #region GetLabels(...)

        /// <summary>
        /// Returns a list of labels of the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <returns>An instance of <see cref="GitHubLabelListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#list-labels-for-a-repository</cref>
        /// </see>
        public GitHubLabelListResponse GetLabels(string owner, string repository) {
            return new GitHubLabelListResponse(Raw.GetLabels(owner, repository));
        }

        /// <summary>
        /// Returns a list of labels of the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <param name="perPage">The maximum amount of labels to returned by each page. Maximum is <c>100</c>.</param>
        /// <returns>An instance of <see cref="GitHubLabelListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#list-labels-for-a-repository</cref>
        /// </see>
        public GitHubLabelListResponse GetLabels(string owner, string repository, int perPage) {
            return new GitHubLabelListResponse(Raw.GetLabels(owner, repository, perPage));
        }

        /// <summary>
        /// Returns a list of labels of the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <param name="perPage">The maximum amount of labels to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="GitHubLabelListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#list-labels-for-a-repository</cref>
        /// </see>
        public GitHubLabelListResponse GetLabels(string owner, string repository, int perPage, int page) {
            return new GitHubLabelListResponse(Raw.GetLabels(owner, repository, perPage, page));
        }

        /// <summary>
        /// Returns a list of labels of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns>An instance of <see cref="GitHubLabelListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#list-labels-for-a-repository</cref>
        /// </see>
        public GitHubLabelListResponse GetLabels(GitHubRepositoryBase repository) {
            return new GitHubLabelListResponse(Raw.GetLabels(repository));
        }

        /// <summary>
        /// Returns a list of labels of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="perPage">The maximum amount of labels to returned by each page. Maximum is <c>100</c>.</param>
        /// <returns>An instance of <see cref="GitHubLabelListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#list-labels-for-a-repository</cref>
        /// </see>
        public GitHubLabelListResponse GetLabels(GitHubRepositoryBase repository, int perPage) {
            return new GitHubLabelListResponse(Raw.GetLabels(repository, perPage));
        }

        /// <summary>
        /// Returns a list of labels of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="perPage">The maximum amount of labels to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="GitHubLabelListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#list-labels-for-a-repository</cref>
        /// </see>
        public GitHubLabelListResponse GetLabels(GitHubRepositoryBase repository, int perPage, int page) {
            return new GitHubLabelListResponse(Raw.GetLabels(repository, perPage, page));
        }

        /// <summary>
        /// Returns a list of labels of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubLabelListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#list-labels-for-a-repository</cref>
        /// </see>
        public GitHubLabelListResponse GetLabels(GitHubGetLabelsOptions options) {
            return new GitHubLabelListResponse(Raw.GetLabels(options));
        }

        #endregion

    }

}