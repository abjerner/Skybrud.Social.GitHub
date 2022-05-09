using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.GitHub.Models;

namespace Skybrud.Social.GitHub.GraphQl.Models.Organizations {

    public class OrganizationData : GitHubObject {

        #region Properties
        
        public Organization Organization { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the user.</param>
        protected OrganizationData(JObject json) : base(json) {
            Organization = json.GetObject("organization", Organization.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="OrganizationData"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="OrganizationData"/>.</returns>
        public static OrganizationData Parse(JObject json) {
            return json == null ? null : new OrganizationData(json);
        }

        #endregion

    }

}