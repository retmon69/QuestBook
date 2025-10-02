using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using Microsoft.Xna.Framework;
using System;
using MonoGameLibrary.Input;

public class QuestOverview : IMainMenu
{
    public List<Quest> Quests;
    private int scrollOffset = 0;
    public MainBorder Border { get; set; }
    public List<Button> Buttons { get; set; }
    public bool Loaded { get; set; }
    public Rectangle SourceRectangle { get; set; }
    public Rectangle Destination { get; set; }

    public QuestOverview(TextureAtlas atlas, ContentManager content, List<Quest> quests, List<Button> buttons, Rectangle sourceRectangle, Rectangle destination)
    {
        Quests = quests;
        Border = new MainBorder(atlas);
        Buttons = buttons;
        Loaded = false;
        SourceRectangle = sourceRectangle;
        Destination = destination;
    }
    public QuestOverview()
    {
    }

    public void Draw(SpriteBatch sb)
    {
        Border.Draw(sb);

        for (int i = 0; i < Quests.Count; i++)
        {
            Quests[i].Draw(sb);
        }
    }

    public void Update(InputManager input)
    {
    }

    private void AlignQuests()
    {
        int spacingY = (int)(Border.Destination.Height * 0.1f);
        int spacingX = (int)(Border.Destination.Width * 0.1f);
        int width = (int)(Border.Destination.Width * 0.25f);
        int height = (int)(Border.Destination.Height * 0.25f);
        Point start = new Point(Border.Destination.X, Border.Destination.Y);
        for (int i = 0; i < Quests.Count; i++)
        {
            for (int y = 0; y < 3; y++)
            {
                for(int x = 0; x < 3; x++)
                Quests[i].Destination = new Rectangle(start.X + (x * spacingX), start.Y + (y * spacingX), width, height);
            }
        }

    }
}