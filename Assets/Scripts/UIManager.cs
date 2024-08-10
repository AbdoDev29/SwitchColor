using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;



public class UIManager : MonoBehaviour
{
    // References
    AudioManager audioManager;

    public bool isStopped = false;
    public bool timeEnd = false;
    [SerializeField] private GameObject gameOverPanel;
    
   


    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
       
    }
 


    private void Update()
    {
        if (timeEnd == true)
        {
           SceneManager.LoadScene("Level_1");
        }
        
    }
       
      

    public void StartGAme()
    {
        audioManager.PlaySound("Click");

        StartCoroutine(LoadScene());
        SceneManager.LoadScene("Level_1");
    }
    

    public void QuitGame()
    {
        Application.Quit();
        audioManager.PlaySound("Click");
    }
    public void StopGame()
    {
        isStopped = true;
        audioManager.PlaySound("Click");

    }
    public void ResumeGame()
    {
        isStopped = false;
        audioManager.PlaySound("Click");

    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.3f);

        timeEnd = true;
    }


 

}


      


        
        
        


