using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.GitHub.Options.Commits {

    /// <summary>
    /// Class representing the options for getting a list of commits of a given repository.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/repos/commits/#list-commits-on-a-repository</cref>
    /// </see>
    public class GitHubGetCommitsOptions: IHttpGetOptions {

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
        public EssentialsTime Since { get; set; }

        /// <summary>
        /// Optional: Gets or sets the timestamp the returned commits should match. Only commits before this date will
        /// be returned.
        /// </summary>
        public EssentialsTime Until { get; set; }

        /// <summary>
        /// Gets or sets the page to be returned.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of commits to be returned by each page. Maximum allowed value is <c>100</c>.
        /// </summary>
        public int PerPage { get; set; }

        #endregion

        #region Member methods

        /// <summary>
        /// Generates an instance of <see cref="IHttpQueryString"/> representing the options.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {
            IHttpQueryString query = new HttpQueryString();
            if (!string.IsNullOrWhiteSpace(Sha)) query.Add("sha", Sha);
            if (!string.IsNullOrWhiteSpace(Path)) query.Add("path", Path);
            if (!string.IsNullOrWhiteSpace(Author)) query.Add("author", Author);
            if (Since != null) query.Add("since", Since.Iso8601);
            if (Until != null) query.Add("until", Until.Iso8601);
            if (Page > 0) query.Add("page", Page);
            if (PerPage > 0) query.Add("per_page", PerPage);
            return query;
        }

        #endregion

    }

}