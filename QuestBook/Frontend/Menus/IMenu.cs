using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using Microsoft.Xna.Framework;
using System;
using MonoGameLibrary.Input;

public interface IMenu : IUiElement
{
    public List<Button> Buttons { get; set; }
    public bool Loaded {get; set;}
    //public abstract void Update(InputManager input);
}