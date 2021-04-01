using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Users {

    /// <summary>
    /// Class representing a collection of URLs related to a GitHub user.
    /// </summary>
    public class GitHubUserUrls {

        #region Properties

        /// <summary>
        /// Gets the API URL of the user.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Gets the website URL of the user.
        /// </summary>
        public string HtmlUrl { get; }

        /// <summary>
        /// Gets the API URL for getting a list of followers of the user.
        /// </summary>
        public string FollowersUrl { get; }

        /// <summary>
        /// Gets the API URL for getting a list of other users the user is following.
        /// </summary>
        public string FollowingUrl { get; }

        /// <summary>
        /// Gets the API URL for getting a list of gists of the user.
        /// </summary>
        public string GistsUrl { get; }

        /// <summary>
        /// Gets the API URL for getting a list of repositories the user has starred.
        /// </summary>
        public string StarredUrl { get; }

        /// <summary>
        /// Gets the API URL for getting a list of repositories to which the user has subscribed.
        /// </summary>
        public string SubscriptionsUrl { get; }

        /// <summary>
        /// Gets the API URL for getting a list of organisation of which the user is a member.
        /// </summary>
        public string OrganizationsUrl { get; }

        /// <summary>
        /// Gets the API URL for getting a list of repositories of the user.
        /// </summary>
        public string ReposUrl { get; }

        /// <summary>
        /// Gets the API URL for getting a list of events made by the user.
        /// </summary>
        public string EventsUrl { get; }

        /// <summary>
        /// Gets the API URL for getting a list of events of repositories to which the user has subscribed.
        /// </summary>
        public string ReceivedEventsUrl { get; }

        #endregion

        #region Constructors

        private GitHubUserUrls(JObject obj) {
            Url = obj.GetString("url");
            HtmlUrl = obj.GetString("html_url");
            FollowersUrl = obj.GetString("followers_url");
            FollowingUrl = obj.GetString("following_url");
            GistsUrl = obj.GetString("gists_url");
            StarredUrl = obj.GetString("starred_url");
            SubscriptionsUrl = obj.GetString("subscriptions_url");
            OrganizationsUrl = obj.GetString("organizations_url");
            ReposUrl = obj.GetString("repos_url");
            EventsUrl = obj.GetString("events_url");
            ReceivedEventsUrl = obj.GetString("received_events_url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubUserUrls"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubUserUrls"/>.</returns>
        public static GitHubUserUrls Parse(JObject obj) {
            return obj == null ? null : new GitHubUserUrls(obj);
        }

        #endregion

    }

}