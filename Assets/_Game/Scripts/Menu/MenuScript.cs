using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void OpenIntroScene()
    {
        SceneManager.LoadScene("_Game/Scenes/InfoScene");
    }
    
    public void OpenGameScene()
    {
        SceneManager.LoadScene("_Game/Scenes/Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
