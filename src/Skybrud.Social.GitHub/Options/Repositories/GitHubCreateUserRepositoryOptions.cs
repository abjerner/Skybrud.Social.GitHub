using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;

namespace Skybrud.Social.GitHub.Options.Repositories {

    /// <summary>
    /// Options for a request to create a new repository belonging to the autehtnicated user.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create-repository-using-a-repository-template</cref>
    /// </see>
    public class GitHubCreateUserRepositoryOptions : GitHubHttpRequestOptions {

        #region Properties

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
        /// Gets or sets whether projects should be enabled for the repository to be created.
        /// </summary>
        public bool HasProjects { get; set; }

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
        public GitHubCreateUserRepositoryOptions() {
            HasIssues = true;
            HasProjects = true;
            HasIssues = true;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the repository.</param>
        public GitHubCreateUserRepositoryOptions(string name) : this() {
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the repository.</param>
        /// <param name="isPrivate">Whether to create a new private repository.</param>
        public GitHubCreateUserRepositoryOptions(string name, bool isPrivate) : this() {
            Name = name;
            IsPrivate = isPrivate;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a new <see cref="IHttpRequest"/> instance for this options instance.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpRequest"/>.</returns>
        public override IHttpRequest GetRequest() {

            // Validate required parameters
            if (string.IsNullOrWhiteSpace(Name)) throw new PropertyNotSetException(nameof(Name));

            // Initialize the request body
            JObject body = new JObject {
                {"name", Name},
                {"description", Description ?? string.Empty},
                {"private", IsPrivate ? "true" : "false"},
                {"private", HasIssues ? "true" : "false"},
                {"has_projects", HasProjects ? "true" : "false"},
                {"has_wiki", HasWiki ? "true" : "false"}
            };

            // Append the "is_template" parameter to the request body (if true)
            if (IsTemplate) body.Add("is_template", "true");

            // Initialize the request
            return HttpRequest
                .Post("/user/repos", body)
                .SetAcceptHeader(MediaTypes);


        }

        #endregion

    }

}