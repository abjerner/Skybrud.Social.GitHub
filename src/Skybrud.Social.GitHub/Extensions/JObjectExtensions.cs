using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Constants;

// ReSharper disable InconsistentNaming

namespace Skybrud.Social.GitHub.Extensions {

    /// <summary>
    /// Various extensions methods for <see cref="JObject"/> that makes manual parsing easier.
    /// </summary>
    public static class JObjectExtensions {

        /// <summary>
        /// Gets an enum of type <typeparamref name="T"/> from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="json">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <param name="empty">A fallback value to be used instead if the property isn't present or it's value is empty.</param>
        /// <param name="unrecognized">A fallback value to be used instead if the property value could not be parsed.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T GetEnum<T>(this JObject json, string path, T empty, T unrecognized) where T : struct {
            string value = json.GetString(path);
            return string.IsNullOrWhiteSpace(value) ? empty : EnumUtils.ParseEnum(value, unrecognized);
        }

        /// <summary>
        /// Gets an enum of type <typeparamref name="T"/> from the token matching the specified <paramref name="path"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="json">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="string"/> that contains a JPath expression.</param>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        public static T GetEnumWithFallbacks<T>(this JObject json, string path) where T : struct {
            string value = json.GetString(path);
            return string.IsNullOrWhiteSpace(value) ? (T) (object) GitHubConstants.Unspecified : EnumUtils.ParseEnum(value, (T) (object) GitHubConstants.Unrecognized);
        }

        /// <summary>
        /// Gets an instance of <see cref="EssentialsTime"/> from the property with the specified
        /// <paramref name="propertyName"/>. If the property is not found or it's value is empty, <c>null</c> is
        /// returned instead.
        /// </summary>
        /// <param name="json">The JSON object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime GetEssentialsTime(this JObject json, string propertyName) {
            if (string.IsNullOrWhiteSpace(propertyName)) throw new ArgumentNullException(nameof(propertyName));
            return EssentialsTime.Parse(json?.GetValue(propertyName)?.Value<string>());
        }

        /// <summary>
        /// Gets an instance of <see cref="EssentialsTime"/> from the token at the specified <paramref name="path"/>.
        /// If a token a matching token is not found, or it's value is empty, <c>null</c> will be returned instead.
        /// </summary>
        /// <param name="json">The JSON object.</param>
        /// <param name="path">The path to the token.</param>
        /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
        public static EssentialsTime GetEssentialsTimeByPath(this JObject json, string path) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            return EssentialsTime.Parse(json?.SelectToken(path)?.Value<string>());
        }

    }

}