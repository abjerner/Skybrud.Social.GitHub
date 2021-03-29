using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Json.Extensions;
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

    }

}