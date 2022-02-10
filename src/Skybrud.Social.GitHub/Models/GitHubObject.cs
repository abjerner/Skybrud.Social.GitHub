using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;

namespace Skybrud.Social.GitHub.Models {

    /// <summary>
    /// Class representing a basic object from the GitHub API derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class GitHubObject : JsonObjectBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected GitHubObject(JObject json) : base(json) { }

        #endregion

    }

}