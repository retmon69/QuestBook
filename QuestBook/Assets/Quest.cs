using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using Microsoft.Xna.Framework;
using MonoGameLibrary;

public class Quest : IUiElement
{
    public Border Border;
    public TextBox TextBox;

    public Rectangle SourceRectangle { get; set; }
    public Rectangle Destination { get; set; }


    public Quest(ContentManager content, TextureAtlas atlas, Rectangle sourceRectangle, Rectangle destination, string text, Color color)
    {
        Destination = destination;
        SourceRectangle = sourceRectangle;
        TextBox = new TextBox(content, sourceRectangle, destination, text, color);
        Border = new Border(atlas, sourceRectangle, destination);
    }

    public void Draw(SpriteBatch sb)
    {
        Border.Draw(sb);
        TextBox.Draw(sb);
    }


}