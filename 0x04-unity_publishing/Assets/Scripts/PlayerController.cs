using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public float speed = 200f;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text winLose;
    public Image winLoseBG;
    public GameObject midFrame;
    // // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (health == 0)
        {
            winLose.color = Color.white;
            winLose.text = "Game Over!";
            winLoseBG.color = Color.red;
            midFrame.SetActive(true);
            StartCoroutine(LoadScene(3));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(0, 0, (-speed) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce((-speed) * Time.deltaTime, 0, 0);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
        }
        if (other.gameObject.CompareTag("Goal"))
        {
            winLose.color = Color.black;
            winLose.text = "YOU WIN!";
            winLoseBG.color = Color.green;
            midFrame.SetActive(true);
            StartCoroutine(NextLevel());
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        health = 5;
        score = 0;
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        health = 5;
    }
}
