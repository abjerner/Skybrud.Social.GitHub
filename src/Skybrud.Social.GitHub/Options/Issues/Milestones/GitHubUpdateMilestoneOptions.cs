using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Models.Milestones;

namespace Skybrud.Social.GitHub.Options.Issues.Milestones {

    /// <summary>
    /// Options for a request to update a new milestone.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/issues/milestones/#update-a-milestone</cref>
    /// </see>
    public class GitHubUpdateMilestoneOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the username (login) of the owner of the repository.
        /// </summary>
        [JsonIgnore]
        public string Owner { get; set; }

        /// <summary>
        /// Gets or sets the slug of the repository.
        /// </summary>
        [JsonIgnore]
        public string Repository { get; set; }

        /// <summary>
        /// Gets or sets the number of the milestone.
        /// </summary>
        [JsonIgnore]
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the title of the milestone.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the state of the milestone. Default is <see cref="GitHubMilestoneState.Open"/>.
        /// </summary>
        [JsonProperty("state")]
        public GitHubMilestoneState State { get; set; }

        /// <summary>
        /// Gets or sets the description of the milestone.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the due date of the milestone.
        /// </summary>
        [JsonProperty("due_on")]
        public EssentialsTime DueOn { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="milestone"/>.
        /// </summary>
        /// <param name="milestone">The milestone to be updated.</param>
        public GitHubUpdateMilestoneOptions(GitHubMilestone milestone) {
            if (milestone == null) throw new ArgumentNullException(nameof(milestone));
            string[] url = milestone.Url.Split('/');
            Owner = url[4];
            Repository = url[5];
            Number = milestone.Number;
            Title = milestone.Title;
            State = (GitHubMilestoneState) (int) milestone.State;
            Description = milestone.Description;
            DueOn = milestone.DueOn;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns a new <see cref="IHttpRequest"/> instance for this options instance.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpRequest"/>.</returns>
        public IHttpRequest GetRequest() {

            if (string.IsNullOrWhiteSpace(Owner)) throw new PropertyNotSetException(nameof(Owner));
            if (string.IsNullOrWhiteSpace(Repository)) throw new PropertyNotSetException(nameof(Repository));
            if (string.IsNullOrWhiteSpace(Title)) throw new PropertyNotSetException(nameof(Title));

            // Generate the payload for the request body
            JObject body = JObject.FromObject(this);

            // Make the request to the API
            return new HttpRequest(HttpMethod.Patch, $"/repos/{Owner}/{Repository}/milestones/{Number}", body);

        }

        #endregion

    }

}