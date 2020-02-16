using System.Collections.Generic;
using Skybrud.Essentials.Http;

// ReSharper disable InconsistentNaming

namespace Skybrud.Social.GitHub.Extensions {

    /// <summary>
    /// Various extension methods for <see cref="IHttpRequest"/>.
    /// </summary>
    public static class HttpRequestExtensions {

        /// <summary>
        /// Sets the <strong>Accept</strong> header of <paramref name="request"/>.
        /// </summary>
        /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
        /// <param name="request">The request.</param>
        /// <param name="value">The value of the header.</param>
        /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
        public static T SetAcceptHeader<T>(this T request, string value) where T : IHttpRequest {
            if (request != null) request.Accept = value;
            return request;
        }

        /// <summary>
        /// Sets the <strong>Accept</strong> header of <paramref name="request"/>.
        /// </summary>
        /// <typeparam name="T">The type of the request - eg. <see cref="HttpRequest"/>.</typeparam>
        /// <param name="request">The request.</param>
        /// <param name="value">The value of the header.</param>
        /// <returns>The specified <paramref name="request"/> as an instance of <typeparamref name="T"/>.</returns>
        public static T SetAcceptHeader<T>(this T request, IEnumerable<string> value) where T : IHttpRequest {
            if (request != null) request.Accept = value == null ? string.Empty : string.Join(",", value);
            return request;
        }

    }

}