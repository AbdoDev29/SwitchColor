using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerMovement playerMovement;


    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    void Update()
    {
        if(playerMovement.isDead == false)
        {
            if (player.transform.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            }
        }

    }
}
