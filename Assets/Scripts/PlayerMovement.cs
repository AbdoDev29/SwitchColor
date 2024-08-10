using UnityEngine;
using UnityEngine.EventSystems;



public class PlayerMovement : MonoBehaviour
{
  
    public float speed;
    public Color ColorBambi;
    public Color colorGreen;
    public Color colorMilky;
    public Color colorOrange;
    public GameObject counterScore;

    public ParticleSystem particatBambi;
    public ParticleSystem particatGreen;
    public ParticleSystem particatMilky;
    public ParticleSystem particatOrange;

    public bool isDead = false;
    public GameObject win;
    public string selectColor;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    
    // References
    AudioManager audioManager;
    PlayerManager playerManager;
    UIManager uiManager;
  

    Score score;
    [SerializeField] GameObject particals;
    float timerWin;
    float timerLose;
    int color;
   [SerializeField] bool isCollide;

    bool isGameStrted;
    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        score = FindObjectOfType<Score>();
        audioManager = FindObjectOfType<AudioManager>();
        playerManager = GetComponent<PlayerManager>();
        uiManager = FindObjectOfType<UIManager>();
        
    }
    private void Start()
    {
        color = Random.Range(1, 4);
        SelectColor();
        Time.timeScale = 1;
        rb.gravityScale = 3;
        timerWin = 0;
        timerLose = 0;
        isCollide = false;
    }



    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!uiManager.isStopped)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            
             rb.velocity = Vector2.up * speed;
            audioManager.PlaySound("Tap");
        }
        // Give little time to show the effect when the ball collide with the ring
        if (isCollide)
        {
            if (timerLose < .4f)
            {
                timerLose += 1 * Time.deltaTime;
                rb.isKinematic = true;
                rb.velocity = Vector2.zero;
               
            }
           else if (timerLose >= .4f)
                playerManager.gameOver.gameObject.SetActive(true);
        }

     
    }
           
   
            
       





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != ("Coin") && collision.gameObject.tag != "ColorChanger")
        {
            if (selectColor != collision.gameObject.tag)
            {
                isCollide = true;
               
                
                if (selectColor == "Bambi")
                {
                    ParticleSystem part = Instantiate(particatBambi, transform.position, Quaternion.identity);
                    Destroy(part.gameObject, 2);
                }
                if (selectColor == "Green")
                {
                    ParticleSystem part = Instantiate(particatGreen, transform.position, Quaternion.identity);
                    Destroy(part.gameObject, 2);
                }
                if (selectColor == "Milky")
                {
                    ParticleSystem part = Instantiate(particatMilky, transform.position, Quaternion.identity);
                    Destroy(part.gameObject, 2);
                }
                if (selectColor == "Orange")
                {
                    ParticleSystem part = Instantiate(particatOrange, transform.position, Quaternion.identity);
                    Destroy(part.gameObject, 2);
                }
               
               
               
            }

        }
        else
        {
           
            if (collision.gameObject.tag == "Coin")
            {
                Destroy(collision.gameObject);
                audioManager.PlaySound("Coin");
                score.scoreCoins += 1;
                score.totalScore += 1;
            }
            else if(collision.gameObject.tag== "ColorChanger")
            {
                if (collision.GetComponent<NumberOfRibs>().numberOfRibs == 4)
                {
                    color = Random.Range(1, 4);
                    SelectColor();
                }
                else if (collision.GetComponent<NumberOfRibs>().numberOfRibs == 3) 
                { 
                    color = Random.Range(1, 3);
                    SelectColor();
                }
                else if(collision.GetComponent<NumberOfRibs>().numberOfRibs == 1)
                {
                    color = Random.Range(1, 3);
                    SelectColor();
                }
              


                audioManager.PlaySound("Transformation");
                Destroy(collision.gameObject);
                
            }

        }




    }


    private void OnCollisionStay2D(Collision2D collision)
    {
      
       if (collision.gameObject.tag == ("Finish"))
        {
            rb.gravityScale = -1;
            particals.SetActive(true);

            if(timerWin<3)
            timerWin += 1 * Time.deltaTime;

            if(timerWin>=1)
            win.SetActive(true);
            
        }
    }

    void SelectColor()
    {
       

        switch (color) 
        {
            case 1:
                selectColor = "Bambi";
                sr.color = ColorBambi;

                break;

            case 2:
                selectColor = "Milky";
                sr.color = colorMilky;
                break;

            case 3:
                selectColor = "Green";
                sr.color = colorGreen;
 
                break;
            case 4:
                selectColor = "Orange";
                sr.color = colorOrange;
                break;
        }
           

    }


}
