using FMOD.Studio;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    // audio
    private EventInstance themeMusic;
    void Start()
    {
        themeMusic = AudioManager.instance.CreateSoundInstance(FModEvents.instance.mainTheme);
        themeMusic.start();
    }
}
