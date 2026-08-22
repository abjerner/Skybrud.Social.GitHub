using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Options.Repositories.Labels;

/// <summary>
/// Options for creating a new label in a GitHub repository.
/// </summary>
/// <see>
///     <cref>https://docs.github.com/en/rest/reference/issues#create-a-label</cref>
/// </see>
public class GitHubCreateLabelOptions : GitHubHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the alias of the owner.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string OwnerAlias { get; set; }
#else
    public string? OwnerAlias { get; set; }
#endif

    /// <summary>
    /// Gets or sets the alias/slug of the repository.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string RepositoryAlias { get; set; }
#else
    public string? RepositoryAlias { get; set; }
#endif

    /// <summary>
    /// Gets or sets the name of the label.
    /// </summary>
#if NET8_0_OR_GREATER
    public required string Name { get; set; }
#else
    public string? Name { get; set; }
#endif

    /// <summary>
    /// Gets or sets the hexadecimal color code for the label, without the leading <c>#</c>.
    /// </summary>
    public string? Color { get; set; }

    /// <summary>
    /// Gets or sets a short description of the label.
    /// </summary>
    public string? Description { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public GitHubCreateLabelOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repositoryAlias"/> and label <paramref name="name"/>.
    /// </summary>
    /// <param name="owner">The alias of the repository owner.</param>
    /// <param name="repositoryAlias">The alias/slug of the repository.</param>
    /// <param name="name">The name of the label.</param>
    [SetsRequiredMembers]
    public GitHubCreateLabelOptions(string owner, string repositoryAlias, string name) {
        OwnerAlias = owner;
        RepositoryAlias = repositoryAlias;
        Name = name;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repositoryAlias"/> and label <paramref name="name"/>.
    /// </summary>
    /// <param name="owner">The alias of the repository owner.</param>
    /// <param name="repositoryAlias">The alias/slug of the repository.</param>
    /// <param name="name">The name of the label.</param>
    /// <param name="color">The hexadecimal color code for the label, without the leading <c>#</c>.</param>
    /// <param name="description">A short description of the label.</param>
    [SetsRequiredMembers]
    public GitHubCreateLabelOptions(string owner, string repositoryAlias, string name, string? color = null, string? description = null) {
        OwnerAlias = owner;
        RepositoryAlias = repositoryAlias;
        Name = name;
        Color = color;
        Description = description;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="repository"/> and label <paramref name="name"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="name">The name of the label.</param>
    [SetsRequiredMembers]
    public GitHubCreateLabelOptions(GitHubRepositoryBase repository, string name) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        OwnerAlias = repository.Owner.Login;
        RepositoryAlias = repository.Name;
        Name = name;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="repository"/> and label <paramref name="name"/>.
    /// </summary>
    /// <param name="repository">The repository.</param>
    /// <param name="name">The name of the label.</param>
    /// <param name="color">The hexadecimal color code for the label, without the leading <c>#</c>.</param>
    /// <param name="description">A short description of the label.</param>
    [SetsRequiredMembers]
    public GitHubCreateLabelOptions(GitHubRepositoryBase repository, string name, string? color = null, string? description = null) {
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        OwnerAlias = repository.Owner.Login;
        RepositoryAlias = repository.Name;
        Name = name;
        Color = color;
        Description = description;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        // Input validation
        if (string.IsNullOrWhiteSpace(OwnerAlias)) throw new PropertyNotSetException(nameof(OwnerAlias));
        if (string.IsNullOrWhiteSpace(RepositoryAlias)) throw new PropertyNotSetException(nameof(RepositoryAlias));
        if (string.IsNullOrWhiteSpace(Name)) throw new PropertyNotSetException(nameof(Name));

        // Initialize the POST body
        JObject body = new() {
            {"name", Name}
        };

        // Add optional parameters
        if (!string.IsNullOrWhiteSpace(Color)) body.Add("color", Color);
        if (!string.IsNullOrWhiteSpace(Description)) body.Add("description", Description);

        // Initialize a new POST request
        return HttpRequest
            .Post($"/repos/{OwnerAlias}/{RepositoryAlias}/labels", body)
            .SetAcceptHeader(MediaTypes);

    }

    #endregion

}