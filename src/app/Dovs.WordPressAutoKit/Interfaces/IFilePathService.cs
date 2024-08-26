namespace Dovs.WordPressAutoKit.Interfaces
{
    public interface IFilePathService
    {
        string GetBasePath(int levelsToTraverse);
        string GetFilePath(string defaultFilePath);
    }
}
