namespace Skybrud.Social.GitHub.Models {

    /// <summary>
    /// Enum class representing a boolean value, which may be either <see cref="True"/>, <see cref="False"/> or <see cref="Unspecified"/>.
    /// </summary>
    public enum GitHubBoolean {

        /// <summary>
        /// This means that the property was missing in the JSON returned by the GitHub API.
        /// </summary>
        Unspecified,

        /// <summary>
        /// Indicates that a boolean value is <c>false</c>.
        /// </summary>
        False,

        /// <summary>
        /// Indicates that a boolean value is <c>true</c>.
        /// </summary>
        True

    }

}