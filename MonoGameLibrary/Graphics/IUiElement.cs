using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface IUiElement
{
    public Rectangle SourceRectangle { get; set; }
    public Rectangle Destination { get; set; }

    public void Draw(SpriteBatch sb);
}