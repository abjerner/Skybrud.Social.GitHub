﻿using System;
using Skybrud.Social.GitHub.Objects;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses {

    public class GitHubUserResponse : GitHubResponse<GitHubUser> {

        #region Constructor

        private GitHubUserResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        public static GitHubUserResponse ParseResponse(SocialHttpResponse response) {
            
            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubUserResponse(response) {
                Body = SocialUtils.ParseJsonObject(response.Body, GitHubUser.Parse)
            };

        }

    }

}