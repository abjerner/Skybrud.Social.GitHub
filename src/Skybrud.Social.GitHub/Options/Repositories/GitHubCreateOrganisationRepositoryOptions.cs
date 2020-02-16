using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.GitHub.Extensions;
using Skybrud.Social.GitHub.Http;

namespace Skybrud.Social.GitHub.Options.Repositories {
    
    /// <summary>
    /// Options for a request to create a new organisation repository.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create-repository-using-a-repository-template</cref>
    /// </see>
    public class GitHubCreateOrganisationRepositoryOptions : GitHubHttpOptionsBase, IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the organization who will own the new repository. To create a new repository in an organization, the authenticated user must be a member of the specified organization.
        /// </summary>
        public string Organisation { get; set; }

        /// <summary>
        /// Gets or sets the name of the new repository.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a short description of the new repository.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets whether to create a new private repository.
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Gets or sets whether issues should be enabled for the repository to be created.
        /// </summary>
        public bool HasIssues { get; set; }

        /// <summary>
        /// Gets or sets whether projects should be enabled for the repository to be created. Default is <c>true</c>.
        ///
        /// <strong>Note:</strong> If you're creating a repository in an organization that has disabled repository
        /// projects, the default is <c>false</c>, and if you pass <c>true</c>, the API returns an error.
        /// </summary>
        public bool? HasProjects { get; set; }

        /// <summary>
        /// Gets or sets whether a wiki should be enabled for the repository to be created.
        /// </summary>
        public bool HasWiki { get; set; }

        /// <summary>
        /// Gets or sets whether the repository to be created should be available as a template. Requires the
        /// <c>application/vnd.github.baptiste-preview+json</c> media type.
        /// </summary>
        public bool IsTemplate { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on default options.
        /// </summary>
        public GitHubCreateOrganisationRepositoryOptions() {
            HasIssues = true;
            HasIssues = true;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="name"/> and <paramref name="name"/>.
        /// </summary>
        /// <param name="organisation">The organization who will own the new repository.</param>
        /// <param name="name">The name of the repository.</param>
        public GitHubCreateOrganisationRepositoryOptions(string organisation, string name) : this() {
            Organisation = organisation;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="name"/> and <paramref name="name"/>.
        /// </summary>
        /// <param name="organisation">The organization who will own the new repository.</param>
        /// <param name="name">The name of the repository.</param>
        /// <param name="isPrivate">Whether to create a new private repository.</param>
        public GitHubCreateOrganisationRepositoryOptions(string organisation, string name, bool isPrivate) : this() {
            Organisation = organisation;
            Name = name;
            IsPrivate = isPrivate;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a new <see cref="IHttpRequest"/> instance for this options instance.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpRequest"/>.</returns>
        public IHttpRequest GetRequest() {

            if (string.IsNullOrWhiteSpace(Organisation)) throw new PropertyNotSetException(nameof(Organisation));
            if (string.IsNullOrWhiteSpace(Name)) throw new PropertyNotSetException(nameof(Name));

            // Initialize the request body
            JObject body = new JObject {
                {"name", Name},
                {"description", Description ?? string.Empty},
                {"private", IsPrivate ? "true" : "false"},
                {"private", HasIssues ? "true" : "false"},
                {"has_wiki", HasWiki ? "true" : "false"}
            };
            
            // Append the "has_project" parameter to the request body (if specified)
            if (HasProjects != null) body.Add("has_projects", HasProjects.Value ? "true" : "false");

            // Append the "is_template" parameter to the request body (if true)
            if (IsTemplate) body.Add("is_template", "true");

            // Initialize the request
            return HttpRequest
                .Post($"/orgs/{Organisation}/repos", body)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}