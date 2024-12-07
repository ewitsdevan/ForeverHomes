// Created by Devan Laczko, 18/10/2024
// Updated 07/12/2024

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILoading : MonoBehaviour
{
    public Image _loadingBar;
    public float loadDelay = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.activeSelf)
        {
            //StartCoroutine(FinishLoading());
        }
    }

    private void OnEnable()
    {
        _loadingBar.fillAmount = 0;
    }

    public void LoadGameScene()
    {
        StartCoroutine(LoadScene("GameScene"));
    }

    public void LoadMenuScene()
    {
        // Reset everything
        UIStickerManager.repairFurnitureEarned = false;
        UIStickerManager.sewingEarned = false;
        UIStickerManager.gramaphoneEarned = false;
        UIStickerManager.paintingEarned = false;
        UIStickerManager.completionEarned = false;
        
        StartCoroutine(LoadScene("MenuScene"));
    }
    
    public void LoadOpenScene()
    {
        StartCoroutine(LoadScene("OpenScene"));
    }

    public void LoadSewingMinigame()
    {
        StartCoroutine(LoadScene("UISewingCurtainScene"));
    }

    public void LoadPaintingMinigame()
    {
        StartCoroutine(LoadScene("PaintingScene"));
    }

    public void LoadCleaningGame()
    {
        StartCoroutine(LoadScene("CleaningScene"));
    }

    public void LoadEndScene()
    {
        StartCoroutine(LoadScene("EndingScene"));
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return new WaitForSeconds(loadDelay);
        
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(sceneName);
        while (!loadLevel.isDone)
        {
            _loadingBar.fillAmount = Mathf.Clamp01(loadLevel.progress / 0.9f);
            yield return null;
        }
    }
}
