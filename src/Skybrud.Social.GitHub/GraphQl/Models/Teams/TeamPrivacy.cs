namespace Skybrud.Social.GitHub.GraphQl.Models.Teams {
    
    /// <summary>
    /// The possible team privacy values.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/graphql/reference/enums#teamprivacy</cref>
    /// </see>
    public enum TeamPrivacy {

        /// <summary>
        /// A secret team can only be seen by its members.
        /// </summary>
        Secret,

        /// <summary>
        /// A visible team can be seen and @mentioned by every member of the organization.
        /// </summary>
        Visible

    }

}