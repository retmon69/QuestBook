using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using Microsoft.Xna.Framework;
using MonoGameLibrary;

public class Quest : IUiElement
{
    public Border Border;
    public TextBox Title;

    public TextBox Description;

    public Rectangle SourceRectangle { get; set; }
    public Rectangle Destination { get; set; }


    public Quest(ContentManager content, TextureAtlas atlas, Rectangle sourceRectangle, Rectangle destination, QuestInfo questInfo, Color color)
    {
        Destination = destination;
        SourceRectangle = sourceRectangle;
        Border = new Border(atlas, sourceRectangle, destination);
        int borderHeight = (int)(50 * (Destination.Height / Border.BorderSize.Y / 128f));
        int borderWidth =  (int)(60 * (Destination.Width / Border.BorderSize.X / 128f));
        Title = new TextBox(content, sourceRectangle, new Rectangle((int)(Destination.X + borderWidth), (int)(Destination.Y + borderHeight), (int)(Destination.Width * 0.8f), (int)(Destination.Height * 0.8)), questInfo.Title, color);
        Title.ChangeTextSize(20);
        Description = new TextBox(content, sourceRectangle, new Rectangle((int)(Destination.X + borderWidth), Destination.Y + (int)(borderHeight * 3), (int)(Destination.Width * 0.8f), (int)(Destination.Height * 0.8)), questInfo.Description, color);
        Description.ChangeTextSize(15);
    }

    public void Draw(SpriteBatch sb)
    {
        Border.Draw(sb);
        Title.Draw(sb);
        Description.Draw(sb);
    }
}