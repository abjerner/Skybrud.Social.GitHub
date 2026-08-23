using Newtonsoft.Json;
using Skybrud.Social.GitHub.Json.Newtonsoft;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Skybrud.Social.GitHub.Http;

[JsonConverter(typeof(GitHubHttpPatchValueJsonConverter))]
public class GitHubHttpPatchValue<T> {

    public T Value { get; }

    public GitHubHttpPatchValue(T value) {
        Value = value;
    }

    public static implicit operator GitHubHttpPatchValue<T>(T value) => new(value);

}