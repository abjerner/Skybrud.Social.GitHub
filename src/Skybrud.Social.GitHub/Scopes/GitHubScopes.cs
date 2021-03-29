// ReSharper disable InconsistentNaming

namespace Skybrud.Social.GitHub.Scopes {

    /// <summary>
    /// Static class with properties representing scopes of the GitHub API.
    /// </summary>
    public static class GitHubScopes {

        /// <summary>
        /// Grants read-only access to public information (includes public user profile info,
        /// public repository info, and gists).
        /// </summary>
        public static readonly GitHubScope Default = GitHubScope.RegisterScope(
            "",
            "Default",
            "Grants read-only access to public information (includes public user profile info, public repository info, and gists)."
        );

        /// <summary>
        /// Gets an array of all build-in scopes.
        /// </summary>
        /// <returns></returns>
        public static readonly GitHubScope[] All = {
            Default,
            Repositories.Write,
            Repositories.Status,
            Repositories.Deployment,
            Repositories.Public,
            Repositories.Invite,
            Repositories.Delete,
            SecurityEvents.Write,
            RepositoryHooks.Admin,
            RepositoryHooks.Write,
            RepositoryHooks.Read,
            Organizations.Admin,
            Organizations.Write,
            Organizations.Read,
            PublicKeys.Admin,
            PublicKeys.Write,
            PublicKeys.Read,
            OrganizationHooks.Admin,
            Gists.Write,
            Notifications.Read,
            Users.Write,
            Users.Read,
            Users.Email,
            Users.Follow,
            Discussions.Write,
            Discussions.Read,
            Packages.Write,
            Packages.Read,
            Packages.Delete,
            GpgKeys.Admin,
            GpgKeys.Write,
            GpgKeys.Read,
            Workflow.Write
        };

        /// <summary>
        /// Scopes related to repositories.
        /// </summary>
        public static class Repositories {

            /// <summary>
            /// Grants full access to repositories, including private repositories. That includes read/write access to code, commit statuses, repository and organization projects, invitations, collaborators, adding team memberships, deployment statuses, and repository webhooks for repositories and organizations. Also grants ability to manage user projects.
            /// </summary>
            public static readonly GitHubScope Write = GitHubScope.RegisterScope(
                "repo",
                "Repositories: Write",
                "Grants full access to repositories, including private repositories. That includes read/write access to code, commit statuses, repository and organization projects, invitations, collaborators, adding team memberships, deployment statuses, and repository webhooks for repositories and organizations. Also grants ability to manage user projects."
            );

            /// <summary>
            /// Grants read/write access to public and private repository commit statuses. This scope is only necessary to grant other users or services access to private repository commit statuses <em>without</em> granting access to the code.
            /// </summary>
            public static readonly GitHubScope Status = GitHubScope.RegisterScope(
                "repo:status",
                "Repositories: Status",
                "Grants read/write access to public and private repository commit statuses. This scope is only necessary to grant other users or services access to private repository commit statuses <em>without</em> granting access to the code."
            );

            /// <summary>
            /// Grants access to deployment statuses for public and private repositories. This scope is only necessary to grant other users or services access to deployment statuses, <em>without</em> granting access to the code.
            /// </summary>
            public static readonly GitHubScope Deployment = GitHubScope.RegisterScope(
                "repo_deployment",
                "Repositories: Deployment",
                "Grants access to deployment statuses for public and private repositories. This scope is only necessary to grant other users or services access to deployment statuses, <em>without</em> granting access to the code."
            );

            /// <summary>
            /// Limits access to public repositories. That includes read/write access to code, commit statuses, repository projects, collaborators, and deployment statuses for public repositories and organizations. Also required for starring public repositories.
            /// </summary>
            public static readonly GitHubScope Public = GitHubScope.RegisterScope(
                "public_repo",
                "Repositories: Public",
                "Limits access to public repositories. That includes read/write access to code, commit statuses, repository projects, collaborators, and deployment statuses for public repositories and organizations. Also required for starring public repositories."
            );

            /// <summary>
            /// Grants accept/decline abilities for invitations to collaborate on a repository. This scope is only necessary to grant other users or services access to invites <em>without</em> granting access to the code.
            /// </summary>
            public static readonly GitHubScope Invite = GitHubScope.RegisterScope(
                "repo:invite",
                "Repositories: Invite",
                "Grants accept/decline abilities for invitations to collaborate on a repository. This scope is only necessary to grant other users or services access to invites <em>without</em> granting access to the code."
            );
            
            /// <summary>
            /// Grants access to delete adminable repositories.
            /// </summary>
            public static readonly GitHubScope Delete = GitHubScope.RegisterScope(
                "delete_repo",
                "Repositories: Delete",
                "Grants access to delete adminable repositories."
            );

        }

        /// <summary>
        /// Scopes related to security events.
        /// </summary>
        public static class SecurityEvents {
            
