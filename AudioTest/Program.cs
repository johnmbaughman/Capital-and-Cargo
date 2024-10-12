using FireAndForgetAudioSample;
using NAudio.Wave;
using System.Media;

var files = new List<string>
{
    "C:\\Personal\\Files\\source\\repos\\Capital-and-Cargo\\Capital And Cargo 1\\Resources\\blipSelect.wav",
    "C:\\Personal\\Files\\source\\repos\\Capital-and-Cargo\\Capital And Cargo 1\\Resources\\horn-hooter-94444.wav",
    "C:\\Personal\\Files\\source\\repos\\Capital-and-Cargo\\Capital And Cargo 1\\sound\\music\\gameMusic.wav"
};

using var soundMgr = new SoundManager(files.ToArray());
soundMgr.Initialize();
soundMgr.PlaySoundLooping("gameMusic");

//soundMgr.PlaySoundByName("blipSelect");
//

var endLoop = false;

while (!Console.KeyAvailable && !endLoop )
{
    try
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.Escape:
            {
                soundMgr.StopLoopingSound();
                endLoop = true;
                break;
            }
            case ConsoleKey.M:
            {
                while (soundMgr.PlayingSound) { }

                soundMgr.PlaySoundByName("horn-hooter-94444");
                break;
            }
            case ConsoleKey.B:
            {
                soundMgr.PlaySoundByName("blipSelect");
                break;
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }
}


//var zap = new CachedSound("C:\\Personal\\Files\\source\\repos\\Capital-and-Cargo\\Capital And Cargo 1\\Resources\\blipSelect.wav");
//var boom = new CachedSound("C:\\Personal\\Files\\source\\repos\\Capital-and-Cargo\\Capital And Cargo 1\\Resources\\horn-hooter-94444.wav");


//var zap = new CachedSound("C:\\Personal\\Files\\source\\repos\\Capital-and-Cargo\\Capital And Cargo 1\\Resources\\blipSelect.wav");
//var boom = new CachedSound("C:\\Personal\\Files\\source\\repos\\Capital-and-Cargo\\Capital And Cargo 1\\Resources\\horn-hooter-94444.wav");


//// later in the app...
//AudioPlaybackEngine.Instance.PlaySound(zap);
//AudioPlaybackEngine.Instance.PlaySound(boom);
//AudioPlaybackEngine.Instance.PlaySound("C:\\Personal\\Files\\source\\repos\\Capital-and-Cargo\\Capital And Cargo 1\\Resources\\moneyGained.wav");

//// on shutdown
//AudioPlaybackEngine.Instance.Dispose();

//using(var audioFile = new AudioFileReader("C:\\Personal\\Files\\source\\repos\\Capital-and-Cargo\\Capital And Cargo 1\\sound\\music\\gameMusic.wav"))
//using(var outputDevice = new WaveOutEvent())
//{
//    outputDevice.Init(audioFile);
//    outputDevice.Play();
//    while (outputDevice.PlaybackState == PlaybackState.Playing)
//    {
//        Thread.Sleep(1000);
//    }
//}