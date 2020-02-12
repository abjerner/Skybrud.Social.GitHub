using Newtonsoft.Json;
using Skybrud.Essentials.Json.Converters.Enums;
using Skybrud.Essentials.Strings;

namespace Skybrud.Social.GitHub.Options.Issues.Milestones {

    /// <summary>
    /// Enum class representing the state of a milestone.
    /// </summary>
    [JsonConverter(typeof(EnumStringConverter), TextCasing.Underscore)]
    public enum GitHubMilestoneState {

        /// <summary>
        /// Indicates an open milestone.
        /// </summary>
        Open,

        /// <summary>
        /// Indicates a closed milestone.
        /// </summary>
        Closed

    }

}