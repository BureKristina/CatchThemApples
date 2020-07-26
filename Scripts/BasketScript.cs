using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketScript : MonoBehaviour
{
  public Text scoreText;
  public GameObject[] hearths;

  private float speed = 6f;
  private float maxX = 7f;
  private float minX = -7f;

  private int score;
  private int lives;

  void Awake()
  {
    lives = 3;
  }

  void Update()
  {
    MoveBasket();
  }

  void MoveBasket()
  {
    float direction = Input.GetAxis("Horizontal");
    Vector3 tempPos = transform.position;

    if(direction > 0) //move to the right
    {
      tempPos.x += speed * Time.deltaTime;
    } else if(direction < 0) //move to the left
    {
      tempPos.x -= speed * Time.deltaTime;
    }

    if(tempPos.x < minX)
    {
      tempPos.x = minX;
    }
    if(tempPos.x > maxX)
    {
      tempPos.x = maxX;
    }

    transform.position = tempPos;
  }

  public void ModifyScore(int value)
  {
    score += value;
    scoreText.text = "Score: " + score;
  }

  void ModifyLife()
  {
    if(lives > 0)
    {
      hearths[lives].gameObject.GetComponent<Animator>().Play("HearthEmpty");
    } else
    {
      //game over
      SceneManager.LoadScene("GameOver");
    }
  }

  void OnTriggerEnter2D(Collider2D target)
  {
    if(target.tag == "RedApple") //increase score for red apple
    {
      target.gameObject.SetActive(false);
      ModifyScore(100);

    } else if(target.tag == "GreenApple")
    {
      target.gameObject.SetActive(false);
      ModifyScore(150);

    } else if(target.tag == "GoldenApple")
    {
      target.gameObject.SetActive(false);
      ModifyScore(200);

    } else if(target.tag == "EatenApple") //decrease life
    {
      target.gameObject.SetActive(false);
      lives--;
      ModifyLife();
    }
  }
} //class