            /// <summary>
            /// Grants:
            /// read and write access to security events in the <a href="https://docs.github.com/en/rest/reference/code-scanning" target="_blank" rel="noreferrer">code scanning API</a>
            /// read and write access to security events in the <a href="https://docs.github.com/en/rest/reference/secret-scanning" target="_blank" rel="noreferrer">secret scanning API</a>
            /// This scope is only necessary to grant other users or services access to security events <em>without</em> granting access to the code.
            /// </summary>
            public static readonly GitHubScope Write = GitHubScope.RegisterScope(
                "security_events",
                "Security Events: Write",
                "Grants:\r\nread and write access to security events in the <a href=\"https://docs.github.com/en/rest/reference/code-scanning\" target=\"_blank\" rel=\"noreferrer\">code scanning API</a>\r\nread and write access to security events in the <a href=\"https://docs.github.com/en/rest/reference/secret-scanning\" target=\"_blank\" rel=\"noreferrer\">secret scanning API</a>\r\nThis scope is only necessary to grant other users or services access to security events <em>without</em> granting access to the code."
            );

        }

        /// <summary>
        /// Scopes related to repository hooks.
        /// </summary>
        public static class RepositoryHooks {

            /// <summary>
            /// Grants read, write, ping, and delete access to repository hooks in public and private repositories. The <c>repo</c> and <c>public_repo</c> scopes grant full access to repositories, including repository hooks. Use the <c>admin:repo_hook</c> scope to limit access to only repository hooks.
            /// </summary>
            public static readonly GitHubScope Admin = GitHubScope.RegisterScope(
                "admin:repo_hook",
                "Repository hooks: Admin",
                "Grants read, write, ping, and delete access to repository hooks in public and private repositories. The <code>repo</code> and <code>public_repo</code> scopes grant full access to repositories, including repository hooks. Use the <c>admin:repo_hook</c> scope to limit access to only repository hooks."
            );

            /// <summary>
            /// Grants read, write, and ping access to hooks in public or private repositories.
            /// </summary>
            public static readonly GitHubScope Write = GitHubScope.RegisterScope(
                "write:repo_hook",
                "Repository hooks: Write",
                "Grants read, write, and ping access to hooks in public or private repositories."
            );

            /// <summary>
            /// Grants read and ping access to hooks in public or private repositories.
            /// </summary>
            public static readonly GitHubScope Read = GitHubScope.RegisterScope(
                "read:repo_hook",
                "Repository hooks: Read",
                "Grants read and ping access to hooks in public or private repositories."
            );

        }

        /// <summary>
        /// Scopes related to organizations.
        /// </summary>
        public static class Organizations {

            /// <summary>
            /// Fully manage the organization and its teams, projects, and memberships.
            /// </summary>
            public static readonly GitHubScope Admin = GitHubScope.RegisterScope(
                "admin:org",
                "Organizations: Admin",
                "Fully manage the organization and its teams, projects, and memberships."
            );

            /// <summary>
            /// Read and write access to organization membership, organization projects, and team membership.
            /// </summary>
            public static readonly GitHubScope Write = GitHubScope.RegisterScope(
                "write:org",
                "Organizations: Write",
                "Read and write access to organization membership, organization projects, and team membership."
            );

            /// <summary>
            /// Read-only access to organization membership, organization projects, and team membership.
            /// </summary>
            public static readonly GitHubScope Read = GitHubScope.RegisterScope(
                "read:org",
                "Organizations: Read",
                "Read-only access to organization membership, organization projects, and team membership."
            );

        }

        /// <summary>
        /// Scopes related to public keys.
        /// </summary>
        public static class PublicKeys {
            
            /// <summary>
            /// Fully manage public keys.
            /// </summary>
            public static readonly GitHubScope Admin = GitHubScope.RegisterScope(
                "admin:public_key",
                "Public Keys: Admin",
                "Fully manage public keys."
            );

            /// <summary>
            /// Create, list, and view details for public keys.
            /// </summary>
            public static readonly GitHubScope Write = GitHubScope.RegisterScope(
                "write:public_key",
                "Public Keys: Write",
                "Create, list, and view details for public keys."
            );

            /// <summary>
            /// List and view details for public keys.
            /// </summary>
            public static readonly GitHubScope Read = GitHubScope.RegisterScope(
                "read:public_key",
                "Public Keys: Read",
                "List and view details for public keys."
            );

        }

        /// <summary>
        /// Scopes related to organization hooks.
        /// </summary>
        public static class OrganizationHooks {

            /// <summary>
            /// Grants read, write, ping, and delete access to organization hooks. <strong>Note:</strong> OAuth tokens will only be able to perform these actions on organization hooks which were created by the OAuth App. Personal access tokens will only be able to perform these actions on organization hooks created by a user.
            /// </summary>
            public static readonly GitHubScope Admin = GitHubScope.RegisterScope(
                "admin:org_hook",
                "Organization Hooks: Admin",
                "Grants read, write, ping, and delete access to organization hooks. <strong>Note:</strong> OAuth tokens will only be able to perform these actions on organization hooks which were created by the OAuth App. Personal access tokens will only be able to perform these actions on organization hooks created by a user."
            );

        }

