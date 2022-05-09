namespace Skybrud.Social.GitHub.GraphQl.Models {

    /// <summary>
    /// Describes an object with an ID.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/graphql/reference/interfaces#node</cref>
    /// </see>
    public interface INode {

        /// <summary>
        /// Gets the ID of the object.
        /// </summary>
        public string Id { get; }

    }

}