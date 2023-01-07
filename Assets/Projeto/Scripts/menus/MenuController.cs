using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject painelPause;
    public GameObject canvas;
    public PlayerController player;
    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType(typeof(PlayerController)) as PlayerController;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseGame();
           
        }


    }

    void PauseGame()
    {
      
        bool pauseState = painelPause.activeSelf;
        pauseState = !pauseState;


        painelPause.SetActive(pauseState);
        canvas.SetActive(!canvas.activeSelf);

      
        switch (pauseState)
        {
            case true:
                player.fxPrincipal.Pause();
                
                
                break;

            case false:
                
                Time.timeScale = 1;
                player.fxPrincipal.UnPause();
                break;
        }

        
    }

    

}
