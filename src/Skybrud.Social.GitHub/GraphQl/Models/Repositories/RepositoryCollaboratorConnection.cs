using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Social.GitHub.Models;

namespace Skybrud.Social.GitHub.GraphQl.Models.Repositories {

    /// <summary>
    /// A repository contains the content for a project.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/graphql/reference/objects#repository</cref>
    /// </see>
    public class RepositoryCollaboratorConnection : GitHubObject {

        #region Properties
        

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the user.</param>
        protected RepositoryCollaboratorConnection(JObject json) : base(json) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="RepositoryCollaboratorConnection"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="RepositoryCollaboratorConnection"/>.</returns>
        public static RepositoryCollaboratorConnection Parse(JObject json) {
            return json == null ? null : new RepositoryCollaboratorConnection(json);
        }

        #endregion

    }

}