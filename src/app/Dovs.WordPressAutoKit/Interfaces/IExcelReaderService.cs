﻿using System.Collections.Generic;

namespace Dovs.WordPressAutoKit.Interfaces
{
    public interface IExcelReaderService
    {
        List<UserData> ReadUserData(string filePath);
    }
}
