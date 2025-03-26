using Godot;

[GlobalClass]
public partial class Progress : Resource
{
    [Export]
    public int CurrentHealth {get; set;}

    [Export]
    public string PlayerName {get; set;}

    public Progress()
    {
        PlayerName = "Severino";
        CurrentHealth = 100;
    }
}
