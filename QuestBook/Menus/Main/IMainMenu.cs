using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Graphics;
using Microsoft.Xna.Framework;
using MonoGameLibrary.Input;
using System;

public interface IMainMenu : IMenu
{
    public MainBorder Border { get; set; }
}