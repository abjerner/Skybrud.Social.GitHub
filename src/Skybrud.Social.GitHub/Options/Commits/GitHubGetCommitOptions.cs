using System;
using Skybrud.Essentials.Time;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.GitHub.Options.Commits {
    
    /// <summary>
    /// Class representing the options for getting a list of commits of a given repository.
    /// </summary>
    public class GitHubGetCommitOptions: IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Mandatory: Gets or sets the username (login) of the owner of the repository.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Mandatory: Gets or sets the slug of the repository.
        /// </summary>
        public string Repository { get; set; }

        /// <summary>
        /// Optional: Gets or sets the SHA or branch to start listing commits from.
        /// </summary>
        public string Sha { get; set; }

        /// <summary>
        /// Optional: Gets or sets the path of the request. Only commits containing this file path will be returned.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Optional: Gets or sets the GitHub login or email address by which to filter by commit author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Optional: Gets or sets the timestamp the returned commits should match. Only commits after this date will
        /// be returned.
        /// </summary>
        public EssentialsDateTime Since { get; set; }

        /// <summary>
        /// Optional: Gets or sets the timestamp the returned commits should match. Only commits before this date will
        /// be returned.
        /// </summary>
        public EssentialsDateTime Until { get; set; }

        #endregion

        #region Member methods

        /// <summary>
        /// Generates an instance of <see cref="IHttpQueryString"/> representing the options.
        /// </summary>
        /// <returns>Returns an instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {
            SocialHttpQueryString query = new SocialHttpQueryString();
            if (!String.IsNullOrWhiteSpace(Sha)) query.Add("sha", Sha);
            if (!String.IsNullOrWhiteSpace(Path)) query.Add("path", Path);
            if (!String.IsNullOrWhiteSpace(Author)) query.Add("author", Author);
            if (Since != null) query.Add("since", Since.ToString(TimeHelper.Iso8601DateFormat));
            if (Until != null) query.Add("until", Until.ToString(TimeHelper.Iso8601DateFormat));
            return query;
        }

        #endregion

    }

}