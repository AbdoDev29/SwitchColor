using UnityEngine;

public class StartScene : MonoBehaviour
{
  public void StartGame()
    {
        FindObjectOfType<LevelManager>().LoadLastLevel();
    }
}
