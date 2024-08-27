using System.Collections.Generic;

namespace Dovs.WordPressAutoKit.Interfaces
{
    /// <summary>
    /// Interface for Excel reader service.
    /// </summary>
    public interface IExcelReaderService
    {
        /// <summary>
        /// Reads user data from the specified Excel file.
        /// </summary>
        /// <param name="filePath">The path to the Excel file.</param>
        /// <returns>A list of user data read from the Excel file.</returns>
        List<UserData> ReadUserData(string filePath);
    }
}
