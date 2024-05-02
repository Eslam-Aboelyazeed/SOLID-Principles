namespace ISP
{
    #region Before 
    //public interface IMediaPlayer
    //{
    //    void PlayAudio();
    //    void PlayVideo();
    //    void DisplaySubtitles();
    //    void LoadMedia(string filePath);
    //}
    //public class AudioPlayer : IMediaPlayer
    //{
    //    public void PlayAudio()
    //    {
    //        // Code to play audio
    //    }
    //    public void PlayVideo()
    //    {
    //        throw new NotImplementedException("Audio players cannot play videos.");
    //    }
    //    public void DisplaySubtitles()
    //    {
    //        throw new NotImplementedException("Audio players cannot display subtitles.");
    //    }
    //    public void LoadMedia(string filePath)
    //    {
    //        // Code to load audio file
    //    }
    //}
    //public class VideoPlayer : IMediaPlayer
    //{
    //    public void PlayAudio()
    //    {
    //        throw new NotImplementedException("Video players cannot play audio without video.");
    //    }
    //    public void PlayVideo()
    //    {
    //        // Code to play video
    //    }
    //    public void DisplaySubtitles()
    //    {
    //        // Code to display subtitles
    //    }
    //    public void LoadMedia(string filePath)
    //    {
    //        // Code to load video file
    //    }
    //}

    #endregion

    #region After

    public interface IAudioPlayer
    {
        void PlayAudio();
    }

    internal interface IVideoPlayer
    {
        void PlayVideo();
    }

    internal interface ISubtitlesDisplayer
    {
        void DisplaySubtitles();
    }

    internal interface IMediaLoader
    {
        void LoadMedia(string filePath);
    }

    public class AudioPlayer : IAudioPlayer, IMediaLoader
    {
        public void LoadMedia(string filePath)
        {
            throw new NotImplementedException();
        }

        public void PlayAudio()
        {
            throw new NotImplementedException();
        }
    }

    public class VideoPlayer : IAudioPlayer, IVideoPlayer, ISubtitlesDisplayer, IMediaLoader
    {
        public void DisplaySubtitles()
        {
            throw new NotImplementedException();
        }

        public void LoadMedia(string filePath)
        {
            throw new NotImplementedException();
        }

        public void PlayAudio()
        {
            throw new NotImplementedException();
        }

        public void PlayVideo()
        {
            throw new NotImplementedException();
        }
    }

    #endregion
}
