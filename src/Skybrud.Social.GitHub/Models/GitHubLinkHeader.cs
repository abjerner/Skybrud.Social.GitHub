using System;
using System.Text.RegularExpressions;
using Skybrud.Essentials.Http;

namespace Skybrud.Social.GitHub.Models {

    /// <summary>
    /// Class representing the <c>Link</c> header of a HTTP response from the GitHub API.
    /// </summary>
    public class GitHubLinkHeader {

        #region Properties

        /// <summary>
        /// Gets the URL of the next page.
        /// </summary>
        public string Next { get; private set; }

        /// <summary>
        /// Gets the URL of the last page.
        /// </summary>
        public string Last { get; private set; }

        /// <summary>
        /// Gets the URL of the first page.
        /// </summary>
        public string First { get; private set; }

        /// <summary>
        /// Gets the URL of the previous page.
        /// </summary>
        public string Previous { get; private set; }

        /// <summary>
        /// Gets the current page number.
        /// </summary>
        public int CurrentPage { get; private set; }

        /// <summary>
        /// Gets the total amount of pages.
        /// </summary>
        public int TotalPages { get; private set; }

        #endregion

        #region Constructors

        private GitHubLinkHeader() {
            CurrentPage = 1;
            TotalPages = 1;
        }

        #endregion

        /// <summary>
        /// Parses the <c>Link</c> header from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>An instance of <see cref="GitHubLinkHeader"/>.</returns>
        public static GitHubLinkHeader Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return Parse(response.Headers["Link"]);
        }

        /// <summary>
        /// Parses the specified <c>Link</c> header <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The header value.</param>
        /// <returns>An instance of <see cref="GitHubLinkHeader"/>.</returns>
        public static GitHubLinkHeader Parse(string value) {

            // Return now if the header wasn't present
            if (String.IsNullOrWhiteSpace(value)) return null;

            // Initialize a new instance with default values
            GitHubLinkHeader link = new GitHubLinkHeader();

            // Match the different URLs using REGEX
            foreach (Match match in Regex.Matches(value, "\\<(.+?)\\>; rel=\"([a-z]+)\"")) {

                string url = match.Groups[1].Value;
                string rel = match.Groups[2].Value;

                // Match the page parameter from the query string
                Match m2 = Regex.Match(url, "page=([0-9]+)");

                // Skip the URL if a page number wasn't part of the URL
                if (!m2.Success) continue;

                // Parse the page number
                int page = Int32.Parse(m2.Groups[1].Value);

                switch (rel) {

                    case "first":
                        link.First = url;
                        break;

                    case "prev":
                        link.Previous = url;
                        link.CurrentPage = page + 1;
                        break;

                    case "next":
                        link.Next = url;
                        link.CurrentPage = page - 1;
                        break;

                    case "last":
                        link.Last = url;
                        link.TotalPages = page;
                        break;

                }

            }

            // If we're at the last page, the "last" link is not included
            link.TotalPages = Math.Max(link.TotalPages, link.CurrentPage);

            return link;

        }

    }

}