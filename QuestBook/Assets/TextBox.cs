using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;



public class TextBox
{
    private SpriteFont textFont;
    private SpriteFont titleFont;

    public TextBox(ContentManager content)
    {
        textFont = content.Load<SpriteFont>("fonts/Arial");
        titleFont = content.Load<SpriteFont>("fonts/ArialBold");
    }

    public void Draw(SpriteBatch sb, string text, Vector2 position, Color color)
    {
        sb.DrawString(textFont, text, position, color);
    }

    public void Draw(SpriteBatch sb, string title, string text, Vector2 position, Color color)
    {
        sb.DrawString(titleFont, title, position, color);
        sb.DrawString(textFont, text, new Vector2(position.X, position.Y + (titleFont.Spacing * 5)), color);
    }

    public void Draw(SpriteBatch sb, QuestInfo questInfo, Vector2 position, Color color)
    {
        sb.DrawString(titleFont, questInfo.Title, position, color);
        sb.DrawString(textFont, questInfo.Description, new Vector2(position.X, position.Y + (titleFont.Spacing * 10)), color);
    }

    public void Draw(SpriteBatch sb, QuestInfo questInfo, Vector2 position, Color color, Vector2 scale)
    {
        sb.DrawString(titleFont, questInfo.Title, position, color, 0, Vector2.One, scale, SpriteEffects.None, 1);
        sb.DrawString(textFont, questInfo.Description, new Vector2(position.X, position.Y + (titleFont.Spacing * 10)), color, 0, Vector2.One, scale, SpriteEffects.None, 1);
    }
}