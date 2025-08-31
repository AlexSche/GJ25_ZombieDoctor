using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        DontDestroyOnLoad(AudioManager.instance);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void SetVolume()
    {
        AudioManager.instance.masterVolume = masterSlider.value;
        AudioManager.instance.musicVolume = musicSlider.value;
        AudioManager.instance.sfxVolume = sfxSlider.value;
    }
}
