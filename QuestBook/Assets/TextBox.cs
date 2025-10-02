using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;



public class TextBox : IUiElement
{
    private SpriteFont textFont;

    public string Text;
    public Rectangle SourceRectangle { get; set; }
    public Rectangle Destination { get; set; }
    public Color Color { get; set; }

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
        Vector2 textSize = textFont.MeasureString(Text);
        Vector2 scale = new Vector2(Destination.Width / textSize.X, Destination.Height / textSize.Y);

        sb.DrawString(textFont, Text, new Vector2(Destination.X, Destination.Y), Color, 0, Vector2.Zero, scale, SpriteEffects.None, 1);
    }
}