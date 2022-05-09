using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.GitHub.GraphQl.Models.Users {

    /// <summary>
    /// A user is an individual's account on GitHub that owns repositories and can make new content.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/graphql/reference/objects#user</cref>
    /// </see>
    public class User : JsonObjectBase, INode {

        #region Properties

        /// <summary>
        /// Gets the ID of the object.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// Gets a URL pointing to the user's public avatar.
        /// </summary>
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; }

        /// <summary>
        /// Gets the user's public profile bio.
        /// </summary>
        [JsonProperty("bio")]
        public string Bio { get; }

        /// <summary>
        /// Gets the user's public profile bio as HTML.
        /// </summary>
        [JsonProperty("bioHTML")]
        public string BioHtml { get; }

        /// <summary>
        /// Gets the user's public profile company.
        /// </summary>
        [JsonProperty("company")]
        public string Company { get; }

        /// <summary>
        /// Gets the user's public profile company as HTML.
        /// </summary>
        [JsonProperty("companyHTML")]
        public string CompanyHtml { get; }

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
        /// Gets the user's publicly visible profile email.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; }

        /// <summary>
        /// Gets the user's public profile location.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; }

        /// <summary>
        /// Gets the username used to login.
        /// </summary>
        [JsonProperty("login")]
        public string Login { get; }

        /// <summary>
        /// Gets the user's public profile name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Gets the user's Twitter username.
        /// </summary>
        [JsonProperty("twitterUsername")]
        public string TwitterUsername { get; }

        /// <summary>
        /// Gets the date and time when the object was last updated.
        /// </summary>
        [JsonProperty("updatedAt")]
        public EssentialsTime UpdatedAt { get; }

        /// <summary>
        /// Gets the HTTP URL for this user.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; }

        /// <summary>
        /// Gets a URL pointing to the user's public website/blog.
        /// </summary>
        [JsonProperty("websiteUrl")]
        public string WebsiteUrl { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the user.</param>
        protected User(JObject json) : base(json) {
            Id = json.GetString("id");
            AvatarUrl = json.GetString("avatarUrl");
            Bio = json.GetString("bio");
            BioHtml = json.GetString("bioHTML");
            Company = json.GetString("company");
            CompanyHtml = json.GetString("companyHTML");
            CreatedAt = json.GetString("createdAt", EssentialsTime.FromIso8601);
            DatabaseId = json.GetInt32("databaseId");
            Email = json.GetString("email");
            Location = json.GetString("location");
            Login = json.GetString("login");
            Name = json.GetString("name");
            TwitterUsername = json.GetString("twitterUsername");
            UpdatedAt = json.GetString("updatedAt", EssentialsTime.FromIso8601);
            Url = json.GetString("url");
            WebsiteUrl = json.GetString("websiteUrl");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="User"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="User"/>.</returns>
        public static User Parse(JObject json) {
            return json == null ? null : new User(json);
        }

        #endregion

    }

}