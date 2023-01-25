using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Historia : MonoBehaviour
{
    public int contaHist;
    public GameObject loadingImage;
    public GameObject panelIdioma;
    public GameObject panelMusic;

    // Start is called before the first frame update
    void Start()
    {
        contaHist = PlayerPrefs.GetInt("PrimeiroBotao");
        Debug.Log(PlayerPrefs.GetInt("PrimeiroBotao"));
    }

   
    //public Text  bar;

    public void LoadScene(int sceneId)
    {
        contaHist= 2;
        panelMusic.SetActive(false);
        if(PlayerPrefs.GetInt("PrimeiroBotao") < 1)
        {
            panelIdioma.SetActive(true);
            
        }
        if(PlayerPrefs.GetInt("PrimeiroBotao") > 1)
        {
            if ((PlayerPrefs.GetInt("Troca") == 1))
            {

                loadingImage.SetActive(true);
                StartCoroutine(LoadSceneAsync(10));
                Time.timeScale = 1;
            }
            else
            {
                loadingImage.SetActive(true);
                StartCoroutine(LoadSceneAsync(sceneId));
                Time.timeScale = 1;
            }
            
           
        }
        PlayerPrefs.SetInt("PrimeiroBotao", contaHist);
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        loadingImage.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        yield return null;



    }
}
