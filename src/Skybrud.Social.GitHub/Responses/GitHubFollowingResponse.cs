using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Social.GitHub.Exceptions;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.GitHub.Responses {

    public class GitHubFollowingResponse : GitHubResponse {

        #region Properties

        public bool IsFollowing { get; private set; }

        #endregion

        #region Constructor

        private GitHubFollowingResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        public static GitHubFollowingResponse ParseResponse(SocialHttpResponse response) {

            switch (response.StatusCode) {

                case HttpStatusCode.NoContent:
                    return new GitHubFollowingResponse(response) {
                        IsFollowing = true
                    };

                case HttpStatusCode.NotFound:
                    return new GitHubFollowingResponse(response) {
                        IsFollowing = false
                    };

                default:

                    // Parse the raw JSON response
                    JObject obj = SocialUtils.ParseJsonObject(response.Body);

                    string message = obj.GetString("message");
                    string url = obj.GetString("documentation_url");
                    throw new GitHubHttpException(response, message, url);
                    
            }

        }

    }

}