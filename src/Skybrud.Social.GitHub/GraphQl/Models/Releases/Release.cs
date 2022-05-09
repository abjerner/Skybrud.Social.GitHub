using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.GraphQl.Models.Users;
using Skybrud.Social.GitHub.Models;

namespace Skybrud.Social.GitHub.GraphQl.Models.Releases {

    /// <summary>
    /// Represents a Git reference.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/graphql/reference/objects#release</cref>
    /// </see>
    public class Release : GitHubObject, INode {

        #region Properties

        /// <summary>
        /// Gets the ID of the object.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// Gets the author of the release.
        /// </summary>
        [JsonProperty("author")]
        public User Author { get; }

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
        /// Gets the description of the release.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <summary>
        /// Gets the HTML description of the release.
        /// </summary>
        [JsonProperty("descriptionHTML")]
        public string DescriptionHtml { get; }

        /// <summary>
        /// Gets the title of the release.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Gets thhe date and time when the release was published.
        /// </summary>
        [JsonProperty("publishedAt")]
        public EssentialsTime PublishedAt { get; }

        /// <summary>
        /// Gets the name of the release's Git tag.
        /// </summary>
        [JsonProperty("tagName")]
        public string TagName { get; }

        /// <summary>
        /// Gets the date and time when the object was last updated.
        /// </summary>
        [JsonProperty("updatedAt")]
        public EssentialsTime UpdatedAt { get; }

        /// <summary>
        /// Gets the HTTP URL for this release.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the user.</param>
        protected Release(JObject json) : base(json) {
            Id = json.GetString("id");
            Author = json.GetObject("author", User.Parse);
            CreatedAt = json.GetString("createdAt", EssentialsTime.FromIso8601);
            DatabaseId = json.GetInt32("databaseId");
            Description = json.GetString("description");
            DescriptionHtml = json.GetString("descriptionHTML");
            Name = json.GetString("name");
            PublishedAt = json.GetString("publishedAt", EssentialsTime.FromIso8601);
            TagName = json.GetString("tagName");
            UpdatedAt = json.GetString("updatedAt", EssentialsTime.FromIso8601);
            Url = json.GetString("url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="Release"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="Release"/>.</returns>
        public static Release Parse(JObject json) {
            return json == null ? null : new Release(json);
        }

        #endregion

    }

}