using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class QuestData
{
    public List<QuestInfo> Quests;
    public string Path = SavePath.GetSaveFile("quests.json");
}