using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        LevelManager.SaveLevel(SceneManager.GetActiveScene().buildIndex);
    }

   public void OnPlayerDeath()
    {
        ReloadCurrentLevel();
    }

    private void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
