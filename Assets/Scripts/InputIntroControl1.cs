using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//show the input intro text, special for the heal text, because it need to find if the player has the healing item
public class InputIntroControl1 : MonoBehaviour
{
    private bool hasPlayedAudio = false;
    [SerializeField] private AudioClip iceCreamClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            if (collision.GetComponent<PlayerCore>().model.inventory["heal"])
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                if (!hasPlayedAudio)
                {
                    hasPlayedAudio = true;
                }
            }
                
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
