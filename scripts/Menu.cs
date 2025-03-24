using Godot;

public partial class Menu : Control
{
    [Export]
    private Control _defaultFocusItem;

    public void Open()
    {
        Visible = true;
        _defaultFocusItem.GrabFocus();
    }

    public void Close()
    {
        Visible = false;
    }
}
