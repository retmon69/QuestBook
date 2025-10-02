using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using Microsoft.Xna.Framework;
using System;
using MonoGameLibrary.Input;

public class Sidebar : IMenu
{
    public Border Border;

    public Rectangle SourceRectangle { get; set; }
    public Rectangle Destination { get; set; }

    public List<Button> Buttons { get; set; }
    public bool Loaded { get; set; }

    public Sidebar(TextureAtlas atlas, Rectangle sourceRectangle, Rectangle destination, List<Button> buttons)
    {
        SourceRectangle = sourceRectangle;
        Destination = destination;
        Buttons = buttons;
        Border = new Border(atlas, sourceRectangle, destination);
        Loaded = false;
        AlignButtons();
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

    private void AlignButtons()
    {  
        int spacing = (int)(Destination.Height * 0.1f);
        int width = (int)(Destination.Width * 0.7f);
        int height = (int)(Destination.Height - Buttons.Count * spacing / Buttons.Count);
        Point start = new Point((int)(Destination.X + ((Destination.Width / 2)  - (width / 2))), (int)(Destination.Y * 1.1f));
        for (int i = 0; i < Buttons.Count; i++)
        {
            Buttons[i].Destination = new Rectangle(start.X, start.Y + (i * spacing), width, height);
        }
    }
}