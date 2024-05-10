---
outdated: true
---

# Getting a single repository

You can look up a specific repository by the username of the parent user/organization and the name of the repository through the <code method="Skybrud.Social.GitHub.Endpoints.GitHubRepositoriesEndpoint.GetRepository">GetRepository</code> method like shown below:

```cshtml
@using Skybrud.Social.GitHub.Models.Repositories
@using Skybrud.Social.GitHub.Responses.Repositories
@inherits WebViewPage<Skybrud.Social.GitHub.GitHubService>

@{

    // Make the request to the API
    GitHubGetRepositoryResponse response = Model.Repositories.GetRepository("abjerner", "Skybrud.Social");

    // Get the repository from the response body
    GitHubRepository repository = response.Body;

    <p>ID: @repository.Id</p>
    <p>Name: @repository.Name</p>

}
```

The method will return an instance of <code class="Skybrud.Social.GitHub.Responses.Repositories.GitHubGetRepositoryResponse, Skybrud.Social.GitHub">GitHubGetRepositoryResponse</code> that represents the entire response received from the GitHub API. In this instance, the `Body` property exposes the repository information as an instance of <code class="Skybrud.Social.GitHub.Models.Repositories.GitHubRepository, Skybrud.Social.GitHub">GitHubRepository</code>.