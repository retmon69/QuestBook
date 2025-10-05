using System.Collections.Generic;
using System.Threading.Tasks;

public class DataTransferManager
{

    public QuestData QuestData;

    public DataTransferManager()
    {
        QuestData = new QuestData();
    }

    public async Task<List<QuestInfo>> GetQuests() => await SaveManager.Load<List<QuestInfo>>(QuestData.Path);
    public async Task SaveQuest(QuestInfo questData) => await SaveManager.Save<QuestInfo>(questData, QuestData.Path);
        
}