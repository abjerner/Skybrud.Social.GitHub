using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.Objects {

    /// <summary>
    /// Class representing a basic object from the GitHub API derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the internal <see cref="JObject"/> the object was created from.
        /// </summary>
        [JsonIgnore]
        public JObject JObject { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the object.</param>
        protected GitHubObject(JObject obj) {
            JObject = obj;
        }

        #endregion

    }

}