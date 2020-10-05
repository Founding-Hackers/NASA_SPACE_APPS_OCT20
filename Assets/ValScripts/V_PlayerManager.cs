using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class V_PlayerManager : MonoBehaviour
{
    #region Singleton

    public static V_PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

    public V_CharacterStats charStats;
    private int xpPM;
    public TextMeshProUGUI xpUI;

    public AudioClip gameMusic;

    void Start()
    {
        charStats = player.GetComponent<V_CharacterStats>();
    
    }

    void Update()
    {
        xpPM = charStats.xp;
        xpUI.SetText("XP: " + xpPM);
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene("FinalScene");
    }

}
