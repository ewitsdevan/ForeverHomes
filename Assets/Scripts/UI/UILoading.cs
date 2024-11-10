// Created by Devan Laczko, 18/10/2024
// Updated 19/10/2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILoading : MonoBehaviour
{
    public Image _loadingBar;
    
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.activeSelf)
        {
            //StartCoroutine(FinishLoading());
        }
    }

    public void LoadGameScene()
    {
        StartCoroutine(LoadScene("GameScene"));
    }

    public void LoadMenuScene()
    {
        StartCoroutine(LoadScene("MenuScene"));
    }
    
    public void LoadOpenScene()
    {
        StartCoroutine(LoadScene("Opening"));
    }

    public void LoadSewingMinigame()
    {
        StartCoroutine(LoadScene("UISewingCurtainScene"));
    }

    IEnumerator LoadScene(string sceneName)
    {
        gameObject.GetComponent<UIAutoAnimation>().EntranceAnimation();
        yield return new WaitForSeconds(1.0f);
        
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(sceneName);
        while (!loadLevel.isDone)
        {
            _loadingBar.fillAmount = Mathf.Clamp01(loadLevel.progress / 0.9f);
            yield return null;
        }
    }
}
