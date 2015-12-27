using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.GitHub.Objects.Commits {
    
    public class GitHubCommitTree : GitHubObject {

        #region Properties

        [JsonProperty("sha")]
        public string Sha { get; private set; }
        
        [JsonProperty("url")]
        public string Url { get; private set; }
        
        #endregion

        #region Constructor

        private GitHubCommitTree(JObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubCommitTree Parse(JObject obj) {
            if (obj == null) return null;
            return new GitHubCommitTree(obj) {
                Sha = obj.GetString("sha"),
                Url = obj.GetString("url")
            };
        }

        #endregion

    }

}