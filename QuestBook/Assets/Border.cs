using MonoGameLibrary.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;
using System;
using System.Security.Cryptography.X509Certificates;


public class Border
{
    public Sprite topLeft, topRight, bottomLeft, bottomRight;
    public Sprite top, bottom, left, right, center;

    public Vector2 Position;
    public Border(TextureAtlas atlas)
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
        Position = new Vector2();
    }

    public void Draw(SpriteBatch sb, Vector2 BorderSize, Vector2 position)
    {
        topLeft.Draw(sb, position);
        for (int i = 1; i <= BorderSize.X - 2; i++)
        {
            top.Draw(sb, new Vector2(position.X + (i * 128), position.Y));
        }
        topRight.Draw(sb, new Vector2(position.X + (128 * (BorderSize.X - 1)), position.Y));



        for (int i = 1; i <= BorderSize.Y - 2; i++)
        {
            left.Draw(sb, new Vector2(position.X, position.Y + (i * 128)));

            for (int y = 1; y <= BorderSize.X - 2; y++)
            {
                center.Draw(sb, new Vector2(position.X + (y * 128), position.Y + (i * 128)));
            }

            right.Draw(sb, new Vector2(position.X + (128 * (BorderSize.X - 1)), position.Y + (i * 128)));
        }

        bottomLeft.Draw(sb, new Vector2(position.X, position.Y + (128 * (BorderSize.Y - 1))));
        for (int i = 1; i <= BorderSize.X - 2; i++)
        {
            bottom.Draw(sb, new Vector2(position.X + (i * 128), position.Y + (128 * (BorderSize.Y - 1))));
        }
        bottomRight.Draw(sb, new Vector2(position.X + (128 * (BorderSize.X - 1)), position.Y + (128 * (BorderSize.Y - 1))));
        Position = position;
    }

    public void Draw(SpriteBatch sb, Vector2 BorderSize, Vector2 position, Vector2 scale)
    {
        topLeft.Draw(sb, position);
        for (int i = 1; i <= BorderSize.X - 2; i++)
        {
            top.Draw(sb, new Vector2(position.X + (i * (128 * scale.X)), position.Y));
        }
        topRight.Draw(sb, new Vector2(position.X + (128 * scale.X * (BorderSize.X - 1)), position.Y));



        for (int i = 1; i <= BorderSize.Y - 2; i++)
        {
            left.Draw(sb, new Vector2(position.X, position.Y + (i * (128 * scale.Y))));

            for (int y = 1; y <= BorderSize.X - 2; y++)
            {
                center.Draw(sb, new Vector2(position.X + (y * (128 * scale.X)), position.Y + (i * (128 * scale.Y))));
            }

            right.Draw(sb, new Vector2(position.X + (128 * scale.X * (BorderSize.X - 1)), position.Y + (i * (128 * scale.Y))));
        }

        bottomLeft.Draw(sb, new Vector2(position.X, position.Y + (128 * scale.Y * (BorderSize.Y - 1))));
        for (int i = 1; i <= BorderSize.X - 2; i++)
        {
            bottom.Draw(sb, new Vector2(position.X + (i * (128 * scale.X)), position.Y + (128 * scale.Y * (BorderSize.Y - 1))));
        }
        bottomRight.Draw(sb, new Vector2(position.X + ((128 * scale.X) * (BorderSize.X - 1)), position.Y + (128 * scale.Y * (BorderSize.Y - 1))));
        Position = position * scale;
        ChangeScale(scale);
    }

public void DrawClipped(SpriteBatch sb, Vector2 borderSize, Vector2 position, Vector2 scale, Rectangle clipRect)
{
    int tileW = (int)(128 * scale.X);
    int tileH = (int)(128 * scale.Y);

    // --- Top Row ---
    Vector2 tilePos = position;
    topLeft.DrawClipped(sb, tilePos, scale, clipRect);

    for (int i = 1; i <= borderSize.X - 2; i++)
    {
        tilePos = new Vector2(position.X + i * tileW, position.Y);
        top.DrawClipped(sb, tilePos, scale, clipRect);
    }

    tilePos = new Vector2(position.X + (borderSize.X - 1) * tileW, position.Y);
    topRight.DrawClipped(sb, tilePos, scale, clipRect);

    // --- Middle Rows ---
    for (int j = 1; j <= borderSize.Y - 2; j++)
    {
        // Left
        tilePos = new Vector2(position.X, position.Y + j * tileH);
        left.DrawClipped(sb, tilePos, scale, clipRect);

        // Center
        for (int i = 1; i <= borderSize.X - 2; i++)
        {
            tilePos = new Vector2(position.X + i * tileW, position.Y + j * tileH);
            center.DrawClipped(sb, tilePos, scale, clipRect);
        }

        // Right
        tilePos = new Vector2(position.X + (borderSize.X - 1) * tileW, position.Y + j * tileH);
        right.DrawClipped(sb, tilePos, scale, clipRect);
    }

    // --- Bottom Row ---
    tilePos = new Vector2(position.X, position.Y + (borderSize.Y - 1) * tileH);
    bottomLeft.DrawClipped(sb, tilePos, scale, clipRect);

    for (int i = 1; i <= borderSize.X - 2; i++)
    {
        tilePos = new Vector2(position.X + i * tileW, position.Y + (borderSize.Y - 1) * tileH);
        bottom.DrawClipped(sb, tilePos, scale, clipRect);
    }

    tilePos = new Vector2(position.X + (borderSize.X - 1) * tileW, position.Y + (borderSize.Y - 1) * tileH);
    bottomRight.DrawClipped(sb, tilePos, scale, clipRect);
}



    private void ChangeScale(Vector2 scale)
    {
        topLeft.Scale = scale;
        topRight.Scale = scale;
        bottomLeft.Scale = scale;
        bottomRight.Scale = scale;
        top.Scale = scale;
        bottom.Scale = scale;
        left.Scale = scale;
        right.Scale = scale;
        center.Scale = scale;
    }
}

