using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.GitHub.Objects.Commits {
    
    public class GitHubCommitAuthor : GitHubObject {

        #region Properties

        [JsonProperty("name")]
        public string Name { get; private set; }
        
        [JsonProperty("email")]
        public string Email { get; private set; }
        
        [JsonProperty("date")]
        public DateTime Date { get; private set; }
        
        #endregion

        #region Constructor

        private GitHubCommitAuthor(JObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubCommitAuthor Parse(JObject obj) {
            if (obj == null) return null;
            return new GitHubCommitAuthor(obj) {
                Name = obj.GetString("name"),
                Email = obj.GetString("email"),
                Date = obj.GetDateTime("date")
            };
        }

        #endregion

    }

}