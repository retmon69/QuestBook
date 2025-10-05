using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Input;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;



public class TextBox : IUiElement
{
    private SpriteFont textFont;

    public string Text;
    public Rectangle SourceRectangle { get; set; }
    public Rectangle Destination { get; set; }
    public Color Color { get; set; }
    private float Scale { get; set; }
    public TextBox(ContentManager content, Rectangle sourceRectangle, Rectangle destination, string text, Color textColor)
    {
        textFont = content.Load<SpriteFont>("fonts/Arial");
        SourceRectangle = sourceRectangle;
        Destination = destination;
        Color = textColor;
        Text = text;
    }

    public void Draw(SpriteBatch sb)
    {
        Vector2 position = new Vector2(Destination.X, Destination.Y);
        sb.DrawString(textFont, Text, position, Color, 0, Vector2.Zero, Scale, SpriteEffects.None, 1);
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
    }
}