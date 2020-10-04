using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public Button startButton;
    public Button creditsButton;

    public int nextSceneIndex = 1;

    public GameObject creditsPanel;
    public Button exitCreditsButton; // this is the little X in the upper corner of the credits panel

    private void Start()
    {
        startButton.onClick.AddListener(delegate { SceneManager.LoadScene(nextSceneIndex); });
        creditsButton.onClick.AddListener(delegate { creditsPanel.SetActive(true); });
        exitCreditsButton.onClick.AddListener(delegate { creditsPanel.SetActive(false); });

        creditsPanel.SetActive(false);
    }
}
