using Skybrud.Social.GitHub.Options.Repositories;
using Skybrud.Social.GitHub.Options.Repositories.Branches;
using Skybrud.Social.GitHub.Options.Repositories.Labels;
using Skybrud.Social.GitHub.Responses.Branches;
using Skybrud.Social.GitHub.Responses.Labels;
using Skybrud.Social.GitHub.Responses.Repositories;

namespace Skybrud.Social.GitHub.Endpoints.Repositories {

    /// <summary>
    /// Class representing the <strong>Repositories</strong> endpoint.
    /// </summary>
    public class GitHubRepositoriesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubRepositoriesRawEndpoint Raw => Service.Client.Repositories;

        #endregion

        #region Constructors

        internal GitHubRepositoriesEndpoint(GitHubHttpService service) {
            Service = service;
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Gets information about the repository matching the specified <paramref name="owner"/> and
        /// <paramref name="repository"/>.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        public GitHubRepositoryResponse GetRepository(string owner, string repository) {
            return new GitHubRepositoryResponse(Raw.GetRepository(owner, repository));
        }

        /// <summary>
        /// Creates a new repository using a repository template.
        /// </summary>
        /// <param name="templateOwner">The alias of the organization or person who owns the template repository.</param>
        /// <param name="templateRepository">The slug of the template repository.</param>
        /// <param name="owner">The organization or person who will own the new repository.</param>
        /// <param name="name">The name of the new repository.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create-repository-using-a-repository-template</cref>
        /// </see>
        public GitHubRepositoryResponse CreateRepositoryFromTemplate(string templateOwner, string templateRepository, string owner, string name) {
            return new GitHubRepositoryResponse(Raw.CreateRepositoryFromTemplate(templateOwner, templateRepository, owner, name));
        }

        /// <summary>
        /// Creates a new repository using a repository template.
        /// </summary>
        /// <param name="templateOwner">The alias of the organization or person who owns the template repository.</param>
        /// <param name="templateRepository">The slug of the template repository.</param>
        /// <param name="owner">The organization or person who will own the new repository.</param>
        /// <param name="name">The name of the new repository.</param>
        /// <param name="isPrivate">Whether to create a new private repository.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create-repository-using-a-repository-template</cref>
        /// </see>
        public GitHubRepositoryResponse CreateRepositoryFromTemplate(string templateOwner, string templateRepository, string owner, string name, bool isPrivate) {
            return new GitHubRepositoryResponse(Raw.CreateRepositoryFromTemplate(templateOwner, templateRepository, owner, name, isPrivate));
        }

        /// <summary>
        /// Creates a new repository using a repository template.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instanceo of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create-repository-using-a-repository-template</cref>
        /// </see>
        public GitHubRepositoryResponse CreateRepositoryFromTemplate(GitHubCreateRepositoryFromTemplateOptions options) {
            return new GitHubRepositoryResponse(Raw.CreateRepositoryFromTemplate(options));
        }

        /// <summary>
        /// Creates a new repository for the authenticated user.
        /// </summary>
        /// <param name="name">The name of the repository.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create</cref>
        /// </see>
        public GitHubRepositoryResponse CreateUserRepository(string name) {
            return new GitHubRepositoryResponse(Raw.CreateUserRepository(name));
        }

        /// <summary>
        /// Creates a new repository for the authenticated user.
        /// </summary>
        /// <param name="name">The name of the repository.</param>
        /// <param name="isPrivate">Whether to create a new private repository.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create</cref>
        /// </see>
        public GitHubRepositoryResponse CreateUserRepository(string name, bool isPrivate) {
            return new GitHubRepositoryResponse(Raw.CreateUserRepository(name, isPrivate));
        }

        /// <summary>
        /// Creates a new repository for the authenticated user.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instanceo of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create</cref>
        /// </see>
        public GitHubRepositoryResponse CreateUserRepository(GitHubCreateUserRepositoryOptions options) {
            return new GitHubRepositoryResponse(Raw.CreateUserRepository(options));
        }

        /// <summary>
        /// Creates a new repository in the specified organization. The authenticated user must be a member of the organization.
        /// </summary>
        /// <param name="organisation">The organization who will own the new repository.</param>
        /// <param name="name">The name of the repository.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create</cref>
        /// </see>
        public GitHubRepositoryResponse CreateOrganisationRepository(string organisation, string name) {
            return new GitHubRepositoryResponse(Raw.CreateOrganisationRepository(organisation, name));
        }

