using Newtonsoft.Json;
using Skybrud.Social.GitHub.Json.Newtonsoft;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Skybrud.Social.GitHub.Http;

[JsonConverter(typeof(PatchValueJsonConverter))]
public class GitHubPatchValue<T> {

    public bool IsSpecified { get; }

    public T Value { get; }

    public GitHubPatchValue(T value) {
        Value = value;
        IsSpecified = true;
    }

    public static implicit operator GitHubPatchValue<T>(T value) => new(value);

}