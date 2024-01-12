using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private string _introScene;
    [SerializeField] private string _gameScene;

    public void OpenIntroScene()
    {
        SceneManager.LoadScene(_introScene);
    }
    
    public void OpenGameScene()
    {
        SceneManager.LoadScene(_gameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
