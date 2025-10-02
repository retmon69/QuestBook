using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;

public class MainBorder
{
    public Border Border;
    public int X = 410;
    public int Y = 25;
    public int Width = (int)(11 * 128 * 1.07f); 
    public int Height = (int)(7 * 128 * 1.05f);
    public Vector2 Scale = new Vector2(1.06f, 1.06f);
    public int ScrollOffsetY = 40;
    public MainBorder(TextureAtlas atlas)
    {
        Border = new Border(atlas);
    }

    public void Draw(SpriteBatch sb)
    {
        Border.Draw(sb, new Vector2(11, 7), new Vector2(X, Y), Scale);
    }
}