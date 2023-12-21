using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questes : MonoBehaviour
{
   public int questNumber;
   public int wordLength;
   public int[] items;
   public GameObject key;

   public void OnTriggerEnter2D(Collider2D other)
   {
        if(other.tag != "Player" && other.gameObject.GetComponent<Pickup>().id == items[questNumber])
        {    questNumber++;
            Destroy(other.gameObject);
            if (questNumber == wordLength) key.SetActive(true);
        }
   }
}
