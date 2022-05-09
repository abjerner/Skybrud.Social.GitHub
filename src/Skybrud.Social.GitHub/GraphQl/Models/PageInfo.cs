using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.GraphQl.Models {

    /// <summary>
    /// Information about pagination in a connection.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/graphql/reference/objects#pageinfo</cref>
    /// </see>
    public class PageInfo {

        #region Properties

        // Add support for the "endCursor " property

        // Add support for the "hasNextPage" property

        // Add support for the "hasPreviousPage" property

        // Add support for the "startCursor" property

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the user.</param>
        protected PageInfo(JObject json) {

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="PageInfo"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="PageInfo"/>.</returns>
        public static PageInfo Parse(JObject json) {
            return json == null ? null : new PageInfo(json);
        }

        #endregion

    }

}