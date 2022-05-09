using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.GitHub.Models;

namespace Skybrud.Social.GitHub.GraphQl.Models.Organizations {
    
    /// <summary>
    /// Class representing the result of an <strong>Organization</strong> query.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/graphql/reference/queries#organization</cref>
    /// </see>
    public class OrganizationResult : GitHubObject {

        #region Properties
        
        /// <summary>
        /// Gets the data of the result.
        /// </summary>
        public OrganizationData Data { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the user.</param>
        protected OrganizationResult(JObject json) : base(json) {
            Data = json.GetObject("data", OrganizationData.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="OrganizationResult"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="OrganizationResult"/>.</returns>
        public static OrganizationResult Parse(JObject json) {
            return json == null ? null : new OrganizationResult(json);
        }

        #endregion

    }

}