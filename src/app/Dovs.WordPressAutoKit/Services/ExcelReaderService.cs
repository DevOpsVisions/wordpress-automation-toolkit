using Dovs.WordPressAutoKit.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using ExcelDataReader;

namespace Dovs.WordPressAutoKit.Services
{
    public class ExcelReaderService : IExcelReaderService
    {
        public List<UserData> ReadUserDataFromExcel(string filePath)
        {
            List<UserData> userDataList = new List<UserData>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            string userNameColumn = ConfigurationManager.AppSettings["UserNameColumn"];
            string emailColumn = ConfigurationManager.AppSettings["EmailColumn"];
            string membershipColumn = ConfigurationManager.AppSettings["MembershipColumn"];

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
                            header[reader.GetValue(i).ToString()] = i;
                        }

                        if (!header.ContainsKey(userNameColumn) || !header.ContainsKey(emailColumn) || !header.ContainsKey(membershipColumn))
                        {
                            throw new Exception($"Required columns '{userNameColumn}', '{emailColumn}', or '{membershipColumn}' not found in Excel file.");
                        }

                        isHeaderProcessed = true;
                        continue;
                    }

                    string userName = reader.GetValue(header[userNameColumn])?.ToString();
                    string email = reader.GetValue(header[emailColumn])?.ToString();
                    string membership = reader.GetValue(header[membershipColumn])?.ToString();

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
