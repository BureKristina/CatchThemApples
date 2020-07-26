using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorScript : MonoBehaviour
{
  public GameObject basket;

  void Awake()
  {
    basket = GameObject.Find("Basket");
  }

  void OnTriggerEnter2D(Collider2D target)
  {
    if(target.tag == "RedApple")
    {
      target.gameObject.SetActive(false);
      basket.GetComponent<BasketScript>().ModifyScore(-50);

    } else if(target.tag == "GreenApple")
    {
      target.gameObject.SetActive(false);
      basket.GetComponent<BasketScript>().ModifyScore(-100);

    } else if(target.tag == "GoldenApple")
    {
      target.gameObject.SetActive(false);
      basket.GetComponent<BasketScript>().ModifyScore(-150);
      
    } else if(target.tag == "EatenApple")
    {
      target.gameObject.SetActive(false);

    }
  }
}
