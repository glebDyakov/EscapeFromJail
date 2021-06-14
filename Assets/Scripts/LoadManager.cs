using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour {

    public string sceneName;
    public GameObject gameState;
    public Text percent;
    public GameObject plate;

    void Start() {

        gameState = GameObject.FindGameObjectWithTag("GameState");
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene() {
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(gameState.GetComponent<GameState>().sceneName);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone) {
            gameObject.GetComponent<Image>().fillAmount = asyncOperation.progress;
            percent.text = (asyncOperation.progress * 100).ToString() + "%"; 
            if (asyncOperation.progress >= 0.9f) {
                //Activate the Scene
                Destroy(gameState);
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
