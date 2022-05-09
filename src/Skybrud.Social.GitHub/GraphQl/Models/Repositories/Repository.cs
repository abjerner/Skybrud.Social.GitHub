using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Models;

namespace Skybrud.Social.GitHub.GraphQl.Models.Repositories {

    /// <summary>
    /// A repository contains the content for a project.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/graphql/reference/objects#repository</cref>
    /// </see>
    public class Repository : GitHubObject, INode {

        #region Properties

        /// <summary>
        /// Gets the ID of the object.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

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
        /// Gets the description of the repository.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <summary>
        /// Gets the HTML description of the repository.
        /// </summary>
        [JsonProperty("descriptionHTML")]
        public string DescriptionHtml { get; }

        /// <summary>
        /// Gets the name of the repository.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Gets the name of the repository.
        /// </summary>
        [JsonProperty("nameWithOwner")]
        public string NameWithOwner { get; }

        /// <summary>
        /// Gets a list of the collaborators of the repository.
        /// </summary>
        [JsonProperty("collaborators")]
        public RepositoryCollaboratorConnection Collaborators { get; }

        /// <summary>
        /// Gets the date and time when the object was last updated.
        /// </summary>
        [JsonProperty("updatedAt")]
        public EssentialsTime UpdatedAt { get; }

        /// <summary>
        /// Gets the HTTP URL for this repository.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the user.</param>
        protected Repository(JObject json) : base(json) {
            Id = json.GetString("id");
            CreatedAt = json.GetString("createdAt", EssentialsTime.FromIso8601);
            DatabaseId = json.GetInt32("databaseId");
            Description = json.GetString("description");
            DescriptionHtml = json.GetString("descriptionHTML");
            Name = json.GetString("name");
            UpdatedAt = json.GetString("updatedAt", EssentialsTime.FromIso8601);
            Url = json.GetString("url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="Repository"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="Repository"/>.</returns>
        public static Repository Parse(JObject json) {
            return json == null ? null : new Repository(json);
        }

        #endregion

    }

}