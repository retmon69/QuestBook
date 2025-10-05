using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using Microsoft.Xna.Framework;
using MonoGameLibrary.Input;
using System;

public class MenuManager
{
    public List<ButtonInfo> NavigationInfos;
    public List<QuestInfo> QuestInfos;


    public Sidebar Sidebar;
    public QuestOverview QuestOverview;

    public AddQuest AddQuest;

    public DataTransferManager DataTransferManager;

    public MenuManager(TextureAtlas atlas, ContentManager content)
    {
        DataTransferManager = new DataTransferManager();
        NavigationInfos =
        [
            new ButtonInfo(() => QuestOverview.Loaded = !QuestOverview.Loaded, "Quests"),
            new ButtonInfo(() => AddQuest.Loaded = !AddQuest.Loaded, "AddQuest"),
            new ButtonInfo(() => QuestOverview.Loaded = !QuestOverview.Loaded, "Quests3"),
            new ButtonInfo(() => QuestOverview.Loaded = !QuestOverview.Loaded, "Quests4"),
            new ButtonInfo(() => QuestOverview.Loaded = !QuestOverview.Loaded, "Quests5"),

        ];

        QuestInfos =
        [
            new QuestInfo("Title", "Description"),
            new QuestInfo("Title2", "Description2"),
            new QuestInfo("Title3", "Description3"),
            new QuestInfo("Title4", "Description4"),
            new QuestInfo("Title5", "Description5"),
            new QuestInfo("Title6", "Description6"),
            new QuestInfo("Title7", "Description7"),
            new QuestInfo("Title8", "Description8"),
            new QuestInfo("Title9", "Description9"),
        ];


        Sidebar = new Sidebar(atlas, content, new Rectangle(0, 112, 500, 800), new Rectangle(0, 162, 400, 700), NavigationInfos);
        QuestOverview = new QuestOverview(atlas, content, QuestInfos, new List<Button>(), new Rectangle(600, 20, 1360, 980), new Rectangle(425, 20, 1470, 980));
        AddQuest = new AddQuest(atlas, content, new List<Button>(), new Rectangle(), new Rectangle(425, 20, 1470, 980));
    }

    public void Draw(SpriteBatch sb)
    {
        Sidebar.Draw(sb);
        if (QuestOverview.Loaded)
        {
            QuestOverview.Draw(sb);
        }
        if (AddQuest.Loaded)
        {
            AddQuest.Draw(sb);
        }
        
    }
    public void Update(InputManager input, GameWindow gameWindow)
    {
        Sidebar.Update(input);
        if (QuestOverview.Loaded)
        {
            QuestOverview.Update(input);
        }
        if (AddQuest.Loaded)
        {
            AddQuest.Update(input,gameWindow);
        }
    }
}