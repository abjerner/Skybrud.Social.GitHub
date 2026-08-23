using System;
using Newtonsoft.Json;
using Skybrud.Social.GitHub.Http;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Skybrud.Social.GitHub.Json.Newtonsoft;

public class PatchValueJsonConverter : JsonConverter {

    public override bool CanRead => false;

    public override bool CanConvert(Type objectType) {
        return objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(GitHubPatchValue<>);
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) {

        if (value is null) {
            writer.WriteNull();
            return;
        }

        var valueProperty = value.GetType().GetProperty(nameof(GitHubPatchValue<object>.Value))!;
        var innerValue = valueProperty.GetValue(value);

        serializer.Serialize(writer, innerValue);

    }

    public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer) {
        throw new NotSupportedException();
    }

}