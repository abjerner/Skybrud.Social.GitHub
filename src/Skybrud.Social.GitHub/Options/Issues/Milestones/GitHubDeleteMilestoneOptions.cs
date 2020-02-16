using System;
using Newtonsoft.Json;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.GitHub.Extensions;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Milestones;

namespace Skybrud.Social.GitHub.Options.Issues.Milestones {
    
    /// <summary>
    /// Options for deleting a milestone.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/issues/milestones/#delete-a-milestone</cref>
    /// </see>
    public class GitHubDeleteMilestoneOptions : GitHubHttpOptionsBase, IHttpRequestOptions {

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
        public int Number { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubDeleteMilestoneOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="milestone"/>.
        /// </summary>
        /// <param name="milestone">The milestone to be deleted.</param>
        public GitHubDeleteMilestoneOptions(GitHubMilestone milestone) {
            if (milestone == null) throw new ArgumentNullException(nameof(milestone));
            string[] url = milestone.Url.Split('/');
            Owner = url[4];
            Repository = url[5];
            Number = milestone.Number;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/> and <paramref name="repository"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="number">The number of the milestone.</param>
        public GitHubDeleteMilestoneOptions(string owner, string repository, int number) {
            Owner = owner;
            Repository = repository;
            Number = number;
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
            if (Number == 0) throw new PropertyNotSetException(nameof(Number));

            // Make the request to the API
            return HttpRequest
                .Delete($"/repos/{Owner}/{Repository}/milestones/{Number}")
                .SetAcceptHeader(MediaTypes);

        }

        #endregion

    }

}