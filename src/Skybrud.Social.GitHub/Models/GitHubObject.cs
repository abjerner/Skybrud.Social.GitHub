using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;

namespace Skybrud.Social.GitHub.Models {

    /// <summary>
    /// Class representing a basic object from the GitHub API derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class GitHubObject : JsonObjectBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the object.</param>
        protected GitHubObject(JObject obj) : base(obj) { }

        #endregion

    }

}