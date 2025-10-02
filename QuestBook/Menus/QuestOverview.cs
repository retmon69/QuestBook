using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using Microsoft.Xna.Framework;
using System;
using MonoGameLibrary.Input;

public class QuestOverview : MainMenu
{
    public List<Quest> Quests;
    private int scrollOffset = 0;
    public QuestOverview(TextureAtlas atlas, ContentManager content)
    {
        Quests = new List<Quest>();
        Quests.Add(new Quest(content, atlas));
        Quests.Add(new Quest(content, atlas));
        Quests.Add(new Quest(content, atlas));
        Quests.Add(new Quest(content, atlas));
        Quests.Add(new Quest(content, atlas));
        Quests.Add(new Quest(content, atlas));
        Quests.Add(new Quest(content, atlas));
        Quests.Add(new Quest(content, atlas));
        Quests.Add(new Quest(content, atlas));
        Quests.Add(new Quest(content, atlas));
        Border = new MainBorder(atlas);
    }
    public QuestOverview()
    {
    }

    public override void Draw(SpriteBatch sb, Vector2 scale, List<Action> actions)
    {
        Border.Draw(sb);
        Rectangle clipRect = new Rectangle(Border.X, Border.Y + Border.ScrollOffsetY, Border.Width, Border.Height - (2 * Border.ScrollOffsetY));

        Vector2 pos = new Vector2(480, 100 - scrollOffset);

        for (int i = 0; i < Quests.Count; i++)
        {
            // Quest zeichnen mit Clipping
            Quests[i].DrawClipped(sb, pos, new QuestInfo("test", "texttest"), new Vector2(5,3), new Vector2(0.7f,0.7f), clipRect);
            if ((i+1) % 3 == 0)
            {
                pos.X = 480; 
                pos.Y = pos.Y + 270;
            }
            else
            {
                pos.X = pos.X + 448;
            }
        }
    }

    public override void Update(InputManager input)
    {
        int scrollSpeed = 30; // Pixel pro "Mausrad-Einheit"

        if (input.Mouse.ScrollWheelDelta != 0)
        {
            scrollOffset -= input.Mouse.ScrollWheelDelta / 120 * scrollSpeed;

            // Begrenzung: nicht zu weit scrollen
            scrollOffset = Math.Clamp(scrollOffset, 0, 1000);
        }
    }
}