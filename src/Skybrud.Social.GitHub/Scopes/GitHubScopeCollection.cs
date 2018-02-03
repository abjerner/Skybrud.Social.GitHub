using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.GitHub.Scopes {

    /// <summary>
    /// Class representing a collection of scopes of the GitHub API.
    /// </summary>
    public class GitHubScopeCollection : IEnumerable<GitHubScope> {

        #region Private fields

        private readonly List<GitHubScope> _list = new List<GitHubScope>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets an array of all scopes added to the collection.
        /// </summary>
        public GitHubScope[] Items => _list.ToArray();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new collection with the specified array of <paramref name="scopes"/>.
        /// </summary>
        /// <param name="scopes">The array of scopes the collection should be based on.</param>
        public GitHubScopeCollection(params GitHubScope[] scopes) {
            _list.AddRange(scopes);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Adds the specified <paramref name="scope"/> to the collection.
        /// </summary>
        /// <param name="scope">The scope to be added.</param>
        public void Add(GitHubScope scope) {
            _list.Add(scope);
        }

        /// <summary>
        /// Converts the collection of scopes into an array of <see cref="GitHubScope"/>.
        /// </summary>
        /// <returns>Returns an array of <see cref="GitHubScope"/>.</returns>
        public GitHubScope[] ToArray() {
            return _list.ToArray();
        }

        /// <summary>
        /// Returns a string array representing the collection.
        /// </summary>
        /// <returns>Returns an array of <see cref="String"/>.</returns>
        public string[] ToStringArray() {
            return (from scope in _list where scope.Name.Length > 0 select scope.Name).ToArray();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<GitHubScope> GetEnumerator() {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Returns a string representation of the collection. The string will consist of the names of scopes added to
        /// the collection, each separated by a comma.
        /// </summary>
        /// <returns>Returns a string representation of the collection.</returns>
        public override string ToString() {
            return String.Join(",", ToStringArray());
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new collection based on a single <paramref name="scope"/>.
        /// </summary>
        /// <param name="scope">The scope the collection should be based on.</param>
        /// <returns>Returns a new collection based on a single <paramref name="scope"/>.</returns>
        public static implicit operator GitHubScopeCollection(GitHubScope scope) {
            return new GitHubScopeCollection(scope);
        }

        /// <summary>
        /// Initializes a new collection based on the specified <paramref name="array"/> of scopes.
        /// </summary>
        /// <param name="array">The array the collection should be based on.</param>
        /// <returns>Returns a new instance of <see cref="GitHubScopeCollection"/>.</returns>
        public static implicit operator GitHubScopeCollection(GitHubScope[] array) {
            return new GitHubScopeCollection(array ?? new GitHubScope[0]);
        }

        /// <summary>
        /// Adds the specified <paramref name="scope"/> to <paramref name="collection"/>.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="scope">The scope to be added.</param>
        /// <returns>Returns the collection.</returns>
        public static GitHubScopeCollection operator +(GitHubScopeCollection collection, GitHubScope scope) {
            collection.Add(scope);
            return collection;
        }

        #endregion

    }

}