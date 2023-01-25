using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Final : MonoBehaviour
{
    public Text texto;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Idioma") == 1)
        {
            texto.text = ("Parab�ns por ter chego t�o longe!  A hist�ria dos pelotas n�o chegou ao fim! \r\n \r\n(Em breve mais informa��es.)");
        }

        if (PlayerPrefs.GetInt("Idioma") == 2)
        {
            texto.text = ("Congratulations on making it this far!  The history of Os Pelotas is not over yet! \r\n \r\n(Soon more information.)");
        }

        if (PlayerPrefs.GetInt("Idioma") == 3)
        {
            texto.text = ("�Felicidades por haber llegado tan lejos!  La historia de Los Pelotas a�n no ha terminado. \r\n \r\n(Pronto m�s informaci�n.)");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("ChamaCena", 11f);
    }

    void ChamaCena()
    {

        SceneManager.LoadScene("QuartoFliper");
    }

}
