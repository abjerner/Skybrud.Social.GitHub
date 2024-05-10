---
outdated: true
---

# Getting the organizations of the authenticated user

Assuming your app has the necessary authorization, you can use `GetOrganizations` method to request a list of the organizations the authenticated user is a part of:

```cshtml
@using Skybrud.Social.GitHub.Models.Organizations
@using Skybrud.Social.GitHub.Responses.Organizations
@inherits WebViewPage<Skybrud.Social.GitHub.GitHubService>

@{

    // Make the request to the API
    GitHubGetOrganizationsResponse response = Model.Organizations.GetOrganizations();

    // Get the organizations from the response body
    GitHubOrganizationItem[] body = response.Body;

    // Iterate through the organizations
    foreach (GitHubOrganizationItem org in body) {
        <p>ID: @org.Id</p>
        <p>Login: @org.Login</p>
        <br />
    }

}
```

As the response from the GitHub API is a list of organizations, the returned JSON will contain fewer properties for each organizations compared to when requesting a single organization. As a result of this, each organization in the list is represented by the `GitHubOrganizationItem` class (opposed to the `GitHubOrganizationItem` class when [getting a single organization](./getting-a-single-organization.md)).



## Pagination

The returned list of organizations is paginated, meaning that you may have to request additional pages to get all organizations the authenticated user is part of. If this is the case, you can specify an instance of `GitHubGetOrganizationsOptions` with your pagination information:

```cshtml
@using Skybrud.Social.GitHub.Models.Organizations
@using Skybrud.Social.GitHub.Options.Organizations
@using Skybrud.Social.GitHub.Responses.Organizations
@inherits WebViewPage<Skybrud.Social.GitHub.GitHubService>

@{

    // Make the request to the API
    GitHubGetOrganizationsResponse response = Model.Organizations.GetOrganizations(new GitHubGetOrganizationsOptions {
        Page = 2,
        PerPage = 10
    });

    // Get the organizations from the response body
    GitHubOrganizationItem[] body = response.Body;

    // Iterate through the organizations
    foreach (GitHubOrganizationItem org in body) {
        <p>ID: @org.Id</p>
        <p>Login: @org.Login</p>
        <br />
    }

}
```

The `Page` property indicates the page to be returned, where `1` is the first page. `PerPage` is used to indicate the maximum amount of organizations to be returned by each page.

According to the GitHub API documentation in general, paginated results will return up to 30 items by default, while some resources allow a page size of up to 100 items.