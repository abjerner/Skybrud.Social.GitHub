using System;
using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Social.GitHub.Exceptions;
using Skybrud.Social.Http;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.GitHub.Responses {

    /// <summary>
    /// Class representing a response from the GitHub API.
    /// </summary>
    public abstract class GitHubResponse : SocialResponse {

        #region Properties

        /// <summary>
        /// Gets the total amount of calls that can be made to the API in the current timeframe.
        /// </summary>
        public int RateLimit { get; private set; }

        /// <summary>
        /// Gets the remaining amount of calls that can be made to the API in the current
        /// timeframe.
        /// </summary>
        public int RateLimitRemaining { get; private set; }

        /// <summary>
        /// Gets the timestamp of the next rate limit timeframe.
        /// </summary>
        public DateTime RateLimitReset { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        protected GitHubResponse(SocialHttpResponse response) : base(response) {
            RateLimit = Int32.Parse(response.Headers["X-RateLimit-Limit"]);
            RateLimitRemaining = Int32.Parse(response.Headers["X-RateLimit-Remaining"]);
            RateLimitReset = SocialUtils.GetDateTimeFromUnixTime(response.Headers["X-RateLimit-Reset"]);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateResponse(SocialHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            // Get the "meta" object
            JObject obj = ParseJsonObject(response.Body);

            // Now throw some exceptions
            string message = obj.GetString("message");
            string url = obj.GetString("documentation_url");
            throw new GitHubHttpException(response, message, url);

        }

        /// <summary>
        /// Parses the specified <code>json</code> string into an instance <code>JObject</code>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>Returns an instance of <code>JObject</code> parsed from the specified <code>json</code> string.</returns>
        protected static JObject ParseJsonObject(string json) {
            return SocialUtils.ParseJsonObject(json);
        }

        /// <summary>
        /// Parses the specified <code>json</code> string into an instance of <code>T</code>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <code>JObject</code> into an instance of <code>T</code>.</param>
        /// <returns>Returns an instance of <code>T</code> parsed from the specified <code>json</code> string.</returns>
        protected static T ParseJsonObject<T>(string json, Func<JObject, T> func) {
            return SocialUtils.ParseJsonObject(json, func);
        }

        /// <summary>
        /// Parses the specified <code>json</code> string into an instance of <code>JArray</code>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>Returns an instance of <code>JArray</code> parsed from the specified <code>json</code> string.</returns>
        public static JArray ParseJsonArray(string json) {
            return SocialUtils.ParseJsonArray(json);
        }

        /// <summary>
        /// Parses the specified <code>json</code> string into an array of <code>T</code>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <code>JObject</code> into an instance of <code>T</code>.</param>
        /// <returns>Returns an array of <code>T</code> parsed from the specified <code>json</code> string.</returns>
        public static T[] ParseJsonArray<T>(string json, Func<JObject, T> func) {
            return SocialUtils.ParseJsonArray(json, func);
        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the GitHub API.
    /// </summary>
    public class GitHubResponse<T> : GitHubResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        protected GitHubResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

}