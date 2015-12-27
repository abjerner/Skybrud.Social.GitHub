﻿using System;
using Skybrud.Social.GitHub.Objects;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Responses { 

    public class GitHubOrganizationsResponse : GitHubResponse<GitHubOrganizationSummary[]> {

        #region Constructor

        private GitHubOrganizationsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        public static GitHubOrganizationsResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubOrganizationsResponse(response) {
                Body = JsonArray.ParseJson(response.Body).ParseMultiple(GitHubOrganizationSummary.Parse)
            };

        }

    }

}