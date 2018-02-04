﻿using System;
using Skybrud.Essentials.Time;
using Skybrud.Social.Http;

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
        public int Remaining { get; private set; }

        /// <summary>
        /// Gets the timestamp of the next rate limit timeframe.
        /// </summary>
        public EssentialsDateTime Reset { get; }

        #endregion

        #region Constructors

        private GitHubRateLimiting(SocialHttpResponse response) {
            
            int limit;
            int remaining;
            double reset;

            Int32.TryParse(response.Headers["X-RateLimit-Limit"], out limit);
            Int32.TryParse(response.Headers["X-RateLimit-Remaining"], out remaining);

            Limit = limit;
            Remaining = remaining;
            Reset = Double.TryParse(response.Headers["X-RateLimit-Reset"], out reset) ? EssentialsDateTime.FromUnixTimestamp(reset) : null;

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses rate-limiting information from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response that holds the rate-limiting information.</param>
        /// <returns>An instance of <see cref="GitHubRateLimiting"/>.</returns>
        public static GitHubRateLimiting GetFromResponse(SocialHttpResponse response) {
            return new GitHubRateLimiting(response);
        }

        #endregion

    }

}