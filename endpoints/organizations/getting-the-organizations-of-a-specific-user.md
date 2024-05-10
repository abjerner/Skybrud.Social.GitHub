---
outdated: true
---

# Getting the organizations of a specific user

To get the public organizations of a specific user, you can use <code method="Skybrud.Social.GitHub.Endpoints.GitHubOrganizationsEndpoint.GetOrganizations">GetOrganizations</code> method along with the username of the user. For instance to get the public organizations for my GitHub user, the code could look like below:

```cshtml
@using Skybrud.Social.GitHub.Models.Organizations
@using Skybrud.Social.GitHub.Responses.Organizations
@inherits WebViewPage<Skybrud.Social.GitHub.GitHubService>

@{

    // Make the request to the API
    GitHubGetOrganizationsResponse response = Model.Organizations.GetOrganizations("abjerner");

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

The GitHub API doesn't provide a way to lookup organizations by the ID of the user.



## Pagination

The returned list of organizations is paginated, meaning that you may have to request additional pages to get all organizations the user is part of. If this is the case, you can specify an instance of <code class="Skybrud.Social.GitHub.Options.Organizations.GitHubGetUserOrganizationsOptions">GitHubGetUserOrganizationsOptions</code> with your pagination information:

```cshtml
@using Skybrud.Social.GitHub.Models.Organizations
@using Skybrud.Social.GitHub.Options.Organizations
@using Skybrud.Social.GitHub.Responses.Organizations
@inherits WebViewPage<Skybrud.Social.GitHub.GitHubService>

@{

    // The options for the request
    var options = new GitHubGetUserOrganizationsOptions {
        Username = "abjerner",
        Page = 2,
        PerPage = 1
    };

    // Make the request to the API
    GitHubGetOrganizationsResponse response = Model.Organizations.GetOrganizations(options);

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

The <code property="Skybrud.Social.GitHub.Options.Organizations.GitHubGetUserOrganizationsOptions.Page, Skybrud.Social.GitHub">Page</code> property indicates the page to be returned, where `1` indicates the first page. <code property="Skybrud.Social.GitHub.Options.Organizations.GitHubGetUserOrganizationsOptions.PerPage, Skybrud.Social.GitHub">PerPage</code> is used to indicate the maximum amount of organizations to be returned by each page.

According to the GitHub API documentation in general, paginated results will return up to 30 items by default, while some resources allow a page size of up to 100 items.