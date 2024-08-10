using UnityEngine;

public class TweenUIStartScene : MonoBehaviour
{
    // References
    AudioManager audio;

    // Virables
    [SerializeField] private GameObject crcileeHolder, startButton;

    private void Awake()
    {
        audio = FindObjectOfType<AudioManager>();
    }
    private void Start()
    {
        LeanTween.scale(crcileeHolder, new Vector3(0.8f, 0.8f, 0.8f), 2f).setEase(LeanTweenType.easeOutElastic).setOnComplete(StartButton);
        audio.PlaySound("StartScene");
        LeanTween.moveLocal(crcileeHolder, new Vector3(0, 0.01f, 0f), .7f).setDelay(2f).setEase(LeanTweenType.easeInOutCubic);
        LeanTween.scale(crcileeHolder, new Vector3(1f, 1f, 1f), 2f).setDelay(1.7f).setEase(LeanTweenType.easeInOutCubic);
    }
    private void StartButton()
    {
        LeanTween.scale(startButton, new Vector3(1.71f, 1.71f, 1.71f), 2f).setEase(LeanTweenType.easeOutElastic);
        audio.PlaySound("StartScene");
    }
}
