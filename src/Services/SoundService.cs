
using Plugin.Maui.Audio;

namespace PolyhydraGames.Core.Maui.Services;

public class SoundService : ISoundService
{
    private readonly IAudioManager _audioManager;
    private readonly Dictionary<string, IAudioPlayer> _soundCache = new();


    public SoundService(IAudioManager audioManager)
    {
        _audioManager = audioManager;
    }

    public static Task<Stream> GetStream(string fileName)
    {
        return FileSystem.OpenAppPackageFileAsync(fileName);
    }
    private async Task<IAudioPlayer> CreateMediaPlayer(string value)
    {
        var mediaPlayer = _audioManager.CreatePlayer(await GetStream(value));
        _soundCache.Add(value, mediaPlayer);
        return mediaPlayer;
    }

    private async Task<IAudioPlayer> GetAudioPlayer(string key)
    {
        return _soundCache.TryGetValue(key, out var value) 
            ? value 
            : await CreateMediaPlayer(key);
    }
    public async Task Play(string value, bool loop = false)
    {
        var mediaplayer = await GetAudioPlayer(value);
        mediaplayer.Loop = loop;
        if (mediaplayer.IsPlaying == false)
        {
            mediaplayer.Play();
        }
    }

    public async Task Pause(string value)
    {
        var mediaplayer = await GetAudioPlayer(value);
        if (mediaplayer.IsPlaying)
        {
            mediaplayer.Pause();
        }
    }

    public async Task Stop(string value)
    {
        var mediaplayer = await GetAudioPlayer(value);
        if (mediaplayer.IsPlaying)
        {
            mediaplayer.Stop();
        }
    }


}