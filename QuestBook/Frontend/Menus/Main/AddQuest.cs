using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using Microsoft.Xna.Framework;
using System;
using MonoGameLibrary.Input;

public class AddQuest : IMenu
{
    public Border Border { get; set; }
    public TextInput Title { get; set; }
    public TextInput Description { get; set; }
    public List<Button> Buttons { get; set; }
    public bool Loaded { get; set; }
    public Rectangle SourceRectangle { get; set; }
    public Rectangle Destination { get; set; }

    public AddQuest(TextureAtlas atlas, ContentManager content, List<Button> buttons, Rectangle sourceRectangle, Rectangle destination)
    {
        Border = new Border(atlas, sourceRectangle, destination);
        Buttons = buttons;
        Loaded = false;
        SourceRectangle = sourceRectangle;
        Destination = destination;
        Title = new TextInput(content, atlas, sourceRectangle, new Rectangle(Destination.X + 60, Destination.Y + 50, (int)(Destination.Width * 0.7), (int)(Destination.Height * 0.1)), Color.Black);
        Title.ChangeTextSize(20);
        Description = new TextInput(content, atlas, sourceRectangle, new Rectangle(Destination.X + 60, Destination.Y + 150, (int)(Destination.Width * 0.7), (int)(Destination.Height * 0.6)), Color.Black);
        Description.ChangeTextSize(15);
        
    }

    public void Draw(SpriteBatch sb)
    {
        Border.Draw(sb);    
        Title.Draw(sb);
        Description.Draw(sb);
    }

    public void Update(InputManager input, GameWindow gameWindow)
    {
        Title.Update(input, gameWindow);
        Description.Update(input, gameWindow);

    }
}