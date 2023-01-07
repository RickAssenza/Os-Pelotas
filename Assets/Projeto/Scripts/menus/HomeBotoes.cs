using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeBotoes : MonoBehaviour
{
    public int numFase;

    public GameObject loadingImage;
    public Text bar;



    public void Start()
    {
        numFase = PlayerPrefs.GetInt("Spawn");
    }

    public void LoadScene(int sceneId)
    {
        loadingImage.SetActive(true);
        StartCoroutine(LoadSceneAsync(sceneId));
        numFase = sceneId;
        PlayerPrefs.SetInt("Spawn", numFase);
    }

    
    IEnumerator LoadSceneAsync(int sceneId)
     {
         loadingImage.SetActive(true);

         AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

         yield return null;



     }
}
