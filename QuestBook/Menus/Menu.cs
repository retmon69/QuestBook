using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using Microsoft.Xna.Framework;
using System;
using MonoGameLibrary.Input;

public abstract class Menu
{
    public List<Button> Buttons;
    public bool Loaded = false;

    public abstract void Draw(SpriteBatch sb, Vector2 scale, List<Action> actions);
    public abstract void Update(InputManager input);
}