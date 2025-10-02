using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;

public class MainBorder : IUiElement
{
    public Border Border;

    public Rectangle SourceRectangle { get; set; }
    public Rectangle Destination { get; set; }

    public Vector2 BorderSize;
    public int X = 410;
    public int Y = 25;
    public int Width = (int)(11 * 128 * 1.07f); 
    public int Height = (int)(7 * 128 * 1.05f);
    public Vector2 Scale = new Vector2(1.06f, 1.06f);
    public int ScrollOffsetY = 40;
    public MainBorder(TextureAtlas atlas)
    {
        BorderSize = new Vector2(11, 7);
        Destination = new Rectangle(410, 25, 1520, 950);
        Border = new Border(atlas, Destination, Destination);
    }

    public void Draw(SpriteBatch sb)
    {
        Border.Draw(sb);
    }
}