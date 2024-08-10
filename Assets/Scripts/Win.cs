using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour
{
    // Slider
    [SerializeField] Slider slider;
    Transform player;
    Transform finishLine;
    float maxDistace;

    // Win panel
    TextMeshProUGUI nextLevelText;
    [SerializeField] int numbreLevel;
    PlayerMovement playerMovement;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        finishLine = GameObject.FindGameObjectWithTag("Finish").transform;
        maxDistace = GetDistance();
        playerMovement = FindObjectOfType<PlayerMovement>();

    

    }

    void Update()
    {
        if (player.position.y <= maxDistace && player.position.y <= finishLine.position.y)
        {
            float distance = 1 - (GetDistance() / maxDistace);
            SetValue(distance);
        }

        // Win panel
        if (playerMovement.win.activeSelf)
        {
            if(SceneManager.GetActiveScene().buildIndex < 7)
            {
            nextLevelText = GameObject.FindGameObjectWithTag("TextNextLevel").GetComponent<TextMeshProUGUI>();
            nextLevelText.text = "Next To Level " + numbreLevel;

            }
            else
            {
                nextLevelText.text = "The game levels are completed. We will work on adding more stages. Would you like to replay the game again?";
            }
        }
      

    }

    float GetDistance()
    {
        return Vector2.Distance(player.position, finishLine.position);
    }
    void SetValue(float D)
    {
        slider.value = D;
    }
}
