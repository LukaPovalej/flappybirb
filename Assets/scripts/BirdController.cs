using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BirdController : MonoBehaviour
{
    
    public float flyvelocity = 400f;
    private Rigidbody2D body;

    private Vector3 initPosition;
    
    private int score = 0;

    public GameObject scoreboard;

    private bool isPaused = false; 

    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        initPosition = transform.position;
        scoreboard.SetActive(false);
        Button btn = startButton.GetComponent<Button>();
		btn.onClick.AddListener(StartGame);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            body.velocity = Vector2.zero;
            body.AddForce(new Vector2(0, flyvelocity));

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Danger")
        {
            reset();
        }
    }

    void reset() 
    {
        if (ScoreTrack.bestScore < score) 
        {
            ScoreTrack.bestScore = score;
        }
        Time.timeScale = 0f;
        scoreboard.SetActive(true);
        isPaused = true;
        GameObject.FindWithTag("cscore")
            .GetComponent<UnityEngine.UI.Text>().text = score + "";
        GameObject.FindWithTag("bscore")
            .GetComponent<UnityEngine.UI.Text>().text = ScoreTrack.bestScore + "";
    }

    public void updateScore(int amount)
    {
        score += amount;
        GameObject.FindWithTag("ScoreText")
            .GetComponent<UnityEngine.UI.Text>().text = score + "";
    }

    void StartGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        transform.position = initPosition;
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }
}


public class ScoreTrack
{
    public static int bestScore = 0;
}
