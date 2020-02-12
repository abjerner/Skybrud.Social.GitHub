using Newtonsoft.Json;
using Skybrud.Essentials.Json.Converters.Enums;
using Skybrud.Essentials.Strings;

namespace Skybrud.Social.GitHub.Options.Issues.Milestones {

    [JsonConverter(typeof(EnumStringConverter), TextCasing.Underscore)]
    public enum GitHubMilestoneState {
        Open,
        Closed
    }

}