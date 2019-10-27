using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Issues;
using Skybrud.Social.GitHub.Models.PullRequests;

namespace Skybrud.Social.GitHub.Options.PullRequests.Reviews {

    /// <summary>
    /// Options for a request to get reviews of a given GitHub pull request.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/pulls/reviews/#list-reviews-on-a-pull-request</cref>
    /// </see>
    public class GitHubGetReviewsOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the username (login) of the owner of the repository.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Gets or sets the slug of the repository.
        /// </summary>
        public string Repository { get; set; }

        /// <summary>
        /// Gets or sets the number of the pull request.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the page to be returned. Default is <c>0</c>, indicating the first page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of reviews to be returned by each page.
        /// </summary>
        public int PerPage { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubGetReviewsOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repository"/> and
        /// <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="number">The number of the pull request.</param>
        public GitHubGetReviewsOptions(string owner, string repository, int number) {
            Owner = owner;
            Repository = repository;
            Number = number;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="issue"/>.
        /// </summary>
        /// <param name="issue">The issue for which to get comments.</param>
        public GitHubGetReviewsOptions(GitHubIssueBase issue) {
            if (issue == null) throw new ArgumentNullException(nameof(issue));
            Owner = issue.Repository.Owner.Login;
            Repository = issue.Repository.Name;
            Number = issue.Number;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="pullRequest"/>.
        /// </summary>
        /// <param name="pullRequest">The pull request for which to get comments.</param>
        public GitHubGetReviewsOptions(GitHubPullRequestBase pullRequest) {
            if (pullRequest == null) throw new ArgumentNullException(nameof(pullRequest));
            Owner = pullRequest.RepositoryOwner;
            Repository = pullRequest.RepositorySlug;
            Number = pullRequest.Number;
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

            IHttpQueryString query = new HttpQueryString();
            if (Page > 0) query.Add("page", Page);
            if (PerPage > 0) query.Add("per_page", PerPage);

            return HttpRequest.Get($"/repos/{Owner}/{Repository}/pulls/{Number}/reviews", query);

        }

        #endregion

    }

}