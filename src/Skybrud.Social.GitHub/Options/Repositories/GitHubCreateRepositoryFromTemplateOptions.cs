using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;

namespace Skybrud.Social.GitHub.Options.Repositories {
    
    /// <summary>
    /// Options for a request to create a new repository using an existing repository as template.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/#create-repository-using-a-repository-template</cref>
    /// </see>
    public class GitHubCreateRepositoryFromTemplateOptions : IHttpRequestOptions {

        #region Properties

        public string TemplateOwner { get; set; }

        public string TemplateRepository { get; set; }

        /// <summary>
        /// Gets or sets the organization or person who will own the new repository. To create a new repository in an organization, the authenticated user must be a member of the specified organization.
        /// </summary>
        public string Owner { get; set; }

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

        #endregion

        #region Constructors

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a new <see cref="IHttpRequest"/> instance for this options instance.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpRequest"/>.</returns>
        public IHttpRequest GetRequest() {

            if (string.IsNullOrWhiteSpace(TemplateOwner)) throw new PropertyNotSetException(nameof(TemplateOwner));
            if (string.IsNullOrWhiteSpace(TemplateRepository)) throw new PropertyNotSetException(nameof(TemplateRepository));
            if (string.IsNullOrWhiteSpace(Owner)) throw new PropertyNotSetException(nameof(Owner));
            if (string.IsNullOrWhiteSpace(Name)) throw new PropertyNotSetException(nameof(Name));

            // Initialize the request body
            JObject body = new JObject {
                {"owner", Owner},
                {"name", Name},
                {"description", Description ?? string.Empty},
                {"private", IsPrivate}
            };

            // Initialize a new request
            HttpRequest request = HttpRequest.Post($"/repos/{TemplateOwner}/{TemplateRepository}/generate", body);

            // Make sure we can access the preview feature
            request.Accept = "application/vnd.github.baptiste-preview+json";

            return request;

        }

        #endregion

    }

}