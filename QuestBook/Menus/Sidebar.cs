using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using Microsoft.Xna.Framework;
using System;
using MonoGameLibrary.Input;

public class Sidebar : Menu
{
    public Border Border;
    public Sidebar(TextureAtlas atlas, ContentManager content)
    {
        Buttons = new List<Button>();
        Buttons.Add(new Button(new Border(atlas), new TextBox(content)));
        Buttons.Add(new Button(new Border(atlas), new TextBox(content)));
        Buttons.Add(new Button(new Border(atlas), new TextBox(content)));
        Buttons.Add(new Button(new Border(atlas), new TextBox(content)));
        Buttons.Add(new Button(new Border(atlas), new TextBox(content)));
        Buttons.Add(new Button(new Border(atlas), new TextBox(content)));
        Border = new Border(atlas);
    }

    public override void Draw(SpriteBatch sb, Vector2 scale, List<Action> actions)
    {
        int pos = 300;
        Border.Draw(sb, new Vector2(3, 4), new Vector2(0, pos - 65));
        for (int i = 0; i < Buttons.Count; i++)
        {
            Buttons[i].Draw(sb, new Vector2(60, pos), scale, new Vector2(10, 2), "Test1", actions[i]);
            pos = pos + 65;
        }

    }

    public override void Update(InputManager input)
    {
        for (int i = 0; i < Buttons.Count; i++)
        {
            Buttons[i].Update(input);
        }
    }
}