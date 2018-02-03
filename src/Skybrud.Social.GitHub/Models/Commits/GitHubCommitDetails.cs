using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Commits {
    
    /// <summary>
    /// Class representing the details of a commit.
    /// </summary>
    public class GitHubCommitDetails : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets information about the author of the commit.
        /// </summary>
        public GitHubCommitAuthor Author { get; }
        
        /// <summary>
        /// Gets information about the user who committed the commit.
        /// </summary>
        public GitHubCommitAuthor Committer { get; }
        
        /// <summary>
        /// Gets the message of the commit.
        /// </summary>
        public string Message { get; }
        
        /// <summary>
        /// Gets information about the tree begind the commit.
        /// </summary>
        public GitHubCommitTree Tree { get; }
        
        /// <summary>
        /// Gets the API URL of the commit.
        /// </summary>
        public string Url { get; }
        
        /// <summary>
        /// Gets the amount of comments the commit has received.
        /// </summary>
        public int CommentCount { get; }
        
        #endregion

        #region Constructors

        private GitHubCommitDetails(JObject obj) : base(obj) {
            Author = obj.GetObject("author", GitHubCommitAuthor.Parse);
            Committer = obj.GetObject("committer", GitHubCommitAuthor.Parse);
            Message = obj.GetString("message");
            Tree = obj.GetObject("tree", GitHubCommitTree.Parse);
            Url = obj.GetString("url");
            CommentCount = obj.GetInt32("comment_count");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubCommitDetails"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubCommitDetails"/>.</returns>
        public static GitHubCommitDetails Parse(JObject obj) {
            return obj == null ? null : new GitHubCommitDetails(obj);
        }

        #endregion

    }

}