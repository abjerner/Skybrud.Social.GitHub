using Skybrud.Social.GitHub.Constants;

namespace Skybrud.Social.GitHub.Models.Common {

    /// <summary>
    /// Enum class representing the permission to a organization, team, repository or similar.
    /// </summary>
    public enum GitHubPermissionLevel {

        /// <summary>
        /// Indicates a permission level could not be recognized by this package.
        /// </summary>
        Unrecognized = GitHubConstants.Unrecognized,

        /// <summary>
        /// For a request, this option may be used to indicate that the permission level isn't specified, leaving it up to the default value of the API.
        ///
        /// For a response, this value indicates that the permission level was not part of the JSON body in the response.
        /// </summary>
        Unspecified = GitHubConstants.Unspecified,

        /// <summary>
        /// Indicates no permission.
        /// </summary>
        None,

        /// <summary>
        /// Indicates pull permission.
        /// </summary>
        Pull,

        /// <summary>
        /// Indicates push permission.
        /// </summary>
        Push,

        /// <summary>
        /// Indicates read permission.
        /// </summary>
        Read,

        /// <summary>
        /// Indicates write permission.
        /// </summary>
        Write,

        /// <summary>
        /// Indicates admin permission.
        /// </summary>
        Admin

    }

}