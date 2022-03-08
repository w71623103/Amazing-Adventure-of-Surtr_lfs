using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class makes the passplatforms can hold players if it land.
public class PassPlatform : MonoBehaviour
{
    
    [SerializeField] private GameObject box;
    void Start()
    {
        
    }


    void Update()
    {
        
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerCore>().model.characterRB.velocity.y <= 0f)
        {

            box.SetActive(true);

        }
        else if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerCore>().model.characterRB.velocity.y > 0f)
        {
            box.SetActive(false);

        }
    }

}

