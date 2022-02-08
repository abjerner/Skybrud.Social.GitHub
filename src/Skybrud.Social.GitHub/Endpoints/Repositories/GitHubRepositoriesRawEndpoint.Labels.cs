using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Options.Repositories.Labels;

namespace Skybrud.Social.GitHub.Endpoints.Repositories {

    public partial class GitHubRepositoriesRawEndpoint {

        #region CreateLabel(...)

        /// <summary>
        /// Creates a new label with <paramref name="name"/> in the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <param name="name">The name of the label.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#create-a-label</cref>
        /// </see>
        public IHttpResponse CreateLabel(string owner, string repository, string name) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return CreateLabel(new GitHubCreateLabelOptions(owner, repository, name));
        }

        /// <summary>
        /// Creates a new label with <paramref name="name"/> in the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <param name="name">The name of the label.</param>
        /// <param name="color">The the hexadecimal color code for the label, without the leading <c>#</c>.</param>
        /// <param name="description">A short description of the label.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#create-a-label</cref>
        /// </see>
        public IHttpResponse CreateLabel(string owner, string repository, string name, string color, string description) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return CreateLabel(new GitHubCreateLabelOptions(owner, repository, name, color, description));
        }

        /// <summary>
        /// Creates a new label with <paramref name="name"/> in the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="name">The name of the label.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#create-a-label</cref>
        /// </see>
        public IHttpResponse CreateLabel(GitHubRepositoryBase repository, string name) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return CreateLabel(new GitHubCreateLabelOptions(repository, name));
        }

        /// <summary>
        /// Creates a new label with <paramref name="name"/> in the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="name">The name of the label.</param>
        /// <param name="color">The the hexadecimal color code for the label, without the leading <c>#</c>.</param>
        /// <param name="description">A short description of the label.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#create-a-label</cref>
        /// </see>
        public IHttpResponse CreateLabel(GitHubRepositoryBase repository, string name, string color, string description) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return CreateLabel(new GitHubCreateLabelOptions(repository, name, color, description));
        }

        /// <summary>
        /// Creates a new label in the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#create-a-label</cref>
        /// </see>
        public IHttpResponse CreateLabel(GitHubCreateLabelOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

        #region GetLabel(...)

        /// <summary>
        /// Returns a label matching the specified <paramref name="owner"/>, <paramref name="repository"/> slug and label <paramref name="name"/>.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <param name="name">The name of the label.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#get-a-label</cref>
        /// </see>
        public IHttpResponse GetLabel(string owner, string repository, string name) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return GetLabel(new GitHubGetLabelOptions(owner, repository, name));
        }

        /// <summary>
        /// Returns a label matching the specified <paramref name="repository"/> and label <paramref name="name"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="name">The name of the label.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#get-a-label</cref>
        /// </see>
        public IHttpResponse GetLabel(GitHubRepositoryBase repository, string name) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return GetLabel(new GitHubGetLabelOptions(repository, name));
        }

        /// <summary>
        /// Returns a label matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#get-a-label</cref>
        /// </see>
        public IHttpResponse GetLabel(GitHubGetLabelOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

        #region UpdateLabel(...)

        /// <summary>
        /// Updates the label with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#update-a-label</cref>
        /// </see>
        public IHttpResponse UpdateLabel(GitHubUpdateLabelOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

        #region GetLabels(...)

        /// <summary>
        /// Returns a list of labels of the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#list-labels-for-a-repository</cref>
        /// </see>
        public IHttpResponse GetLabels(string owner, string repository) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return GetLabels(new GitHubGetLabelsOptions(owner, repository));
        }

        /// <summary>
        /// Returns a list of labels of the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <param name="perPage">The maximum amount of labels to returned by each page. Maximum is <c>100</c>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#list-labels-for-a-repository</cref>
        /// </see>
        public IHttpResponse GetLabels(string owner, string repository, int perPage) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return GetLabels(new GitHubGetLabelsOptions(owner, repository, perPage, default));
        }

        /// <summary>
        /// Returns a list of labels of the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <param name="perPage">The maximum amount of labels to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#list-labels-for-a-repository</cref>
        /// </see>
        public IHttpResponse GetLabels(string owner, string repository, int perPage, int page) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return GetLabels(new GitHubGetLabelsOptions(owner, repository, perPage, page));
        }

        /// <summary>
        /// Returns a list of labels of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#list-labels-for-a-repository</cref>
        /// </see>
        public IHttpResponse GetLabels(GitHubRepositoryBase repository) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            return GetLabels(new GitHubGetLabelsOptions(repository));
        }

        /// <summary>
        /// Returns a list of labels of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="perPage">The maximum amount of labels to returned by each page. Maximum is <c>100</c>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#list-labels-for-a-repository</cref>
        /// </see>
        public IHttpResponse GetLabels(GitHubRepositoryBase repository, int perPage) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            return GetLabels(new GitHubGetLabelsOptions(repository, perPage, default));
        }

        /// <summary>
        /// Returns a list of labels of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="perPage">The maximum amount of labels to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#list-labels-for-a-repository</cref>
        /// </see>
        public IHttpResponse GetLabels(GitHubRepositoryBase repository, int perPage, int page) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            return GetLabels(new GitHubGetLabelsOptions(repository, perPage, page));
        }

        /// <summary>
        /// Returns a list of labels of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#list-labels-for-a-repository</cref>
        /// </see>
        public IHttpResponse GetLabels(GitHubGetLabelsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}