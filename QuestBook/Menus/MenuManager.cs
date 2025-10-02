using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using Microsoft.Xna.Framework;
using MonoGameLibrary.Input;
using System;

public class MenuManager
{
    public List<Button> Links;
    public List<Quest> Quests;
    public Sidebar Sidebar;
    public QuestOverview QuestOverview;

    public MenuManager(TextureAtlas atlas, ContentManager content)
    {
        Links =
        [
            new Button(content, atlas, new Rectangle(0, 112, 500, 800), new Rectangle(0, 112, 500, 800), "Quests", Color.Black, () => QuestOverview.Loaded = !QuestOverview.Loaded),
        ];

        Quests =
        [
                new Quest(content, atlas, new Rectangle(600, 20, 1360, 980), new Rectangle(600, 20, 1360, 980), "Test", Color.White),
        ];


        Sidebar = new Sidebar(atlas, new Rectangle(0, 112, 500, 800), new Rectangle(0, 112, 500, 800), Links);
        QuestOverview = new QuestOverview(atlas, content, Quests, new List<Button>(), new Rectangle(600, 20, 1360, 980), new Rectangle(600, 20, 1360, 980));

    }

    public void Draw(SpriteBatch sb)
    {
        Sidebar.Draw(sb);
        if (QuestOverview.Loaded)
        {
            QuestOverview.Draw(sb);
        }
        
    }
    public void Update(InputManager input)
    {
        Sidebar.Update(input);
        if (QuestOverview.Loaded)
        {
            QuestOverview.Update(input);
        }
    }
}