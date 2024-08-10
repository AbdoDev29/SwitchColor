using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    
    [SerializeField] int levelNumber;
 
    private void Start()
    {
        // print(PlayerPrefs.GetInt("LastLevel"));
        if (PlayerPrefs.GetInt("LastLevel") == 0)
        {
            PlayerPrefs.SetInt("LastLevel", 1);
        }
       levelNumber = System.Convert.ToInt32(SceneManager.GetActiveScene().name);
       if(levelNumber!= PlayerPrefs.GetInt("LastLevel"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevel").ToString());
        }
    }
    private void Update()
    {
        
    }

    public void RestartLevel()
    {
       
        SceneManager.LoadScene(levelNumber.ToString());
    }
    public void NextLevel()
    {
        int lastLevel = PlayerPrefs.GetInt("LastLevel"); 
        if (levelNumber+1 > lastLevel)
        {
            PlayerPrefs.SetInt("LastLevel", levelNumber + 1);
        }
        SceneManager.LoadScene((levelNumber+ 1).ToString());

    }
    
    public void ReplayTheGame()
    {
        PlayerPrefs.DeleteKey("LastLevel");
        SceneManager.LoadScene("1");
    }
 
}

