using System;

public class ButtonInfo
{
    public Action OnClick;
    public string Text;

    public ButtonInfo(Action onClick, string text)
    {
        OnClick = onClick;
        Text = text;
    }
}