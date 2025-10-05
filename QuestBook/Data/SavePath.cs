using System;
using System.IO;

public static class SavePath
{
    
    public static string GetSaveFolder()
    {

        string baseDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QuestBook");
        Directory.CreateDirectory(baseDir);
        return baseDir;
    }

    public static string GetSaveFile(string fileName)
    {
        if (fileName.Contains(".json"))
            return Path.Combine(GetSaveFolder(), fileName);
        return Path.Combine(GetSaveFolder(), fileName + ".json");
    }
}
