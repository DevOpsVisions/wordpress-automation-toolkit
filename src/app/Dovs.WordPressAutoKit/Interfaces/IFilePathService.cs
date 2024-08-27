namespace Dovs.WordPressAutoKit.Interfaces
{
    /// <summary>
    /// Interface for file path service.
    /// </summary>
    public interface IFilePathService
    {
        /// <summary>
        /// Gets the base path by traversing the specified number of levels.
        /// </summary>
        /// <param name="levelsToTraverse">The number of levels to traverse.</param>
        /// <returns>The base path after traversing the specified levels.</returns>
        string GetBasePath(int levelsToTraverse);

        /// <summary>
        /// Gets the file path, using the default file path if necessary.
        /// </summary>
        /// <param name="defaultFilePath">The default file path to use if no other path is provided.</param>
        /// <returns>The file path to be used.</returns>
        string GetFilePath(string defaultFilePath);
    }
}
