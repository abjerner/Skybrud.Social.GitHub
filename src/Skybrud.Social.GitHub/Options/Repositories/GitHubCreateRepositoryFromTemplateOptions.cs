using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Organizations;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Options.Repositories;

/// <summary>
/// Options for a request to create a new repository using an existing repository as template.
/// </summary>
/// <see>
///     <cref>https://developer.github.com/v3/repos/#create-repository-using-a-repository-template</cref>
/// </see>
public class GitHubCreateRepositoryFromTemplateOptions : GitHubHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the alias of the organization or person who owns the template repository.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string TemplateOwner { get; set; }
#else
    public string? TemplateOwner { get; set; }
#endif

    /// <summary>
    /// Gets or sets the slug of the template repository.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string TemplateRepository { get; set; }
#else
    public string? TemplateRepository { get; set; }
#endif

    /// <summary>
    /// Gets or sets the organization or person who will own the new repository. To create a new repository in an organization, the authenticated user must be a member of the specified organization.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string Owner { get; set; }
#else
    public string? Owner { get; set; }
#endif

    /// <summary>
    /// Gets or sets the name of the new repository.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string Name { get; set; }
#else
    public string? Name { get; set; }
#endif

    /// <summary>
    /// Gets or sets a short description of the new repository.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets whether to create a new private repository.
    /// </summary>
    public bool IsPrivate { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public GitHubCreateRepositoryFromTemplateOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="templateOwner"/>, <paramref name="templateRepository"/>, <paramref name="owner"/> and <paramref name="name"/>.
    /// </summary>
    /// <param name="templateOwner">The alias of the organization or person who owns the template repository.</param>
    /// <param name="templateRepository">The slug of the template repository.</param>
    /// <param name="owner">The organization or person who will own the new repository.</param>
    /// <param name="name">The name of the new repository.</param>
    [SetsRequiredMembers]
    public GitHubCreateRepositoryFromTemplateOptions(string templateOwner, string templateRepository, string owner, string name) {
        TemplateOwner = templateOwner;
        TemplateRepository = templateRepository;
        Owner = owner;
        Name = name;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="templateOwner"/>, <paramref name="templateRepository"/>, <paramref name="owner"/> and <paramref name="name"/>.
    /// </summary>
    /// <param name="templateOwner">The alias of the organization or person who owns the template repository.</param>
    /// <param name="templateRepository">The slug of the template repository.</param>
    /// <param name="owner">The organization or person who will own the new repository.</param>
    /// <param name="name">The name of the new repository.</param>
    /// <param name="isPrivate">Whether to create a new private repository.</param>
    [SetsRequiredMembers]
    public GitHubCreateRepositoryFromTemplateOptions(string templateOwner, string templateRepository, string owner, string name, bool isPrivate) {
        TemplateOwner = templateOwner;
        TemplateRepository = templateRepository;
        Owner = owner;
        Name = name;
        IsPrivate = isPrivate;
    }

    /// <summary>
    /// Initializes a new instance based on the specified template repository and organization owner.
    /// </summary>
    /// <param name="template">The template repository.</param>
    /// <param name="owner">The organization that should own the new repository.</param>
    /// <param name="name">The name of the new repository.</param>
    [SetsRequiredMembers]
    public GitHubCreateRepositoryFromTemplateOptions(GitHubRepositoryBase template, GitHubOrganizationBase owner, string name) {
        TemplateOwner = template.Owner.Login;
        TemplateRepository = template.Name;
        Owner = owner.Login;
        Name = name;
    }

    /// <summary>
    /// Initializes a new instance based on the specified template repository and user owner.
    /// </summary>
    /// <param name="template">The template repository.</param>
    /// <param name="owner">The user that should own the new repository.</param>
    /// <param name="name">The name of the new repository.</param>
    [SetsRequiredMembers]
    public GitHubCreateRepositoryFromTemplateOptions(GitHubRepositoryBase template, GitHubUser owner, string name) {
        TemplateOwner = template.Owner.Login;
        TemplateRepository = template.Name;
        Owner = owner.Login;
        Name = name;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns a new <see cref="IHttpRequest"/> instance for this options instance.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpRequest"/>.</returns>
    public override IHttpRequest GetRequest() {

        // Validate required parameters
        if (string.IsNullOrWhiteSpace(TemplateOwner)) throw new PropertyNotSetException(nameof(TemplateOwner));
        if (string.IsNullOrWhiteSpace(TemplateRepository)) throw new PropertyNotSetException(nameof(TemplateRepository));
        if (string.IsNullOrWhiteSpace(Owner)) throw new PropertyNotSetException(nameof(Owner));
        if (string.IsNullOrWhiteSpace(Name)) throw new PropertyNotSetException(nameof(Name));

        // Initialize the request body
        JObject body = new() {
            {"owner", Owner},
            {"name", Name},
            {"description", Description ?? string.Empty},
            {"private", IsPrivate}
        };

        // Initialize a new request
        HttpRequest request = HttpRequest.Post($"/repos/{TemplateOwner}/{TemplateRepository}/generate", body);

        // Make sure we can access the preview feature
        request.Accept = "application/vnd.github.baptiste-preview+json";

        return request;

    }

    #endregion

}