using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject creditsScreen;
    [SerializeField]
    private GameObject settingsScreen;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip saunaClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        creditsScreen.SetActive(false);
        settingsScreen.SetActive(false);
        InvokeRepeating("playSaunaSound", 0f, 7f);
    }

    public void onPlayButtonClick()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Play");
    }

    public void onCreditsButtonClick()
    {
        creditsScreen.SetActive(true);
    }

    public void onSettingsButtonClick()
    {
        settingsScreen.SetActive(true);
    }

    public void onCloseButtonClick()
    {
        settingsScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }

    public void onQuitButtonClick()
    {
        Application.Quit();
        Debug.Log("Quit");

    }

    private void playSaunaSound()
    {
        audioSource.PlayOneShot(saunaClip);
    }
}
