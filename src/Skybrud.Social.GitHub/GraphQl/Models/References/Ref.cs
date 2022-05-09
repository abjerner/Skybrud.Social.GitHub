using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.GitHub.Models;

namespace Skybrud.Social.GitHub.GraphQl.Models.References {

    /// <summary>
    /// Represents a Git reference.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/graphql/reference/objects#ref</cref>
    /// </see>
    public class Ref : GitHubObject, INode {

        // TODO: is "References" the correct namespace?

        #region Properties

        /// <summary>
        /// Gets the ID of the object.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// Gets the the ref name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Gets the ref's prefix, such as <c>refs/heads/</c> or <c>refs/tags/</c>.
        /// </summary>
        [JsonProperty("prefix")]
        public string Prefix { get; }
        
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the user.</param>
        protected Ref(JObject json) : base(json) {
            Id = json.GetString("id");
            Name = json.GetString("name");
            Prefix = json.GetString("prefix");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="Ref"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="Ref"/>.</returns>
        public static Ref Parse(JObject json) {
            return json == null ? null : new Ref(json);
        }

        #endregion

    }

}