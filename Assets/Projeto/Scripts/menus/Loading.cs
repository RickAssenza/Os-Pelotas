using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Loading : MonoBehaviour
{
    public GameObject loadingImage;
    public Text  bar;

    public void LoadScene(int sceneId)
    {
        loadingImage.SetActive(true); 
        StartCoroutine(LoadSceneAsync(sceneId));       
        Time.timeScale = 1;
    }

   IEnumerator LoadSceneAsync(int sceneId)
    {   
        loadingImage.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
   
        yield return null;
        

        
    }
}
