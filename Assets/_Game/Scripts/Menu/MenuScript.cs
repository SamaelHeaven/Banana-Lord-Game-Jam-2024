using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private string _introScene;

    public void OpenIntroScene()
    {
        SceneManager.LoadScene(_introScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
