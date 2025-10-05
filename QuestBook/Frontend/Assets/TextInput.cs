using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;



public class TextInput : IUiElement
{
    public Border Border;
    private SpriteFont textFont;

    public bool Active;
    public string Text;
    public Rectangle SourceRectangle { get; set; }
    public Rectangle Destination { get; set; }
    public Color Color { get; set; }

    private int MaxTextRows { get; set; }
    private float Scale { get; set; }

    private List<string> displayText { get; set; }

    public TextInput(ContentManager content, TextureAtlas atlas, Rectangle sourceRectangle, Rectangle destination, Color textColor)
    {
        Border = new Border(atlas, sourceRectangle, destination);
        textFont = content.Load<SpriteFont>("fonts/Arial");
        SourceRectangle = sourceRectangle;
        int borderSizeX = (int)(60 * (destination.Width / Border.BorderSize.X / 128f));
        int borderSizeY = (int)(60 * (destination.Height / Border.BorderSize.Y / 128f));
        Destination = new Rectangle(destination.X + borderSizeX, destination.Y + borderSizeY, destination.Width - (2 * borderSizeX), destination.Height - (2 * borderSizeY));
        Color = textColor;
        Text = "";
        displayText = new List<string>(); ;
        displayText.Add(Text);
        Scale = 1;
        MaxTextRows = (int)Math.Round(Destination.Height / (textFont.MeasureString("T").Y + textFont.Spacing), MidpointRounding.ToZero);
    }

    public void Draw(SpriteBatch sb)
    {
        Border.Draw(sb);
        for (int i = 0; i < displayText.Count; i++)
        {
            Vector2 position = new Vector2(Destination.X, Destination.Y + ((textFont.MeasureString(displayText[i]).Y * Scale + (textFont.Spacing * Scale)) * i));
            sb.DrawString(textFont, displayText[i], position, Color, 0, Vector2.Zero, Scale, SpriteEffects.None, 1);
        }
    }

    public void Center(Rectangle parentDestination)
    {
        Destination = new Rectangle(Destination.X + ((parentDestination.Width / 2) - (int)(Destination.Width / 2)), Destination.Y + (int)((parentDestination.Height / 2) - (Destination.Height / 2)), Destination.Width, Destination.Height);
    }

    public void ScaleTextToContainer()
    {
        Vector2 textSize = textFont.MeasureString(Text);
        Vector2 scale = new Vector2(Destination.Width / textSize.X, Destination.Height / textSize.Y);
        if (scale.X <= scale.Y)
            Scale = scale.X;
        else
            Scale = scale.Y;

        Destination = new Rectangle(Destination.X, Destination.Y, (int)(textSize.X * Scale), (int)(textSize.Y * Scale));
    }

    public void ChangeTextSize(float size)
    {
        Scale = size / 100;
        var realTextHeight = (textFont.MeasureString("S").Y * Scale) + (textFont.Spacing * Scale);
        var ratio = size / realTextHeight;
        MaxTextRows = (int)Math.Round(Destination.Height / ((textFont.MeasureString("S").Y * Scale) + (textFont.Spacing * Scale)), MidpointRounding.ToZero);
        Scale = Destination.Height / MaxTextRows / 100f * ratio; 
    }

    private void Write(InputManager input, GameWindow gameWindow)
    {
        input.Keyboard.Hook(gameWindow);
        while (input.Keyboard.TryDequeueChar(out var ch))
        {
            
            var displaySize = textFont.MeasureString(displayText[displayText.Count - 1] + ch) * Scale;

            if (displaySize.X > Destination.Width && MaxTextRows > displayText.Count)
            {
                displayText.Add("");
            }

            if (displaySize.X < Destination.Width && MaxTextRows >= displayText.Count)
            {
                displayText[displayText.Count - 1] += ch;
                Text += ch;
            }
        }


        if (input.Keyboard.WasKeyJustPressed(Keys.Back) && Text.Length > 0)
        {
            if (string.IsNullOrEmpty(displayText[displayText.Count - 1]))
            {
                displayText.RemoveAt(displayText.Count - 1);
            }
            Text = Text[..^1];
            displayText[displayText.Count - 1] = displayText[displayText.Count - 1][..^1];
        }
    }
    
    public void Update(InputManager input, GameWindow gameWindow)
    {
        if (Destination.Contains(input.Mouse.Position) && input.Mouse.WasButtonJustPressed(MouseButton.Left))
        {
            Active = true;
        }
        else if (!Destination.Contains(input.Mouse.Position) && input.Mouse.WasButtonJustPressed(MouseButton.Left))
        {
            Active = false;
        }
        if (Active)
        {
            Write(input, gameWindow);
        }

    }
}