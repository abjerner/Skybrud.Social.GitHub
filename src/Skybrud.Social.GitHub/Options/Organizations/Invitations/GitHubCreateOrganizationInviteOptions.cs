//using Skybrud.Essentials.Common;
//using Skybrud.Essentials.Http;
//using Skybrud.Essentials.Http.Collections;
//using Skybrud.Essentials.Http.Options;
//using Skybrud.Social.GitHub.Models.Organizations;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Skybrud.Social.GitHub.Options.Organizations.Invites {

//    public class GitHubCreateOrganizationInviteOptions : IHttpRequestOptions {

//        /// <summary>
//        /// Gets or sets the alias/slug of the organization.
//        /// </summary>
//        public string OrgAlias { get; set; }

//        public int InviteeId { get; set; }

//        public string Email { get; set; }

//        // role

//        public List<int> TeamIds { get; }

//        public GitHubGetFailedInvitationsOptions() { }

//        public GitHubGetFailedInvitationsOptions(string orgAlias) {
//            OrgAlias = orgAlias;
//        }

//        public GitHubGetFailedInvitationsOptions(string orgAlias, int perPage) {
//            OrgAlias = orgAlias;
//            PerPage = perPage;
//        }

//        public GitHubGetFailedInvitationsOptions(GitHubOrganizationItem organization) {
//            if (organization == null) throw new ArgumentNullException(nameof(organization));
//            OrgAlias = organization.Login;
//        }

//        public GitHubGetFailedInvitationsOptions(GitHubOrganizationItem organization, int perPage) {
//            if (organization == null) throw new ArgumentNullException(nameof(organization));
//            OrgAlias = organization.Login;
//            PerPage = perPage;
//        }

//        /// <inheritdoc />
//        public override IHttpRequest GetRequest() {

//            if (string.IsNullOrWhiteSpace(OrgAlias)) throw new PropertyNotSetException(nameof(OrgAlias));

//            IHttpQueryString query = new HttpQueryString();

//            if (PerPage > 0) query.Add("per_page", PerPage);
//            if (Page > 0) query.Add("page", Page);

//            return HttpRequest.Get($"/orgs/{OrgAlias}/failed_invitations", query);

//        }

//    }

//}