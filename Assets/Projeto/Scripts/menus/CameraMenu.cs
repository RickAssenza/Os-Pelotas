using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenu : MonoBehaviour
{
    public float offsetX = 3f;
    public float smooth = 0.1f;

    //Limites da camera.
    public float limiteUp;
    public float limiteDown;
    public float limiteLeft;
    public float limiteRight;

    private Transform player;
    private float playerX; //Vai controlar o player no eixo X.
    private float playerY;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<JosecaTrem>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            playerX = Mathf.Clamp(player.position.x, limiteLeft, limiteRight);
            playerY = Mathf.Clamp(player.position.y + 1.5f, limiteDown, limiteUp);

            transform.position = new Vector3(player.position.x, player.position.y + 2, -10);
        }
    }

}
