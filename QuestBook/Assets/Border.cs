using MonoGameLibrary.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


public class Border : IUiElement
{
    public Sprite topLeft, topRight, bottomLeft, bottomRight;
    public Sprite top, bottom, left, right, center;

    public Rectangle SourceRectangle { get; set; }
    public Rectangle Destination { get; set; }
    public Vector2 BorderSize;

    public Border(TextureAtlas atlas, Rectangle sourceRectangle, Rectangle destination)
    {
        topLeft = atlas.CreateSprite("TopLeftCorner");
        topRight = atlas.CreateSprite("TopRightCorner");
        bottomLeft = atlas.CreateSprite("BottomLeftCorner");
        bottomRight = atlas.CreateSprite("BottomRightCorner");
        top = atlas.CreateSprite("Top");
        bottom = atlas.CreateSprite("Bottom");
        left = atlas.CreateSprite("Left");
        right = atlas.CreateSprite("Right");
        center = atlas.CreateSprite("Center");

        SourceRectangle = sourceRectangle;
        Destination = destination;
        BorderSize = new Vector2(destination.Width / 128, destination.Height / 128);
        if (destination.Width / 128 < 3)
            destination.Width = 3;
        else if (destination.Height / 128 < 3)
            destination.Height = 3;
    }

    public void Draw(SpriteBatch sb)
    {
        Point start = Destination.Location;
        int width = (int)(Destination.Width / BorderSize.X);
        int height = (int)(Destination.Height / BorderSize.Y);

        topLeft.Draw(sb, new Rectangle(start.X, start.Y, width, height), SourceRectangle);
        for (int i = 1; i <= BorderSize.X - 2; i++)
        {
            top.Draw(sb, new Rectangle(start.X + (i * width), start.Y, width, height), SourceRectangle);
        }
        topRight.Draw(sb, new Rectangle(((int)BorderSize.X - 1) * width + start.X, start.Y, width, height), SourceRectangle);



        for (int i = 1; i <= BorderSize.Y - 2; i++)
        {
            left.Draw(sb, new Rectangle(start.X, start.Y + (i * height), width, height), SourceRectangle);

            for (int y = 1; y <= BorderSize.X - 2; y++)
            {
                center.Draw(sb, new Rectangle(start.X + (width * y), start.Y + (height * i), width, height), SourceRectangle);
            }

            right.Draw(sb, new Rectangle((int)(BorderSize.X - 1) * width + start.X, start.Y + (height * i), width, height), SourceRectangle);
        }

        bottomLeft.Draw(sb, new Rectangle(start.X, start.Y + (height * ((int)BorderSize.Y - 1)), width, height), SourceRectangle);
        for (int i = 1; i <= BorderSize.X - 2; i++)
        {
            bottom.Draw(sb, new Rectangle(start.X + (width * i), start.Y + (height * ((int)BorderSize.Y - 1)), width, height), SourceRectangle);
        }
        bottomRight.Draw(sb, new Rectangle(start.X + ((int)BorderSize.X - 1) * width, start.Y + (((int)BorderSize.Y - 1) * height), width, height), SourceRectangle);
    }
}

