using System;
using Skybrud.Social.GitHub.Models.Issues;

namespace Skybrud.Social.GitHub.Options.Issues.Comments {

    /// <summary>
    /// Class representing the options for adding a comment to a GitHub issue.
    /// </summary>
    public class GitHubAddIssueCommentOptions {

        #region Properties
        
        /// <summary>
        /// Mandatory: Gets or sets the username (login) of the owner of the repository.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Mandatory: Gets or sets the slug of the repository.
        /// </summary>
        public string Repository { get; set; }

        /// <summary>
        /// Gets or sets the number of the issue to which the comment should be added.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the Markdown-based body of the comment.
        /// </summary>
        /// <see>
        ///     <cref>https://guides.github.com/features/mastering-markdown/</cref>
        /// </see>
        public string Body { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public GitHubAddIssueCommentOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="owner"/>, <paramref name="repository"/>,
        /// <paramref name="number"/> and <paramref name="body"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="number">The number of the issue.</param>
        /// <param name="body">The Markdown-based body of the comment.</param>
        public GitHubAddIssueCommentOptions(string owner, string repository, int number, string body) {
            Owner = owner;
            Repository = repository;
            Number = number;
            Body = body;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="issue"/> and <paramref name="body"/>.
        /// </summary>
        /// <param name="issue">The issue to which the comment will be added.</param>
        /// <param name="body">The Markdown-based body of the comment.</param>
        public GitHubAddIssueCommentOptions(GitHubIssue issue, string body) {
            if (issue == null) throw new ArgumentNullException(nameof(issue));
            Owner = issue.Repository.Owner.Login;
            Repository = issue.Repository.Name;
            Number = issue.Number;
            Body = body;
        }

        #endregion

    }

}