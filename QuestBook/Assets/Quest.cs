using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using Microsoft.Xna.Framework;
using MonoGameLibrary;

public class Quest
{
    public Border Border;
    public TextBox TextBox;

    public Vector2 Position;

    public Quest(ContentManager content, TextureAtlas atlas)
    {
        Border = new Border(atlas);
        TextBox = new TextBox(content);
        Position = new Vector2();
    }

    public void Draw(SpriteBatch sb, Vector2 position, QuestInfo questInfo, Vector2 borderSize)
    {
        Border.Draw(sb, borderSize, position);
        TextBox.Draw(sb, questInfo, new Vector2(position.X + 64, position.Y + 64), Color.BurlyWood);
        Position = position;
    }

    public void Draw(SpriteBatch sb, Vector2 position, QuestInfo questInfo, Vector2 borderSize, Vector2 scale)
    {
        Border.Draw(sb, borderSize, position, scale);
        TextBox.Draw(sb, questInfo, new Vector2(position.X + (64 * scale.X), position.Y + (64 * scale.Y)), Color.BurlyWood, scale);
        Position = position * scale;
    }
        public void DrawClipped(SpriteBatch sb, Vector2 position, QuestInfo questInfo, Vector2 borderSize, Vector2 scale, Rectangle clipRect)
    {
        Border.DrawClipped(sb, borderSize, position, scale, clipRect);

        Texture2D textTex = TextBox.RenderTextToTexture(Core.GraphicsDevice, questInfo, Color.BurlyWood, scale);
        TextureRegion region = new TextureRegion(textTex, 0, 0, textTex.Width, textTex.Height);
        Sprite sprite = new Sprite(region);

        Vector2 textPos = new Vector2(position.X + (64 * scale.X), position.Y + (64 * scale.Y));

        sprite.DrawClipped(sb, textPos, Vector2.One, clipRect); // Scale schon im Texture gerendert
        Position = position * scale;
    }
}