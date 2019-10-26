using System;
using System.Text.RegularExpressions;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Events;
using Skybrud.Social.GitHub.Models.Issues;

namespace Skybrud.Social.GitHub.Responses.Events {

    /// <summary>
    /// Class representing the response for getting a list of events.
    /// </summary>
    public class GitHubGetEventsResponse : GitHubResponse<GitHubEventItem[]> {

        #region Properties

        /// <summary>
        /// Gets the current page number.
        /// </summary>
        public int CurrentPage { get; }

        /// <summary>
        /// Gets the total number of pages.
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        /// Gets whether the response represents the first page.
        /// </summary>
        public bool IsFirstPage => CurrentPage == 0;

        /// <summary>
        /// Gets whether the response represents the last page.
        /// </summary>
        public bool IsLastPage => CurrentPage >= TotalPages;

        #endregion

        #region Constructors

        private GitHubGetEventsResponse(IHttpResponse response) : base(response) {

            // Parse the response body
            Body = ParseJsonArray(response.Body, GitHubEventItem.Parse);
            
            // Get the "link" header from the response
            string linkHeader = response.Headers["link"];

            // Return now if the header wasn't present
            if (string.IsNullOrWhiteSpace(linkHeader)) return;

            // Set default values
            CurrentPage = 1;
            TotalPages = 1;
            
            // Match the different URLs using REGEX
            foreach (Match match in Regex.Matches(linkHeader, "\\<(.+?)\\>; rel=\"([a-z]+)\"")) {

                string url = match.Groups[1].Value;
                string rel = match.Groups[2].Value;

                // Match the page parameter from the query string
                Match m2 = Regex.Match(url, "page=([0-9]+)");

                // Skip the URL if a page number wasn't part of the URL
                if (!m2.Success) continue;
                
                // Parse the page number
                int page = int.Parse(m2.Groups[1].Value);

                switch (rel) {

                    case "next":
                        CurrentPage = page - 1;
                        break;

                    case "last":
                        TotalPages = page;
                        break;

                }

            }

            TotalPages = Math.Max(TotalPages, CurrentPage);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetEventsResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetEventsResponse"/> representing the response.</returns>
        public static GitHubGetEventsResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetEventsResponse(response);
        }

        #endregion

    }

}