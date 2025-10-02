using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;

namespace QuestBook;

public class Game1 : Core   
{
    private MenuManager menuManager;

    private Border border;

    private Sprite sprite;

    private Button button;

    private TextBox textBox;

    public Game1() : base("QuestBook", 1920, 1024, false)
    {

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {


        TextureAtlas atlas = TextureAtlas.FromFile(Content, "images/border-definition.xml");

        button = new Button(Content, atlas, new Rectangle(100, 100, 800, 500), new Rectangle(100, 100, 800, 500), "Test", Color.White, () => Console.Write("TEst"));

        border = new Border(atlas, new Rectangle(100, 100, 800, 500), new Rectangle(100, 100, 800, 500));

        sprite = atlas.CreateSprite("TopRightCorner");

        menuManager = new MenuManager(atlas, Content);

        textBox = new TextBox(Content, new Rectangle(100, 100, 800, 500), new Rectangle(100, 100, 800, 500), "Test", Color.Black);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        //button.Update(Input);
        menuManager.Update(Input);

        button.Update(Input);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // TODO: Add your drawing code here

        GraphicsDevice.Clear(Color.SandyBrown);

        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp, blendState: BlendState.AlphaBlend);

        //sprite.Draw(SpriteBatch, new Rectangle(100, 100, 500, 500), new Rectangle(100, 100, 500, 500));

        //border.Draw(SpriteBatch);
        //quest.Draw(SpriteBatch, new Vector2(200, 200), new QuestInfo("Test Quest", "Test beschreibung und so"));
        //menuManager.Draw(SpriteBatch);
        //button.Draw(SpriteBatch);
        textBox.Draw(SpriteBatch);

        //button.Draw(SpriteBatch, Vector2.One, new Vector2(0.2f,0.2f), new Vector2(4,2), "Tost");

        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
