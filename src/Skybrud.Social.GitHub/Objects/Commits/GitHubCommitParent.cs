using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.GitHub.Objects.Commits {
    
    public class GitHubCommitParent : GitHubObject {

        #region Properties

        [JsonProperty("sha")]
        public string Sha { get; private set; }
        
        [JsonProperty("url")]
        public string Url { get; private set; }
        
        [JsonProperty("html_url")]
        public string HtmlUrl { get; private set; }
        
        #endregion

        #region Constructor

        private GitHubCommitParent(JObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubCommitParent Parse(JObject obj) {
            if (obj == null) return null;
            return new GitHubCommitParent(obj) {
                Sha = obj.GetString("sha"),
                Url = obj.GetString("url"),
                HtmlUrl = obj.GetString("html_url")
            };
        }

        #endregion

    }

}