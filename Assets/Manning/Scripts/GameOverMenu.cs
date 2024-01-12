using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private string _gameScene;
    [SerializeField] private List<GameObject> _toHide;
    [SerializeField] private EndMenuSkip _endMenu;
    [SerializeField] private Canvas _buttons;
    [SerializeField] private AudioSource _audio;
    public float fadeOutDuration = 2.0f;
    private bool _fadeOut;


    private void Update()
    {
        if (Input.anyKeyDown && _endMenu.CanSkip || _endMenu.Force)
        {
            HideObjects();
            _buttons.gameObject.SetActive(true);
            _fadeOut = true;
        }

        if (_fadeOut)
        {
            FadeOutSound();
        }
    }

    private void HideObjects()
    {
        foreach (var obj in _toHide)
        {
            obj.SetActive(false);
        }
    }

    private void FadeOutSound()
    {
        if (_audio.volume > 0)
        {
            _audio.volume -= 0.0075f;
        }
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(_gameScene);
    }

    public void QuitGame()
    {
        #if UNITY_STANDALONE
                Application.Quit();
        #endif
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
