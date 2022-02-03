using System;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.GitHub.Models.Common {

    /// <summary>
    /// Class with rate-limiting information about a response from the GitHub API.
    /// </summary>
    public class GitHubRateLimiting {

        #region Properties

        /// <summary>
        /// Gets the total amount of calls that can be made to the API in the current timeframe.
        /// </summary>
        public int Limit { get; }

        /// <summary>
        /// Gets the remaining amount of calls that can be made to the API in the current
        /// timeframe.
        /// </summary>
        public int Remaining { get; }

        /// <summary>
        /// Gets the timestamp of the next rate limit timeframe.
        /// </summary>
        public EssentialsTime Reset { get; }

        #endregion

        #region Constructors

        private GitHubRateLimiting(IHttpResponse response) {

            int.TryParse(response.Headers["X-RateLimit-Limit"], out int limit);
            int.TryParse(response.Headers["X-RateLimit-Remaining"], out int remaining);

            Limit = limit;
            Remaining = remaining;
            Reset = double.TryParse(response.Headers["X-RateLimit-Reset"], out double reset) ? EssentialsTime.FromUnixTimestamp(reset) : null;

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses rate-limiting information from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response that holds the rate-limiting information.</param>
        /// <returns>An instance of <see cref="GitHubRateLimiting"/>.</returns>
        public static GitHubRateLimiting GetFromResponse(IHttpResponse response) {
            return new GitHubRateLimiting(response);
        }

        #endregion

    }

}