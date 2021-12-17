using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

    private Animator anime;
    private SpriteRenderer sr;
    private Rigidbody2D myBody;

    public float speed = 3f;
    public float jumpSpeed = 3f;

    private float min_X = -3f, max_X = 3f;

    public Text timerText;
    private int timer;
    public Text scoreText;
    private int score;
    public Text finalScoreText;


    public static bool isGameOver;
    private bool isImmune = false;

    public GameObject immunity;
    private GameObject temp;

    // Use this for initialization
    void Awake () {
        anime = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        myBody = GetComponent<Rigidbody2D>();
        finalScoreText.text = "";
	}

    private void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(CountTime());
        timer = 0;
        score = 0;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update () {
        Move();
        PlayerBounds();
	}

    void PlayerBounds()
    {
        Vector3 temp = transform.position;
        if(temp.x > max_X)
        {
            temp.x = max_X;
        }
        else if(temp.x < min_X)
        {
            temp.x = min_X;
        }

        transform.position = temp;
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 temp = transform.position;

        if (horizontal > 0)
        {
            //going to the right side
            temp.x += speed * Time.deltaTime;
            sr.flipX = false;

            anime.SetBool("Walk", true);

        }
        else if (horizontal < 0)
        {
            //going to the left side
            temp.x -= speed * Time.deltaTime;
            sr.flipX = true;

            anime.SetBool("Walk", true);
        }
        else
        {
            anime.SetBool("Walk", false);
        }

        if(vertical > 0)
        {
            //temp.y += jumpSpeed * Time.deltaTime;
            myBody.velocity = new Vector2(myBody.velocity.x, jumpSpeed);
        }


        transform.position = temp;
        
    }

    IEnumerator CountTime()
    {
        yield return new WaitForSeconds(1f);
        timer++;
        score++;

        timerText.text = "Time: " + timer;
        scoreText.text = "Score: " + score;

        StartCoroutine(CountTime());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(5f);

        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    IEnumerator Immunity()
    {
        yield return new WaitForSecondsRealtime(5f);
        isImmune = false;
        Destroy(temp);
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if (isImmune == false)
        {
            if (target.tag == "Knife")
            {
                Time.timeScale = 0f;
                isGameOver = true;

                finalScoreText.text = "Your Score is: " + score;
                

                StartCoroutine(RestartGame());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bluepotion")
        {
            Destroy(collision.gameObject);
            //Debug.Log("Blue");
            score += 10;
            scoreText.text = "Score: " + score;

        }
        if (collision.gameObject.tag == "redpotion")
        {
            Destroy(collision.gameObject);
            //Debug.Log("Red");
            isImmune = true;
            StartCoroutine(Immunity());
            temp = Instantiate(immunity);
        }
    }
}
