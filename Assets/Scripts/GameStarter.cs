using FMOD.Studio;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    // audio
    private EventInstance themeMusic;
    void Start()
    {
        SetCameraPosition();
        themeMusic = AudioManager.instance.CreateSoundInstance(FModEvents.instance.mainTheme);
        themeMusic.start();
    }

    private static void SetCameraPosition()
    {
        Camera.main.transform.position = new Vector3(0, 3, -9.85f);
    }
}
