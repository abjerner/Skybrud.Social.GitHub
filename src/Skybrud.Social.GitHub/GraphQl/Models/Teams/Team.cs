using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Models;

namespace Skybrud.Social.GitHub.GraphQl.Models.Teams {
    
    /// <summary>
    /// A team of users in an organization.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/graphql/reference/objects#team</cref>
    /// </see>
    public class Team : GitHubObject, INode {

        #region Properties

        /// <summary>
        /// Gets the ID of the object.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// Gets a URL pointing to the team's avatar.
        /// </summary>
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; }

        /// <summary>
        /// Gets the date and time when the object was created.
        /// </summary>
        [JsonProperty("createdAt")]
        public EssentialsTime CreatedAt { get; }

        /// <summary>
        /// Gets the primary key from the database.
        /// </summary>
        [JsonProperty("databaseId")]
        public int DatabaseId { get; }

        /// <summary>
        /// Gets the description of the team.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <summary>
        /// Gets a list of users who are members of this team.
        /// </summary>
        [JsonProperty("members")]
        public TeamMemberConnection Members { get; }

        /// <summary>
        /// Gets the name of the team.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Gets the level of privacy the team has.
        /// </summary>
        [JsonProperty("privacy")]
        public TeamPrivacy Privacy { get; }

        /// <summary>
        /// Gets the slug corresponding to the team.
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; }

        /// <summary>
        /// Gets the date and time when the object was last updated.
        /// </summary>
        [JsonProperty("updatedAt")]
        public EssentialsTime UpdatedAt { get; }

        /// <summary>
        /// Gets the HTTP URL for this team.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the user.</param>
        protected Team(JObject json) : base(json) {
            Id = json.GetString("id");
            AvatarUrl = json.GetString("avatarUrl");
            CreatedAt = json.GetString("createdAt", EssentialsTime.FromIso8601);
            DatabaseId = json.GetInt32("databaseId");
            Description = json.GetString("description");
            Members = json.GetObject("members", TeamMemberConnection.Parse);
            Name = json.GetString("name");
            Privacy = json.GetEnum<TeamPrivacy>("privacy");
            Slug = json.GetString("slug");
            UpdatedAt = json.GetString("updatedAt", EssentialsTime.FromIso8601);
            Url = json.GetString("url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="Team"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="Team"/>.</returns>
        public static Team Parse(JObject json) {
            return json == null ? null : new Team(json);
        }

        #endregion

    }

}