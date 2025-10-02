using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using Microsoft.Xna.Framework;
using MonoGameLibrary.Input;
using System;

public class MenuManager
{
    public List<Action> links;
    public Sidebar sidebar;
    public bool test;

    public QuestOverview questOverview;

    public MenuManager(TextureAtlas atlas, ContentManager content)
    {
        sidebar = new Sidebar(atlas, content);
        questOverview = new QuestOverview(atlas, content);
        links = new List<Action>();
        links.Add(() => questOverview.Loaded = sidebar.Buttons[0].Active);
        links.Add(() => test = sidebar.Buttons[1].Active);
        links.Add(() => test = sidebar.Buttons[2].Active);
        links.Add(() => test = sidebar.Buttons[3].Active);
        links.Add(() => test = sidebar.Buttons[4].Active);
        links.Add(() => test = sidebar.Buttons[5].Active);
    }

    public void Draw(SpriteBatch sb)
    {
        sidebar.Draw(sb, new Vector2(0.2f,0.2f), links);
        if (questOverview.Loaded)
        {
            questOverview.Draw(sb, new Vector2(0.5f,0.5f), new List<Action>());
        }
        
    }
    public void Update(InputManager input)
    {
        sidebar.Update(input);
        if (questOverview.Loaded)
        {
            questOverview.Update(input);
        }
    }
}