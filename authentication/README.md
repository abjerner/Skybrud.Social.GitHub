# Authentication

To get started, you should [**Register a new OAuth application** at github.com](https://github.com/settings/applications/new). Once registered, you will get a client ID and a client secret that is specific to your app. You should also specify a redirect URI, which is the URI the user is redirected back to after a successful (or failed) authentication.

The example below illustrates how to authenticate users from a Razor file. The file initially shows a login button, which when clicked, redirects the user to github.com for further authentication.

When the user completes (or cancels) the authentication, they are redirected back the login page. If successful, the access token of the user is printed on the screen.

```cshtml
@using Skybrud.Social.GitHub.OAuth
@using Skybrud.Social.GitHub.Responses.Authentication
@using Skybrud.Social.GitHub.Scopes
@inherits WebViewPage

@{
    
    // Initialize a new instance of the OAuth client
    GitHubOAuthClient client = new GitHubOAuthClient {
        ClientId = "Your client ID",
        ClientSecret = "Your client secret",
        RedirectUri = "Your redirect URI"
    };
    
    // Read some input from the query string
    string code = Request.QueryString["code"];
    string state = Request.QueryString["state"];
    string action = Request.QueryString["do"];
    string error = Request.QueryString["error"];
    string errorDescription = Request.QueryString["error_description"];

    // Handle the state when the user clicks our login button
    if (action == "login") {

        // Generate a random scope
        state = Guid.NewGuid().ToString();

        // Generate the session key for the state
        string stateKey = "GitHubOAuthState_" + state;

        // Store the state in the session of the user
        Session[stateKey] = Request.RawUrl;

        // Declare a list of scopes to request from the user
        GitHubScopeCollection scopes = new GitHubScopeCollection {
            GitHubScopes.User,
            GitHubScopes.UserEmail
        };

        // Generate the authorization URL
        string authorizationUrl = client.GetAuthorizationUrl(state, scopes);

        // Redirect the user
        Response.Redirect(authorizationUrl);

    } else if (!string.IsNullOrWhiteSpace(error)) {

        // Remove the session
        if (state != null) {
            Session.Remove("GitHubOAuthState_" + state);
        }

        // Print out the error
        <div class="alert alert-danger"><strong>@error</strong><br />@errorDescription</div>

        return;

    } else if (Request.QueryString["code"] != null) {

        // Generate the session key for the state
        string stateKey = "GitHubOAuthState_" + state;

        if (Session[stateKey] == null) {
            <p>Has your session expired?</p>
            <p>
                <a class="btn btn-default" href="?do=login">Re-try login</a>
            </p>
            return;
        }

        GitHubTokenResponse response = client.GetAccessTokenFromAuthorizationCode(code);

        <p><strong>Access Token</strong></p>
        <textarea>@(string.IsNullOrWhiteSpace(response.Body.AccessToken) ? "Empty" : response.Body.AccessToken)</textarea>

        return;

    }

    <p>
        <a class="btn btn-default" href="?do=login">Login with GitHub</a>
    </p>

}
```

The Razor file serves as a great example for illustrating the various steps involved in the OAuth authentication, but ideally most of this logic should be moved to a MVC controller instead. And the app information - especially the client secret - should be added as constants or similar.