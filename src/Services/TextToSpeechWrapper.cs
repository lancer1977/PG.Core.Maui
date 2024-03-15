using System.Reactive.Linq;
using System.Reactive.Subjects;

using IPlatformTextToSpeech = Microsoft.Maui.Media.ITextToSpeech;
using ITextToSpeech = PolyhydraGames.Core.Interfaces.ITextToSpeech;

namespace PolyhydraGames.Core.Maui.Services;

public class TextToSpeechWrapper : ITextToSpeech
{
    private readonly IPlatformTextToSpeech _plat;

    private readonly SpeechOptions _speechOptions = new();
    CancellationTokenSource cts;

    readonly Subject<PlaybackState> _playbackStateSubject = new Subject<PlaybackState>();
    public IObservable<PlaybackState> PlaybackState { get; }

    public TextToSpeechWrapper(IPlatformTextToSpeech plat)
    {
        _plat = plat;
        _speechOptions = new SpeechOptions();
        PlaybackState = _playbackStateSubject.AsObservable();
    }

    public void Speak(string text)
    {
        Task.Run(async () =>await SpeakAsync(text));
    }

    public async Task SpeakAsync(string text)
    {
        cts = new CancellationTokenSource();
        await _plat.SpeakAsync(text, _speechOptions, cts.Token);
        _playbackStateSubject.OnNext(PolyhydraGames.Core.Interfaces.PlaybackState.Playing);

    }


    public void Rate(double value)
    {
        _speechOptions.Pitch = (float)value;
    }

    public void ChangeVoice(string voice)
    {

    }

    public string[] VoiceNames()
    {
        return Array.Empty<string>();
    }

    /// <summary>
    /// 
    /// </summary>
    public void Stop()
    {
        if (cts.IsCancellationRequested) return;

        cts.Cancel();

        _playbackStateSubject.OnNext(PolyhydraGames.Core.Interfaces.PlaybackState.Stopped);
    }

    /// <summary>
    /// Pause 
    /// </summary>
    public void Pause()
    {
        Stop();
    }
}