using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.GraphQl.Models.Teams;
using Skybrud.Social.GitHub.Models;

namespace Skybrud.Social.GitHub.GraphQl.Models.Organizations {
    
    /// <summary>
    /// An account on GitHub, with one or more owners, that has repositories, members and teams.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/graphql/reference/objects#organization</cref>
    /// </see>
    public class Organization : GitHubObject, INode {

        #region Properties

        /// <summary>
        /// Gets the ID of the object.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// Gets a URL pointing to the organization's public avatar.
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
        /// Gets the organization's public profile description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <summary>
        /// Gets the organization's public profile description rendered to HTML.
        /// </summary>
        [JsonProperty("descriptionHTML")]
        public string DescriptionHtml { get; }

        /// <summary>
        /// Gets the organization's public email.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; }

        /// <summary>
        /// Gets whether the organization has verified its profile email and website.
        /// </summary>
        [JsonProperty("isVerified")]
        public bool IsVerified { get; }

        /// <summary>
        /// Gets the organization's public profile location.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; }

        /// <summary>
        /// Gets the organization's login name.
        /// </summary>
        [JsonProperty("login")]
        public string Login { get; }

        /// <summary>
        /// Gets a list of users who are members of this organization.
        /// </summary>
        [JsonProperty("membersWithRole")]
        public OrganizationMemberConnection MembersWithRole { get; }

        /// <summary>
        /// Gets the organization's public profile name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Gets a list of teams in this organization.
        /// </summary>
        [JsonProperty("teams")]
        public TeamConnection Teams { get; }

        /// <summary>
        /// Gets the organization's Twitter username.
        /// </summary>
        [JsonProperty("twitterUsername")]
        public string TwitterUsername { get; }

        /// <summary>
        /// Gets the date and time when the object was last updated.
        /// </summary>
        [JsonProperty("updatedAt")]
        public EssentialsTime UpdatedAt { get; }

        /// <summary>
        /// Gets the HTTP URL for this organization.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; }

        /// <summary>
        /// Gets the organization's public profile URL.
        /// </summary>
        [JsonProperty("websiteUrl")]
        public string WebsiteUrl { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the user.</param>
        protected Organization(JObject json) : base(json) {
            Id = json.GetString("id");
            AvatarUrl = json.GetString("avatarUrl");
            CreatedAt = json.GetString("createdAt", EssentialsTime.FromIso8601);
            DatabaseId = json.GetInt32("databaseId");
            Description = json.GetString("description");
            DescriptionHtml = json.GetString("descriptionHTML");
            Email = json.GetString("email");
            IsVerified = json.GetBoolean("isVerified");
            Location = json.GetString("location");
            Login = json.GetString("login");
            MembersWithRole = json.GetObject("membersWithRole", OrganizationMemberConnection.Parse);
            Name = json.GetString("name");
            Teams = json.GetObject("teams", TeamConnection.Parse);
            TwitterUsername = json.GetString("twitterUsername");
            UpdatedAt = json.GetString("updatedAt", EssentialsTime.FromIso8601);
            Url = json.GetString("url");
            WebsiteUrl = json.GetString("websiteUrl");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="Organization"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="Organization"/>.</returns>
        public static Organization Parse(JObject json) {
            return json == null ? null : new Organization(json);
        }

        #endregion

    }

}