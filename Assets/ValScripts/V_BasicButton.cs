using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class V_BasicButton : MonoBehaviour
{
    // Start is called before the first frame update
   public void RestartGame() {

        SceneManager.LoadScene("FinalScene");
    }

    public void GoToMainMenu()
    {

        SceneManager.LoadScene("UIScene");
    }
}
