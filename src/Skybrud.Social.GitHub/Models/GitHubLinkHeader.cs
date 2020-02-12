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
        /// Gets number of the next page.
        /// </summary>
        public int Next { get; }

        /// <summary>
        /// Gets the URL of the next page.
        /// </summary>
        public string NextUrl { get; }

        /// <summary>
        /// Gets whether the list has a next page.
        /// </summary>
        public bool HasNextPage => Next > Current;

        /// <summary>
        /// Gets number of the last page.
        /// </summary>
        public int Last { get; }

        /// <summary>
        /// Gets the URL of the last page.
        /// </summary>
        public string LastUrl { get; }

        /// <summary>
        /// Gets number of the first page.
        /// </summary>
        public int First { get; }

        /// <summary>
        /// Gets the URL of the first page.
        /// </summary>
        public string FirstUrl { get; }

        /// <summary>
        /// Gets the number of the previous page.
        /// </summary>
        public int Previous { get; }

        /// <summary>
        /// Gets whether the list has a previous page.
        /// </summary>
        public bool HasPreviousPage => Previous > 1;

        /// <summary>
        /// Gets the URL of the previous page.
        /// </summary>
        public string PreviousUrl { get; }

        /// <summary>
        /// Gets the current page number.
        /// </summary>
        public int Current { get; }

        /// <summary>
        /// Gets the total amount of pages.
        /// </summary>
        public int TotalPages { get; }

        #endregion

        #region Constructors

        private GitHubLinkHeader(string value) {

            First = 1;
            Current = 1;
            TotalPages = 1;
            Last = 1;

            if (string.IsNullOrWhiteSpace(value)) return;

            // Match the different URLs using REGEX
            foreach (Match match in Regex.Matches(value, "\\<(.+?)\\>; rel=\"([a-z]+)\"")) {

                string url = match.Groups[1].Value;
                string rel = match.Groups[2].Value;

                // Match the page parameter from the query string
                Match m2 = Regex.Match(url, "page=([0-9]+)");

                // Skip the URL if a page number wasn't part of the URL
                if (!m2.Success) continue;

                // Parse the page number
                int page = int.Parse(m2.Groups[1].Value);

                switch (rel) {

                    case "first":
                        FirstUrl = url;
                        break;

                    case "prev":
                        Previous = page;
                        PreviousUrl = url;
                        Current = page + 1;
                        break;

                    case "next":
                        Next = page;
                        NextUrl = url;
                        Current = page - 1;
                        break;

                    case "last":
                        Last = page;
                        LastUrl = url;
                        TotalPages = page;
                        break;

                }

            }

            // If we're at the last page, the "last" link is not included
            if (TotalPages == 1) TotalPages = Math.Max(TotalPages, Current);

        }

        #endregion

        /// <summary>
        /// Parses the <c>Link</c> header from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>An instance of <see cref="GitHubLinkHeader"/>.</returns>
        public static GitHubLinkHeader Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubLinkHeader(response.Headers["Link"]);
        }

    }

}