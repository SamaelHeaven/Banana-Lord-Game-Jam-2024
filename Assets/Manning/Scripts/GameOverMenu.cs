using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private string _gameScene;
    [SerializeField] private List<GameObject> _toHide;
    [SerializeField] private Canvas _buttons;
    [SerializeField] private AudioSource _audio;
    public float fadeOutDuration = 2.0f;
    private bool _fadeOut;


    private void Update()
    {
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
        StartCoroutine(FadeoutAndRestart());
    }

    IEnumerator FadeoutAndRestart()
    {
        _fadeOut = true;

        yield return new WaitForSeconds(2f);

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
