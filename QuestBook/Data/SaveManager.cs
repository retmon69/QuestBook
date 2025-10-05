using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public static class SaveManager
{
    public static async Task<List<T>> Save<T>(T newContent, string path)
    {
        string test = await File.ReadAllTextAsync(path);
        List<T> oldList = JsonSerializer.Deserialize<List<T>>(test);
        oldList.Add(newContent);
        if (!File.Exists(path))
        {
            File.Delete(path);
        }
        await File.WriteAllTextAsync(path, JsonSerializer.Serialize<List<T>>(oldList));
        return oldList;
    }

        public static async Task<T> Load<T>(string path)
    {
        if (!File.Exists(path))
        {
            File.Create(path);
        }
        return JsonSerializer.Deserialize<T>(await File.ReadAllTextAsync(path));
    }
}