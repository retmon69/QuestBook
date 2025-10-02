using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Input;


public class Button
{
    public TextBox TextBox;
    public Border Border;
    public Rectangle Bounds;

    public bool WasPressed;
    public bool IsPressed;
    public bool IsHovered;

    public bool Active;

    public Action OnClick;

    public Button(Border border, TextBox textBox)
    {
        TextBox = textBox;
        Border = border; 
        Active = false;
    }

    public void Draw(SpriteBatch sb, Vector2 position, Vector2 scale, Vector2 ButtonSize, string buttonText, Action onClick)
    {
        Border.Draw(sb, ButtonSize, position, scale);
        Bounds = new Rectangle((int)position.X, (int)position.Y, (int)(ButtonSize.X * 128 * scale.X), (int)(ButtonSize.Y * 128 * scale.Y));
        TextBox.Draw(sb, buttonText, new Vector2(position.X + (64 * 0.3f), position.Y + (16 * 0.7f)), Color.BurlyWood);
        OnClick = onClick;
        
    }

    public void Update(InputManager inputManager)
    {
        IsHovered = Bounds.Contains(inputManager.Mouse.Position) && !inputManager.Mouse.WasButtonJustPressed(MouseButton.Left);

        IsPressed = Bounds.Contains(inputManager.Mouse.Position) && inputManager.Mouse.IsButtonDown(MouseButton.Left);

        WasPressed = Bounds.Contains(inputManager.Mouse.Position) && inputManager.Mouse.WasButtonJustPressed(MouseButton.Left);

        if (WasPressed)
        {
            if (Active)
            {
                Active = false;
            }
            else
            {
                Active = true;
            }
            OnClick.Invoke();
        }
    }
}