using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Input;


public class Button : IUiElement
{
    public TextBox TextBox;
    public Border Border;
    public Rectangle SourceRectangle { get; set; }
    public Rectangle Destination { get; set; }
    public bool WasPressed;
    public bool IsPressed;
    public bool IsHovered;

    public Action OnClick;

    public Button(ContentManager content, TextureAtlas atlas, Rectangle sourceRectangle, Rectangle destination, string text, Color textColor, Action onClick)
    {
        Destination = destination;
        SourceRectangle = sourceRectangle;
        TextBox = new TextBox(content, sourceRectangle, new Rectangle(Destination.X, Destination.Y, (int)(Destination.Width * 0.7f), (int)(Destination.Height * 0.7f)), text, textColor);
        TextBox.ScaleTextToContainer();
        TextBox.Center(Destination);
        Border = new Border(atlas, sourceRectangle, destination);
        OnClick = onClick;  
    }

    public void Draw(SpriteBatch sb)
    {
        Border.Draw(sb);
        TextBox.Draw(sb);
    }

    public void Update(InputManager inputManager)
    {
        IsHovered = Destination.Contains(inputManager.Mouse.Position) && !inputManager.Mouse.WasButtonJustPressed(MouseButton.Left);

        IsPressed = Destination.Contains(inputManager.Mouse.Position) && inputManager.Mouse.IsButtonDown(MouseButton.Left);

        WasPressed = Destination.Contains(inputManager.Mouse.Position) && inputManager.Mouse.WasButtonJustPressed(MouseButton.Left);

        if (WasPressed)
        {
            OnClick.Invoke();
        }
    }
}