using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 1f;

    public void LoadGameOver()
    {
        StartCoroutine(DelayForSeconds());
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadNextScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 1);
    }
        public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator DelayForSeconds()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(2);
    }
}
