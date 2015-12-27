using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.GitHub.Objects.Commits {
    
    public class GitHubCommitStats : GitHubObject {

        #region Properties

        [JsonProperty("additions")]
        public int Additions { get; private set; }
        
        [JsonProperty("deletions")]
        public int Deletions { get; private set; }
        
        [JsonProperty("total")]
        public int Total { get; private set; }
        
        #endregion

        #region Constructor

        private GitHubCommitStats(JObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubCommitStats Parse(JObject obj) {
            if (obj == null) return null;
            return new GitHubCommitStats(obj) {
                Additions = obj.GetInt32("additions"),
                Deletions = obj.GetInt32("deletions"),
                Total = obj.GetInt32("total")
            };
        }

        #endregion

    }

}