        /// <summary>
        /// Scopes related to gists.
        /// </summary>
        public static class Gists {

            /// <summary>
            /// Grants write access to gists.
            /// </summary>
            public static readonly GitHubScope Write = GitHubScope.RegisterScope(
                "gist",
                "Gist: Write",
                "Grants write access to gists."
            );
        }

        /// <summary>
        /// Scopes related to notifications.
        /// </summary>
        public static class Notifications {

            /// <summary>
            /// Grants read access to a user’s notifications. <c>repo</c> also provides this access.
            /// </summary>
            public static readonly GitHubScope Read = GitHubScope.RegisterScope(
                "notifications",
                "Notifications",
                "Grants read access to a user’s notifications. repo also provides this access."
            );

        }

        /// <summary>
        /// Scopes related to users.
        /// </summary>
        public static class Users {

            /// <summary>
            /// Grants read/write access to profile info only. Note that this scope includes user:email and user:follow.
            /// </summary>
            public static readonly GitHubScope Write = GitHubScope.RegisterScope(
                "user",
                "User: Write",
                "Grants read/write access to profile info only. Note that this scope includes <code>user:email and <code>user:follow</code>."
            );

            /// <summary>
            /// Grants access to read a user's profile data.
            /// </summary>
            public static readonly GitHubScope Read = GitHubScope.RegisterScope(
                "read:user",
                "User: Read",
                "Grants access to read a user's profile data."
            );

            /// <summary>
            /// Grants read/write access to profile info only. Note that this scope includes user:email and user:follow.
            /// </summary>
            public static readonly GitHubScope Email = GitHubScope.RegisterScope(
                "user:email",
                "User: Email",
                "Grants read access to a user's email addresses."
            );

            /// <summary>
            /// Grants access to follow or unfollow other users.
            /// </summary>
            public static readonly GitHubScope Follow = GitHubScope.RegisterScope(
                "user:follow",
                "User: Follow",
                "Grants access to follow or unfollow other users."
            );

        }

        /// <summary>
        /// Scopes related to discussions.
        /// </summary>
        public static class Discussions {

            /// <summary>
            /// Allows read and write access for team discussions.
            /// </summary>
            public static readonly GitHubScope Write = GitHubScope.RegisterScope(
                "write:discussion",
                "Discussions: Write",
                "Allows read and write access for team discussions."
            );

            /// <summary>
            /// Allows read access for team discussions.
            /// </summary>
            public static readonly GitHubScope Read = GitHubScope.RegisterScope(
                "read:discussion",
                "Discussions: Read",
                "Allows read access for team discussions."
            );

        }

        /// <summary>
        /// Scopes related to packages.
        /// </summary>
        public static class Packages {

            /// <summary>
            /// Grants access to upload or publish a package in GitHub Packages.
            /// </summary>
            public static readonly GitHubScope Write = GitHubScope.RegisterScope(
                "write:packages",
                "Packages: Write",
                "Grants access to upload or publish a package in GitHub Packages."
            );

            /// <summary>
            /// Grants access to download or install packages from GitHub Packages.
            /// </summary>
            public static readonly GitHubScope Read = GitHubScope.RegisterScope(
                "read:packages",
                "Packages: Read",
                "Grants access to download or install packages from GitHub Packages."
            );

            /// <summary>
            /// Grants access to delete packages from GitHub Packages.
            /// </summary>
            public static readonly GitHubScope Delete = GitHubScope.RegisterScope(
                "delete:packages",
                "Packages: Delete",
                "Grants access to delete packages from GitHub Packages."
            );


        }

        /// <summary>
        /// Scopes related to GPG Keys.
        /// </summary>
        public static class GpgKeys {

            /// <summary>
            /// Fully manage GPG keys.
            /// </summary>
            public static readonly GitHubScope Admin = GitHubScope.RegisterScope(
                "admin:gpg_key",
                "GPG Keys: Admin",
                "Fully manage GPG keys."
            );

            /// <summary>
            /// Create, list, and view details for GPG keys.
            /// </summary>
            public static readonly GitHubScope Write = GitHubScope.RegisterScope(
                "write:gpg_key",
                "GPG Keys: Write",
                "Create, list, and view details for GPG keys."
            );

            /// <summary>
            /// List and view details for GPG keys.
            /// </summary>
            public static readonly GitHubScope Read = GitHubScope.RegisterScope(
                "read:gpg_key",
                "GPG Keys: Read",
                "List and view details for GPG keys."
            );

        }

        /// <summary>
        /// Scopes related to workflow.
        /// </summary>
        public static class Workflow {

            /// <summary>
            /// Grants the ability to add and update GitHub Actions workflow files. Workflow files can be committed without this scope if the same file (with both the same path and contents) exists on another branch in the same repository.
            /// </summary>
            public static readonly GitHubScope Write = GitHubScope.RegisterScope(
                "workflow",
                "Workflow: Write",
                "Grants the ability to add and update GitHub Actions workflow files. Workflow files can be committed without this scope if the same file (with both the same path and contents) exists on another branch in the same repository."
            );

        }

    }

}