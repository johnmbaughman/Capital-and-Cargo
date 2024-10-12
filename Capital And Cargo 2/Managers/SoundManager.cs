using CapitalAndCargo2.Interfaces;
using CapitalAndCargo2.Models;
using CommunityToolkit.Mvvm.Messaging;
using NAudio.Wave;

namespace CapitalAndCargo2.Managers;

internal class SoundManager() : IManager, IRecipient<Message>, IDisposable
{
    private static readonly WaveOutEvent _musicPlayer = new();
    private static readonly WaveOutEvent _soundPlayer = new();
    private bool _disposed;
    private bool _playingMusic = _musicPlayer.PlaybackState == PlaybackState.Playing;
    private bool _playingSound = _soundPlayer.PlaybackState == PlaybackState.Playing;

    public void Receive(Message message) { }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }



    public void PlayMusic()
    {
        var reader = new WaveFileReader()
        LoopStream loop = new LoopStream(reader);
        _musicPlayer.Init(loop);
        _musicPlayer.Play();
    }

    public void StopMusic()
    {
        _musicPlayer.Stop();
    }

    public void PlaySound()
    {

    }

    private void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            _musicPlayer.Stop();
            _soundPlayer.Stop();
            Thread.Sleep(1000);
            _musicPlayer.Dispose();
            _soundPlayer.Dispose();
        }

        _disposed = true;
    }

    public Task Initialize()
    {
        return Task.CompletedTask;
    }
}


