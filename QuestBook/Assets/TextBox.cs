using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;



public class TextBox
{
    private SpriteFont textFont;
    private SpriteFont titleFont;

    public TextBox(ContentManager content)
    {
        textFont = content.Load<SpriteFont>("fonts/Arial");
        titleFont = content.Load<SpriteFont>("fonts/ArialBold");
    }

    public void Draw(SpriteBatch sb, string text, Vector2 position, Color color)
    {
        sb.DrawString(textFont, text, position, color);
    }

    public void Draw(SpriteBatch sb, string title, string text, Vector2 position, Color color)
    {
        sb.DrawString(titleFont, title, position, color);
        sb.DrawString(textFont, text, new Vector2(position.X, position.Y + (titleFont.Spacing * 5)), color);
    }

    public void Draw(SpriteBatch sb, QuestInfo questInfo, Vector2 position, Color color)
    {
        sb.DrawString(titleFont, questInfo.Title, position, color);
        sb.DrawString(textFont, questInfo.Description, new Vector2(position.X, position.Y + (titleFont.Spacing * 10)), color);
    }

    public void Draw(SpriteBatch sb, QuestInfo questInfo, Vector2 position, Color color, Vector2 scale)
    {
        sb.DrawString(titleFont, questInfo.Title, position, color, 0, Vector2.One, scale, SpriteEffects.None, 1);
        sb.DrawString(textFont, questInfo.Description, new Vector2(position.X, position.Y + (titleFont.Spacing * 10)), color, 0, Vector2.One, scale, SpriteEffects.None, 1);
    }

    public Texture2D RenderTextToTexture(GraphicsDevice graphicsDevice, QuestInfo questInfo, Color color, Vector2 scale)
    {
        // Textgrößen berechnen
        Vector2 titleSize = titleFont.MeasureString(questInfo.Title) * scale;
        Vector2 descSize = textFont.MeasureString(questInfo.Description) * scale;

        // Textur so klein wie nötig -> kein unnötiges Transparent
        int width = (int)Math.Ceiling(Math.Max(titleSize.X, descSize.X));
        int height = (int)Math.Ceiling(titleSize.Y + descSize.Y);

        if (width <= 0 || height <= 0)
            return null;

        // Neues RenderTarget mit kleinstmöglicher Größe
        RenderTarget2D renderTarget = new RenderTarget2D(
            graphicsDevice,
            width,
            height,
            false,                        // keine MipMaps
            SurfaceFormat.Color,          // normales Farbformat mit Alpha
            DepthFormat.None
        );

        // Aktuelles Ziel sichern
        var oldTarget = graphicsDevice.GetRenderTargets();

        graphicsDevice.SetRenderTarget(renderTarget);
        graphicsDevice.Clear(Color.Transparent); // Transparent als Hintergrund

        using (SpriteBatch sb = new SpriteBatch(graphicsDevice))
        {
            // Wichtig: AlphaBlend aktiv -> Transparent bleibt durchsichtig
            sb.Begin(blendState: BlendState.AlphaBlend);
            
            // Titel
            sb.DrawString(titleFont, questInfo.Title, Vector2.Zero, color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

            // Beschreibung darunter
            Vector2 descPos = new Vector2(0, titleSize.Y);
            sb.DrawString(textFont, questInfo.Description, descPos, color, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

            sb.End();
        }

        // RenderTarget zurücksetzen
        graphicsDevice.SetRenderTargets(null);

        return renderTarget;
    }



}