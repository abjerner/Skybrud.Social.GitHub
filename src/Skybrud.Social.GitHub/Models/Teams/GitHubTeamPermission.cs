namespace Skybrud.Social.GitHub.Models.Teams;

/// <summary>
/// Enum class representing A team permission.
/// </summary>
public enum GitHubTeamPermission {

    /// <summary>
    /// Indicates pull permission.
    /// </summary>
    Pull,

    /// <summary>
    /// Indicates triage permission.
    /// </summary>
    Triage,

    /// <summary>
    /// Indicates push permission.
    /// </summary>
    Push,

    /// <summary>
    /// Indicates maintain permission.
    /// </summary>
    Maintain,

    /// <summary>
    /// Indicates admin permission.
    /// </summary>
    Admin

}