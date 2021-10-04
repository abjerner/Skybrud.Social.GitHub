using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;
using System.Collections.Generic;

namespace Skybrud.Social.GitHub.Options.Issues {
    
    /// <summary>
    /// Class with options for creating a new issue.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/issues#create-an-issue</cref>
    /// </see>
    public class GitHubCreateIssueOptions : GitHubHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the alias of the parent organization.
        /// </summary>
        public string OrganizationAlias { get; set; }

        /// <summary>
        /// Gets or sets the alias of the repository to which the issue will be added.
        /// </summary>
        public string RepositoryAlias { get; set; }

        /// <summary>
        /// Gets or sets the title of the issue.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the body of the issue.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the labels to be added to the issue.
        /// </summary>
        public List<string> Labels { get; set; }

        /// <summary>
        /// Gets or sets the usernames of the users the issue should be assigned to the issue.
        /// </summary>
        public List<string> Assignees { get; set; }

        #endregion

        #region Member methods
        
        /// <inheritdoc />
        public override IHttpRequest GetRequest() {

            if (string.IsNullOrWhiteSpace(Title)) throw new PropertyNotSetException(nameof(Title));
            
            string url = $"/repos/{OrganizationAlias}/{RepositoryAlias}/issues";

            JObject body = new JObject {
                {"title", Title },
                {"body", Body ?? string.Empty }
            };
            
            if (Labels != null && Labels.Count > 0) body.Add("labels", new JArray(Labels));
            if (Assignees != null && Assignees.Count > 0) body.Add("assignees", new JArray(Assignees));
            
            // Initialize the request
            return HttpRequest
                .Post(url, body)
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}