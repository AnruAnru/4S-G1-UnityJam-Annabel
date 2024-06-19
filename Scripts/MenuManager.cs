using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu, optionMenu, pauseMenu;
    [SerializeField] private Slider sliderVolume;

    private float volume;

    public void ButtonStartOnKlickEvent()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonQuitOnKlickEvent()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ButtonOptionsOnKlickEvent()
    {
        if (pauseMenu == null)
        {
            mainMenu.SetActive(false);
        }
        else
        {
            pauseMenu.SetActive(false);
        }

        optionMenu.SetActive(true);
    }

    public void ButtonBackOnKlickEvent()
    {
        if (pauseMenu == null)
        {
            mainMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(true);
        }

        optionMenu.SetActive(false);
    }

    public void SliderVolumeOnValueChangeEvent()
    {
        volume = sliderVolume.value;
        PlayerPrefs.SetFloat("Volume", volume);
    }

    private void Start()
    {
        volume = PlayerPrefs.GetFloat("Volume");
        sliderVolume.value = volume;
    }

    private void Update()
    {
        if (pauseMenu == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
            }
            else
            {
                pauseMenu.SetActive(true);

                Time.timeScale = 0f;
            }
        }
    }

    public void ButtonBackToGameOnKlickEvent()
    {
        pauseMenu.SetActive(false);

        Time.timeScale = 1f;
    }

    public void ButtonBackMainMenuOnKlickEvent()
    {
        SceneManager.LoadScene(0);
    }
}
