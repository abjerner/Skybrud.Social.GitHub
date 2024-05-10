---
outdated: true
---

# Media Types

When making requests to the GitHub API, you can specify one or more media type via the **Accept** header. This can be used to either make the GitHub API respond in a specific format, or to enable certain preview/beta features that are otherwise not public.

## Enable preview features

As an example, draft pull requests are currently in beta, so querying the GitHub API for pull requests of a given repository won't expose whether the PRs are in draft mode or not.

But by setting the **Accept** header to `application/vnd.github.shadow-cat-preview+json`, the API will now expose a `draft` property in the JSON for each pull request. The exact media type may be difficult to remember, so this package lets you use the `GitHubMediaTypes.DraftPullRequestApiPreview` constant instead of the raw string value.

You may specify more than one media type, so this can be done by setting the `MediaType` property with a list contaning the desired media types:

```cshtml
@using Skybrud.Social.GitHub.Constants
@using Skybrud.Social.GitHub.Options
@using Skybrud.Social.GitHub.Options.PullRequests
@using Skybrud.Social.GitHub.Options.Repositories
@using Skybrud.Social.GitHub.Responses.PullRequests
@inherits WebViewPage<Skybrud.Social.GitHub.GitHubService>

@{

    // Initialize the options
    GitHubGetPullRequestsOptions options = new GitHubGetPullRequestsOptions("Umbraco", "OurUmbraco") {
        MediaTypes = new List<string> { GitHubMediaTypes.DraftPullRequestApiPreview },
        Sort = GitHubPullRequestSortField.Created,
        Direction = GitHubSortDirection.Descending,
        PerPage = 10
    };

    // Make the request to the GitHub API
    GitHubGetPullRequestsResponse response = Model.PullRequests.GetPullRequests(options);

}
```

Alternatively you can use the `AddMediaType` extension method to add the media type after the options instance have been initialized:

```cshtml
@using Skybrud.Social.GitHub.Constants
@using Skybrud.Social.GitHub.Extensions
@using Skybrud.Social.GitHub.Options
@using Skybrud.Social.GitHub.Options.PullRequests
@using Skybrud.Social.GitHub.Options.Repositories
@using Skybrud.Social.GitHub.Responses.PullRequests
@inherits WebViewPage<Skybrud.Social.GitHub.GitHubService>

@{

    // Initialize the options
    GitHubGetPullRequestsOptions options = new GitHubGetPullRequestsOptions("Umbraco", "OurUmbraco") {
        Sort = GitHubPullRequestSortField.Created,
        Direction = GitHubSortDirection.Descending,
        PerPage = 10
    };

    // Add the "shadow cat" media type
    options.AddMediaType(GitHubMediaTypes.DraftPullRequestApiPreview);

    // Make the request to the GitHub API
    GitHubGetPullRequestsResponse response = Model.PullRequests.GetPullRequests(options);

}
```