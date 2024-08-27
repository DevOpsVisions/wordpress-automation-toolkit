
using Dovs.WordPressAutoKit.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using ExcelDataReader;

namespace Dovs.WordPressAutoKit.Services
{
    /// <summary>  
    /// Service for reading user data from an Excel file.  
    /// </summary>  
    public class ExcelReaderService : IExcelReaderService
    {
        private readonly IConfigurationService _configurationService;

        /// <summary>  
        /// Initializes a new instance of the <see cref="ExcelReaderService"/> class.  
        /// </summary>  
        /// <param name="configurationService">The configuration service.</param>  
        public ExcelReaderService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        /// <summary>  
        /// Reads user data from the specified Excel file.  
        /// </summary>  
        /// <param name="filePath">The path to the Excel file.</param>  
        /// <returns>A list of user data read from the Excel file.</returns>  
        /// <exception cref="Exception">Thrown when required columns are not found or no user data is found.</exception>  
        public List<UserData> ReadUserData(string filePath)
        {
            var userDataList = new List<UserData>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var userNameColumn = _configurationService.GetConfigValue("UserNameColumn");
            var emailColumn = _configurationService.GetConfigValue("EmailColumn");
            var membershipColumn = _configurationService.GetConfigValue("MembershipColumn");

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var header = new Dictionary<string, int>();
                bool isHeaderProcessed = false;

                while (reader.Read())
                {
                    if (!isHeaderProcessed)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            var columnName = reader.GetValue(i)?.ToString();
                            if (!string.IsNullOrEmpty(columnName))
                            {
                                header[columnName] = i;
                            }
                        }

                        if (!header.ContainsKey(userNameColumn) || !header.ContainsKey(emailColumn) || !header.ContainsKey(membershipColumn))
                        {
                            throw new Exception($"Required columns '{userNameColumn}', '{emailColumn}', or '{membershipColumn}' not found in Excel file.");
                        }

                        isHeaderProcessed = true;
                        continue;
                    }

                    var userName = reader.GetValue(header[userNameColumn])?.ToString();
                    var email = reader.GetValue(header[emailColumn])?.ToString();
                    var membership = reader.GetValue(header[membershipColumn])?.ToString();

                    if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(membership))
                    {
                        userDataList.Add(new UserData(userName, email, membership));
                    }
                }
            }

            if (userDataList.Count == 0)
            {
                throw new Exception("No user data found in Excel.");
            }

            return userDataList;
        }
    }
}