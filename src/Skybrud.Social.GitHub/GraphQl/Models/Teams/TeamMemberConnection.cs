using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.GitHub.GraphQl.Models.Users;
using Skybrud.Social.GitHub.Models;

namespace Skybrud.Social.GitHub.GraphQl.Models.Teams {

    /// <summary>
    /// The connection type for User.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/graphql/reference/objects#teammemberconnection</cref>
    /// </see>
    public class TeamMemberConnection : GitHubObject {

        #region Properties

        // Add support for the "edges" property

        /// <summary>
        /// Gets a list of nodes.
        /// </summary>
        [JsonProperty("nodes")]
        public IReadOnlyList<User> Nodes { get; }

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
        protected TeamMemberConnection(JObject json) : base(json) {
            Nodes = json.GetArray("nodes", User.Parse);
            PageInfo = json.GetObject("pageInfo", PageInfo.Parse);
            TotalCount = json.GetInt32("totalCount");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="TeamMemberConnection"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="TeamMemberConnection"/>.</returns>
        public static TeamMemberConnection Parse(JObject json) {
            return json == null ? null : new TeamMemberConnection(json);
        }

        #endregion

    }

}