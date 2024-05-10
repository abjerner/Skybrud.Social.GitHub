---
outdated: true
---

# Getting a single organization

Using the `GetOrganization` method, you can specify the login (or username if you will) to get information about a specific organization. As show below, the method returns an instance of `GitHubOrganization`:

```cshtml
@using Skybrud.Social.GitHub.Models.Organizations
@using Skybrud.Social.GitHub.Responses.Organizations
@inherits WebViewPage<Skybrud.Social.GitHub.GitHubService>

@{

    // Make the request to the API
    GitHubGetOrganizationResponse response = Model.Organizations.GetOrganization("skybrud");

    // Get the organization from the response body
    GitHubOrganization organization = response.Body;

    <p>ID: @organization.Id</p>
    <p>Login: @organization.Login</p>
    <p>Name: @organization.Name</p>

}
```

While an organization also has an ID, the GitHub API provides no way of looking up an organization by it's ID.