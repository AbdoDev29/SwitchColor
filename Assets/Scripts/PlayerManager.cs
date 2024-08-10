using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject stop, resum;
   // [SerializeField] private GameObject resum; 
    public GameObject gameOver;
    public GameObject lose;
    private Camera mainCam;
    PlayerMovement player;
    AudioManager audioManager;
    private UIManager uiManager;
   

    private void Awake()
    {
        player = GetComponent<PlayerMovement>();
        uiManager = FindObjectOfType<UIManager>();
        mainCam = FindAnyObjectByType<Camera>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
 

    // Update is called once per frame
    void Update()
    {


        // Stop and resum game.
        if (uiManager.isStopped)
        {
            Time.timeScale = 0;
            stop.SetActive(false);
            resum.SetActive(true);

        }
        else if (!uiManager.isStopped)
        {
            Time.timeScale = 1;
            resum.SetActive(false);
            stop.SetActive(true);
        }

        // Destroy the player if he fall down.
        if (transform.position.y + 15f < mainCam.transform.position.y)
            gameOver.gameObject.SetActive(true);
       

    }



    // Function death the player.
    public void GameOver()
    {
      
        if (player.isDead == true)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }
}
