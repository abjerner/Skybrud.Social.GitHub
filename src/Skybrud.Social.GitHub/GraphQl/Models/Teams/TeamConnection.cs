using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.GitHub.Models;

namespace Skybrud.Social.GitHub.GraphQl.Models.Teams {
    
    /// <summary>
    /// The connection type for a <strong>Team</strong>.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/graphql/reference/objects#teamconnection</cref>
    /// </see>
    public class TeamConnection : GitHubObject {

        #region Properties

        // Add support for the "edges" property

        /// <summary>
        /// A list of nodes.
        /// </summary>
        [JsonProperty("nodes")]
        public Team[] Nodes { get; }

        /// <summary>
        /// Gets nformation to aid in pagination.
        /// </summary>
        [JsonProperty("pageInfo")]
        public PageInfo PageInfo { get; }

        /// <summary>
        /// Gets the total count of items in the connection.
        /// </summary>
        [JsonProperty("totalCount")]
        public int TotalCount { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the user.</param>
        protected TeamConnection(JObject json) : base(json) {
            Nodes = json.GetArray("nodes", Team.Parse);
            PageInfo = json.GetObject("pageInfo", PageInfo.Parse);
            TotalCount = json.GetInt32("totalCount");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="PageInfo"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="PageInfo"/>.</returns>
        public static TeamConnection Parse(JObject json) {
            return json == null ? null : new TeamConnection(json);
        }

        #endregion

    }

}