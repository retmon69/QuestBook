using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using Microsoft.Xna.Framework;
using System;
using MonoGameLibrary.Input;
using Microsoft.Xna.Framework.Input;

public class Sidebar : IMenu
{
    public Border Border;

    public Rectangle SourceRectangle { get; set; }
    public Rectangle Destination { get; set; }

    public List<Button> Buttons { get; set; }
    public bool Loaded { get; set; }

    public Sidebar(TextureAtlas atlas, ContentManager content, Rectangle sourceRectangle, Rectangle destination, List<ButtonInfo> buttonInfos)
    {
        SourceRectangle = sourceRectangle;
        Destination = destination;
        Border = new Border(atlas, sourceRectangle, destination);
        Loaded = false;
        Buttons = new List<Button>();
        AlignButtons(buttonInfos, content, atlas);
    }

    public  void Draw(SpriteBatch sb)
    {
        Border.Draw(sb);
        for (int i = 0; i < Buttons.Count; i++)
        {
            Buttons[i].Draw(sb);
        }

    }

    public void Update(InputManager input)
    {
        for (int i = 0; i < Buttons.Count; i++)
        {
            Buttons[i].Update(input);
        }
    }

    private void AlignButtons(List<ButtonInfo> buttonInfos, ContentManager content, TextureAtlas atlas)
    {
        float bla = Destination.Height / Border.BorderSize.Y / 128;
        int borderLength = (int)(50 * bla);
        int height = (int)((Destination.Height - (2 * borderLength)) / buttonInfos.Count * 0.75);
        int spacing = (int)((Destination.Height - (2 * borderLength)) / buttonInfos.Count * 0.25);
        int width = (int)(Destination.Width * 0.65f);
        
        Point start = new Point((int)(Destination.X + ((Destination.Width / 2) - (width / 2))), (int)(Destination.Y + borderLength));
        for (int i = 0; i < buttonInfos.Count; i++)
        {
            Buttons.Add(new Button(content, atlas, SourceRectangle, new Rectangle(start.X, start.Y + (i * (spacing + height)), width, height), buttonInfos[i].Text, Color.Black, buttonInfos[i].OnClick));
        }
    }
}