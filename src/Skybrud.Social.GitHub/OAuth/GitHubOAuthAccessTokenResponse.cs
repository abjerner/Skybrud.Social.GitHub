using System;
using System.Collections.Specialized;
using Skybrud.Social.GitHub.Scopes;

namespace Skybrud.Social.GitHub.OAuth {

    public class GitHubOAuthAccessTokenResponse {

        public string AccessToken { get; private set; }

        public GitHubScopeCollection Scope { get; private set; }

        public string TokenType { get; private set; }

        public static GitHubOAuthAccessTokenResponse Parse(NameValueCollection nvc) {

            GitHubScopeCollection scopes = new GitHubScopeCollection();

            foreach (string scope in (nvc["scope"] ?? "").Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries)) {
                switch (scope) {
                    case "user": scopes.Add(GitHubScopes.User); break;
                    case "user:email": scopes.Add(GitHubScopes.UserEmail); break;
                    case "user:follow": scopes.Add(GitHubScopes.UserFollow); break;
                    case "public_repo": scopes.Add(GitHubScopes.PublicRepo); break;
                    case "repo": scopes.Add(GitHubScopes.Repo); break;
                    case "repo:status": scopes.Add(GitHubScopes.RepoStatus); break;
                    case "delete_repo": scopes.Add(GitHubScopes.DeleteRepo); break;
                    case "notifications": scopes.Add(GitHubScopes.Notifications); break;
                    case "gist": scopes.Add(GitHubScopes.Gist); break;
                    default: scopes.Add(new GitHubScope(scope)); break;
                }
            } 

            return new GitHubOAuthAccessTokenResponse {
                AccessToken = nvc["access_token"],
                Scope = scopes,
                TokenType = nvc["token_type"]
            };
        
        }

    }

}
