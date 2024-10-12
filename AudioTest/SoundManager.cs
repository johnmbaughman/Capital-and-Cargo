using NAudio.Wave;
using System.Media;

namespace FireAndForgetAudioSample;

public class SoundManager : IDisposable
{
    private Dictionary<string, WaveFileReader> waveFileReaders;
    private bool _disposed;
    private WaveOutEvent _loopWaveOut;

    public string[] Files { get; }

    public SoundManager(string[] files)
    {
        Files = files;
        waveFileReaders = new Dictionary<string, WaveFileReader>();
    }

    public void Initialize()
    {
        foreach (var file in Files)
        {
            waveFileReaders.Add(Path.GetFileNameWithoutExtension(file), new WaveFileReader(file));
        }
    }

    public void PlaySoundLooping(string name)
    {
        if (waveFileReaders.ContainsKey(name))
        {
            var loopStream = new LoopStream(waveFileReaders[name]);
            _loopWaveOut = new WaveOutEvent();
            _loopWaveOut.Init(loopStream);
            _loopWaveOut.Play();
        }
    }

    public void StopLoopingSound()
    {
        if (_loopWaveOut.PlaybackState == PlaybackState.Playing)
        {
            _loopWaveOut.Stop();
        }
    }

    public void PlaySoundByName(string name)
    {
        if (waveFileReaders.ContainsKey(name))
        {
            try
            {
                var soundEvent = new WaveOutEvent();
                soundEvent.Init(waveFileReaders[name]);
                soundEvent.Play();
                PlayingSound = true;
                while (soundEvent.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(50);
                }

                PlayingSound = false;
                waveFileReaders[name].Position = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public bool PlayingSound { get; private set;  }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            waveFileReaders.Values.ToList().ForEach(w => w.Dispose());
        }

        _disposed = true;
    }
}