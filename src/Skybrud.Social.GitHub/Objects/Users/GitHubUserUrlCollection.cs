using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Objects.Users {

    /// <summary>
    /// Class representing a collection of URLs related to a GitHub user.
    /// </summary>
    public class GitHubUserUrlCollection {

        #region Properties

        /// <summary>
        /// Gets the API URL of the user.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Gets the website URL of the user.
        /// </summary>
        public string HtmlUrl { get; private set; }

        /// <summary>
        /// Gets the API URL for getting a list of followers of the user.
        /// </summary>
        public string FollowersUrl { get; private set; }

        /// <summary>
        /// Gets the API URL for getting a list of other users the user is following.
        /// </summary>
        public string FollowingUrl { get; private set; }

        /// <summary>
        /// Gets the API URL for getting a list of gists of the user.
        /// </summary>
        public string GistsUrl { get; private set; }

        /// <summary>
        /// Gets the API URL for getting a list of repositories the user has starred.
        /// </summary>
        public string StarredUrl { get; private set; }

        /// <summary>
        /// Gets the API URL for getting a list of repositories to which the user has subscribed.
        /// </summary>
        public string SubscriptionsUrl { get; private set; }

        /// <summary>
        /// Gets the API URL for getting a list of organisation of which the user is a member.
        /// </summary>
        public string OrganizationsUrl { get; private set; }

        /// <summary>
        /// Gets the API URL for getting a list of repositories of the user.
        /// </summary>
        public string ReposUrl { get; private set; }

        /// <summary>
        /// Gets the API URL for getting a list of events made by the user.
        /// </summary>
        public string EventsUrl { get; private set; }

        /// <summary>
        /// Gets the API URL for getting a list of events of repositories to which the user has subscribed.
        /// </summary>
        public string ReceivedEventsUrl { get; private set; }

        #endregion

        #region Constructor

        private GitHubUserUrlCollection(JObject obj) {
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
        /// Parses the specified <code>obj</code> into an instance of <code>GitHubUserUrlCollection</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>GitHubUserUrlCollection</code>.</returns>
        public static GitHubUserUrlCollection Parse(JObject obj) {
            return obj == null ? null : new GitHubUserUrlCollection(obj);
        }

        #endregion

    }

}