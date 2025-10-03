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
    public MainBorder Border { get; set; }
    public List<Button> Buttons { get; set; }
    public bool Loaded { get; set; }
    public Rectangle SourceRectangle { get; set; }
    public Rectangle Destination { get; set; }

    public QuestOverview(TextureAtlas atlas, ContentManager content, List<QuestInfo> questInfos, List<Button> buttons, Rectangle sourceRectangle, Rectangle destination)
    {
        Border = new MainBorder(atlas);
        Buttons = buttons;
        Loaded = false;
        SourceRectangle = sourceRectangle;
        Destination = destination;
        Quests = new List<Quest>();
        AlignQuests(atlas, content, questInfos);
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

    private void AlignQuests(TextureAtlas atlas, ContentManager content, List<QuestInfo> questInfos)
    {
        int spacingY = (int)(Border.Destination.Height * 0.05f);
        int spacingX = (int)(Border.Destination.Width * 0.05f);
        int width = (int)(Border.Destination.Width * 0.25f);
        int height = (int)(Border.Destination.Height * 0.25f);
        Point start = new Point(Border.Destination.X + spacingX, Border.Destination.Y + spacingY);
        int rows = 0;
        int cols = 0;
        for (int i = 0; i < questInfos.Count; i++)
        {
            if (i % 3 == 0 && i != 0)
            {
                rows++;
                cols = 0;
            }
            Rectangle rect = new Rectangle(start.X + (spacingX * cols) + (cols * width), start.Y + (rows * spacingY) + (rows * height), width, height);
            Quests.Add(new Quest(content, atlas, SourceRectangle, rect, questInfos[i], Color.White));
            cols++;
        }

    }
}