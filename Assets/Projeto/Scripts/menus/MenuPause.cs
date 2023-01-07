using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum Gamestate
{
    GAMEPLAY,
    PAUSE

}


public class MenuPause : MonoBehaviour
{
    public Gamestate currentState;

    public GameObject pauseMenu;
    public PlayerController player;
    
    

    void Start()
    {
        player = FindObjectOfType(typeof(PlayerController)) as PlayerController;

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            currentState = Gamestate.PAUSE;
            Time.timeScale = 0;
            player.fxPrincipal.Pause();
            //Cursor.lockState = CursorLockMode.Confined;
            //Cursor.visible = true; ;
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        currentState = Gamestate.PAUSE;
        Time.timeScale = 0;
        player.fxPrincipal.Pause();
        player.StopCoroutine("Atirar");
        
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        currentState = Gamestate.GAMEPLAY;
        Time.timeScale = 1;
        player.fxPrincipal.UnPause();
        player.enabled = true;
        player.StartCoroutine("Atirar");
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

    }

   /* public void ChamaCena(int sceneId)
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneId);
    }*/
}

