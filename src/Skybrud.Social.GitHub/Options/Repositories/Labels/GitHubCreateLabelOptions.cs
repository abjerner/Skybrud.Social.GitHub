using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.GitHub.Options.Repositories.Labels {
    
    /// <summary>
    /// Options for creating a new label in a GitHub repository.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/issues#create-a-label</cref>
    /// </see>
    public class GitHubCreateLabelOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the alias of the owner.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Gets or sets the alias/slug of the repository.
        /// </summary>
        public string Repo { get; set; }

        /// <summary>
        /// Gets or sets the name of the label.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the hexadecimal color code for the label, without the leading <c>#</c>.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets a short description of the label.
        /// </summary>
        public string Description { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubCreateLabelOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repo"/> slug and label <paramref name="name"/>.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repo">The alias/slug of the repository.</param>
        /// <param name="name">The name of the label.</param>
        public GitHubCreateLabelOptions(string owner, string repo, string name) {
            Owner = owner;
            Repo = repo;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repo"/> slug and label <paramref name="name"/>.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repo">The alias/slug of the repository.</param>
        /// <param name="name">The name of the label.</param>
        /// <param name="color">The the hexadecimal color code for the label, without the leading <c>#</c>.</param>
        /// <param name="description">A short description of the label.</param>
        public GitHubCreateLabelOptions(string owner, string repo, string name, string color, string description) {
            Owner = owner;
            Repo = repo;
            Name = name;
            Color = color;
            Description = description;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            // Input validation
            if (string.IsNullOrWhiteSpace(Owner)) throw new PropertyNotSetException(nameof(Owner));
            if (string.IsNullOrWhiteSpace(Repo)) throw new PropertyNotSetException(nameof(Repo));
            if (string.IsNullOrWhiteSpace(Name)) throw new PropertyNotSetException(nameof(Name));

            // Initialize the POST body
            JObject body = new JObject {
                {"name", Name}
            };

            // Add optional parameters
            if (!string.IsNullOrWhiteSpace(Color)) body.Add("color", Color);
            if (!string.IsNullOrWhiteSpace(Description)) body.Add("description", Description);

            // Initialize a new POST request
            return HttpRequest.Post($"/repos/{Owner}/{Repo}/labels", body);

        }

        #endregion

    }

}