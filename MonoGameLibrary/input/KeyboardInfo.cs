using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGameLibrary.Input;

public class KeyboardInfo
{
    /// <summary>
    /// Gets the state of keyboard input during the previous update cycle.
    /// </summary>
    public KeyboardState PreviousState { get; private set; }

    /// <summary>
    /// Gets the state of keyboard input during the current input cycle.
    /// </summary>
    public KeyboardState CurrentState { get; private set; }

    private GameWindow? _window;
    private readonly Queue<char> _charQueue = new();

    /// <summary>
    /// Creates a new KeyboardInfo. 
    /// </summary>
    public KeyboardInfo()
    {
        PreviousState = new KeyboardState();
        CurrentState = Keyboard.GetState();
    }

    public void Hook(GameWindow window)
    {
        if (_window != null) Unhook();
        _window = window;
        _window.TextInput += OnTextInput;
    }

    public void Unhook()
    {
        if (_window != null)
        {
            _window.TextInput -= OnTextInput;
            _window = null;
        }
    }

    private void OnTextInput(object? sender, TextInputEventArgs e)
    {
        if (!char.IsControl(e.Character))
            _charQueue.Enqueue(e.Character);
        // Backspace/Enter etc. bei Bedarf hier separat behandeln
    }

    public bool TryDequeueChar(out char ch)
    {
        if (_charQueue.Count > 0)
        {
            ch = _charQueue.Dequeue();
            return true;
        }
        ch = default;
        return false;
    }

    /// <summary>
    /// Updates the state information about keyboard input.
    /// </summary>
    public void Update()
    {
        PreviousState = CurrentState;
        CurrentState = Keyboard.GetState();
    }

    /// <summary>
    /// Returns a value that indicates if the specified key is currently down.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns>true if the specified key is currently down; otherwise, false.</returns>
    public bool IsKeyDown(Keys key)
    {
        return CurrentState.IsKeyDown(key);
    }

    /// <summary>
    /// Returns a value that indicates whether the specified key is currently up.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns>true if the specified key is currently up; otherwise, false.</returns>
    public bool IsKeyUp(Keys key)
    {
        return CurrentState.IsKeyUp(key);
    }

    /// <summary>
    /// Returns a value that indicates if the specified key was just pressed on the current frame.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns>true if the specified key was just pressed on the current frame; otherwise, false.</returns>
    public bool WasKeyJustPressed(Keys key)
    {
        return CurrentState.IsKeyDown(key) && PreviousState.IsKeyUp(key);
    }

    /// <summary>
    /// Returns a value that indicates if the specified key was just released on the current frame.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns>true if the specified key was just released on the current frame; otherwise, false.</returns>
    public bool WasKeyJustReleased(Keys key)
    {
        return CurrentState.IsKeyUp(key) && PreviousState.IsKeyDown(key);
    }

    public List<Keys> GetPressedKeys() =>  Keyboard.GetState().GetPressedKeys().ToList();
}
