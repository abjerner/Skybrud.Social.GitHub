﻿// ReSharper disable InconsistentNaming
#pragma warning disable 1591

namespace Skybrud.Social.GitHub.Constants {

    /// <summary>
    /// Static class with constants for various GitHub media types.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/media/</cref>
    /// </see>
    /// <see>
    ///     <cref>https://github.com/octokit/octokit.net/blob/master/Octokit/Helpers/AcceptHeaders.cs</cref>
    /// </see>
    public static class GitHubMediaTypes {

        #region Friendly names

        public const string StableVersion = "application/vnd.github.v3";

        public const string StableVersionHtml = "application/vnd.github.html";

        public const string RedirectsPreviewThenStableVersionJson = "application/vnd.github.quicksilver-preview+json; charset=utf-8, application/vnd.github.v3+json; charset=utf-8";

        public const string CommitReferenceSha1MediaType = "application/vnd.github.v3.sha";

        public const string OrganizationPermissionsPreview = "application/vnd.github.ironman-preview+json";

        public const string LicensesApiPreview = "application/vnd.github.drax-preview+json";

        public const string ProtectedBranchesApiPreview = "application/vnd.github.loki-preview+json";

        public const string StarCreationTimestamps = "application/vnd.github.v3.star+json";

        public const string IssueLockingUnlockingApiPreview = "application/vnd.github.the-key-preview+json";

        public const string SquashCommitPreview = "application/vnd.github.polaris-preview+json";

        public const string MigrationsApiPreview = "application/vnd.github.wyandotte-preview+json";

        public const string ReactionsPreview = "application/vnd.github.squirrel-girl-preview";

        public const string SignatureVerificationPreview = "application/vnd.github.cryptographer-preview+sha";

        public const string GpgKeysPreview = "application/vnd.github.cryptographer-preview";

        public const string DeploymentApiPreview = "application/vnd.github.ant-man-preview+json";

        public const string InvitationsApiPreview = "application/vnd.github.swamp-thing-preview+json";

        public const string PagesApiPreview = "application/vnd.github.mister-fantastic-preview+json";

        public const string IssueTimelineApiPreview = "application/vnd.github.mockingbird-preview";

        public const string RepositoryTrafficApiPreview = "application/vnd.github.spiderman-preview";

        public const string PullRequestReviewsApiPreview = "application/vnd.github.black-cat-preview+json";

        public const string DraftPullRequestApiPreview = ShadowCat;

        public const string ProjectsApiPreview = "application/vnd.github.inertia-preview+json";

        public const string OrganizationMembershipPreview = "application/vnd.github.korra-preview+json";

        public const string NestedTeamsPreview = "application/vnd.github.hellcat-preview+json";

        public const string GitHubAppsPreview = "application/vnd.github.machine-man-preview+json";

        public const string PreReceiveEnvironmentsPreview = "application/vnd.github.eye-scream-preview+json";

        public const string LabelsApiPreview = "application/vnd.github.symmetra-preview+json";

        public const string RepositoryTransferPreview = "application/vnd.github.nightshade-preview+json";

        public const string ChecksApiPreview = "application/vnd.github.antiope-preview+json";

        public const string ProtectedBranchesRequiredApprovingApiPreview = LukeCage;

        #endregion

        #region Funny names

        public const string Baptiste = "application/vnd.github.baptiste-preview+json";

        public const string LukeCage = "application/vnd.github.luke-cage-preview+json";

        public const string SailorV = "application/vnd.github.sailor-v-preview+json";

        public const string ShadowCat = "application/vnd.github.shadow-cat-preview+json";

        #endregion

    }

}