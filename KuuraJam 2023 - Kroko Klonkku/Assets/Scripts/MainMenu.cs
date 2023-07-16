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
    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject settingsButton;
    [SerializeField]
    private GameObject creditsButton;
    [SerializeField]
    private GameObject quitButton;
    [SerializeField]
    private GameObject title;
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip saunaClip;
    [SerializeField]
    private Animator[] animators;

    // Start is called before the first frame update
    void Start()
    {
        creditsScreen.SetActive(false);
        settingsScreen.SetActive(false);
        playButton.SetActive(true);
        creditsButton.SetActive(true);
        quitButton.SetActive(true);
        settingsButton.SetActive(true);
        title.SetActive(true);
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("playSaunaSound", 0f, 7f);
        InvokeRepeating("playRandomAnimation", 3f, 10f);
    }

    public void onPlayButtonClick()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Play");
    }

    public void onCreditsButtonClick()
    {
        creditsScreen.SetActive(true);
        creditsButton.SetActive(false);
        quitButton.SetActive(false);
        settingsButton.SetActive(false);
        playButton.SetActive(false);
        title.SetActive(false);
    }

    public void onSettingsButtonClick()
    {
        settingsScreen.SetActive(true);
        creditsButton.SetActive(false);
        quitButton.SetActive(false);
        settingsButton.SetActive(false);
        playButton.SetActive(false);
        title.SetActive(false);
    }

    public void onCloseButtonClick()
    {
        settingsScreen.SetActive(false);
        creditsScreen.SetActive(false);
        creditsButton.SetActive(true);
        quitButton.SetActive(true);
        settingsButton.SetActive(true);
        playButton.SetActive(true);
        title.SetActive(true);
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

    private void playRandomAnimation()
    {
        int randomAnimation = Random.Range(0, animators.Length);
        
        Debug.Log(randomAnimation);
        animators[randomAnimation].Play("Animation");
    }
}
