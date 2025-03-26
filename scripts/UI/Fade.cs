using Godot;
using System.Threading.Tasks;

public partial class Fade : ColorRect
{
    private Tween _tween;

    [Signal]
    public delegate void ToBlackCompletedEventHandler();

    public override void _Ready()
    {
        Visible = true;
    }

    public async void ToClear()
    {
        _tween = CreateTween();
        _tween.TweenProperty(this, "color", Colors.Transparent, 1);
        await ToSignal(_tween, "finished");
    }

    public async Task ToBlack()
    {
        _tween = CreateTween();
        _tween.TweenProperty(this, "color", Colors.Black, 1);
        await ToSignal(_tween, "finished");
    }
}
