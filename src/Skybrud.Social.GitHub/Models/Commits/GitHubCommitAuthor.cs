using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Extensions;

namespace Skybrud.Social.GitHub.Models.Commits {
    
    /// <summary>
    /// Class representing the author of a commit.
    /// </summary>
    public class GitHubCommitAuthor : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the name of the author.
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Gets the email address of the author.
        /// </summary>
        public string Email { get; }
        
        /// <summary>
        /// Gets the date of the commit.
        /// </summary>
        public EssentialsTime Date { get; }
        
        #endregion

        #region Constructors

        private GitHubCommitAuthor(JObject obj) : base(obj) {
            Name = obj.GetString("name");
            Email = obj.GetString("email");
            Date = obj.GetEssentialsTime("date");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubCommitAuthor"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubCommitAuthor"/>.</returns>
        public static GitHubCommitAuthor Parse(JObject obj) {
            return obj == null ? null : new GitHubCommitAuthor(obj);
        }

        #endregion

    }

}