        /// <summary>
        /// Creates a new repository in the specified organization. The authenticated user must be a member of the organization.
        /// </summary>
        /// <param name="organisation">The organization who will own the new repository.</param>
        /// <param name="name">The name of the repository.</param>
        /// <param name="isPrivate">Whether to create a new private repository.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create</cref>
        /// </see>
        public GitHubRepositoryResponse CreateOrganisationRepository(string organisation, string name, bool isPrivate) {
            return new GitHubRepositoryResponse(Raw.CreateOrganisationRepository(organisation, name, isPrivate));
        }

        /// <summary>
        /// Creates a new repository in the specified organization. The authenticated user must be a member of the organization.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instanceo of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create</cref>
        /// </see>
        public GitHubRepositoryResponse CreateOrganisationRepository(GitHubCreateOrganisationRepositoryOptions options) {
            return new GitHubRepositoryResponse(Raw.CreateOrganisationRepository(options));
        }

        /// <summary>
        /// Returns the branch matching the specified <paramref name="owner"/>, <paramref name="repo"/> slug and branch <paramref name="name"/>.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repo">The alias/slug of the repository.</param>
        /// <param name="name">The name of the branch.</param>
        /// <returns>An instance of <see cref="GitHubBranchResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-a-branch</cref>
        /// </see>
        public GitHubBranchResponse GetBranch(string owner, string repo, string name) {
            return new GitHubBranchResponse(Raw.GetBranch(owner, repo, name));
        }

        /// <summary>
        /// Returns the branch matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubBranchResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-a-branch</cref>
        /// </see>
        public GitHubBranchResponse GetBranch(GitHubGetBranchOptions options) {
            return new GitHubBranchResponse(Raw.GetBranch(options));
        }

        /// <summary>
        /// Returns a list of branches of the repository matching the specified <paramref name="owner"/> and <paramref name="repo"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repo">The alias/slug of the repository.</param>
        /// <returns>An instance of <see cref="GitHubBranchListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-branches</cref>
        /// </see>
        public GitHubBranchListResponse GetBranches(string owner, string repo) {
            return new GitHubBranchListResponse(Raw.GetBranches(owner, repo));
        }

        /// <summary>
        /// Returns a list of branches of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubBranchListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-branches</cref>
        /// </see>
        public GitHubBranchListResponse GetBranches(GitHubGetBranchesOptions options) {
            return new GitHubBranchListResponse(Raw.GetBranches(options));
        }

        /// <summary>
        /// Creates a new label with <paramref name="name"/> in the repository matching the specified <paramref name="owner"/> and <paramref name="repo"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repo">The alias/slug of the repository.</param>
        /// <param name="name">The name of the label.</param>
        /// <returns>An instance of <see cref="GitHubLabelResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#create-a-label</cref>
        /// </see>
        public GitHubLabelResponse CreateLabel(string owner, string repo, string name) {
            return new GitHubLabelResponse(Raw.CreateLabel(owner, repo, name));
        }

        /// <summary>
        /// Creates a new label with <paramref name="name"/> in the repository matching the specified <paramref name="owner"/> and <paramref name="repo"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repo">The alias/slug of the repository.</param>
        /// <param name="name">The name of the label.</param>
        /// <param name="color">The the hexadecimal color code for the label, without the leading <c>#</c>.</param>
        /// <param name="description">A short description of the label.</param>
        /// <returns>An instance of <see cref="GitHubLabelResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#create-a-label</cref>
        /// </see>
        public GitHubLabelResponse CreateLabel(string owner, string repo, string name, string color, string description) {
            return new GitHubLabelResponse(Raw.CreateLabel(owner, repo, name, color, description));
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

        /// <summary>
        /// Returns a label matching the specified <paramref name="owner"/>, <paramref name="repo"/> slug and label <paramref name="name"/>.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repo">The alias/slug of the repository.</param>
        /// <param name="name">The name of the label.</param>
        /// <returns>An instance of <see cref="GitHubLabelResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#get-a-label</cref>
        /// </see>
        public GitHubLabelResponse GetLabel(string owner, string repo, string name) {
            return new GitHubLabelResponse(Raw.GetLabel(owner, repo, name));
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

        /// <summary>
        /// Returns a list of labels of the repository matching the specified <paramref name="owner"/> and <paramref name="repo"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repo">The alias/slug of the repository.</param>
        /// <returns>An instance of <see cref="GitHubLabelListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/issues#list-labels-for-a-repository</cref>
        /// </see>
        public GitHubLabelListResponse GetLabels(string owner, string repo) {
            return new GitHubLabelListResponse(Raw.GetLabels(owner, repo));
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