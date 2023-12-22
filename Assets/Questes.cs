using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questes : MonoBehaviour
{
   public int questNumber;
   public int  wordLength;
   public int[] items;
   public GameObject key;
   public GameObject Quest;
 
    public GameObject[] word;  // = new GameObject[wordLength] ;

   public void OnTriggerEnter2D(Collider2D other)
   {
        // npc = GameObject.FindGameObjectWithTag("npc").transform;
        if(other.tag != "Player" && questNumber < wordLength && other.gameObject.GetComponent<Pickup>().id == items[questNumber])
        {   
            questNumber++;
            // word[questNumber-1] = other.gameObject;  
            Destroy(other.gameObject);
            if (questNumber == wordLength) 
            {
                key.SetActive(true);
                Quest.SetActive(false);
                foreach(var letter in word) letter.SetActive(true);
                
                // foreach(var letter in word)
                // {
                //     Vector2 npcPos = new Vector2(npc.position.x - 2, npc.position.y - 1);
                //     Instantiate(letter, npcPos, Quaternion.identity);
                // }
                
                
            }
        }
   }
}
