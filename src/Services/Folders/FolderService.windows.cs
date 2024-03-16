namespace PolyhydraGames.Core.Console.Services.Folders
{
    public class FolderService : IStorageFolder
    {
        public string Get()
        {
            var path = "c:\\temp";
            return path;
        }
    }
}