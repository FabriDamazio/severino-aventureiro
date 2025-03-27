using Godot;

public partial class Music : AudioStreamPlayer
{

    private Tween _tween;
    private File _file;

    public override void _Ready()
    {
        SetLinearVolume(0);
        ProcessMode = ProcessModeEnum.Always;
        _file = GetNode<File>("/root/File");
    }

    public void SetLinearVolume(float linearVolume)
    {
        VolumeDb = Mathf.LinearToDb(linearVolume);
    }

    public SignalAwaiter FadeVolume(float targetVolume)
    {
        if (_tween is not null && _tween.IsRunning())
            _tween.Kill();

        _tween = CreateTween();
        _tween.TweenMethod(Callable.From<float>(SetLinearVolume), Mathf.DbToLinear(VolumeDb), targetVolume, 1);
        return ToSignal(_tween, "finished");
    }

    public SignalAwaiter Play(AudioStream stream)
    {
        Stream = stream;
        Play();

        return FadeVolume(_file.Settings.Volume);
    }

    public async void FadeOut()
    {
        await FadeVolume(0);
        Stop();
        Stream = null;
    }
}
