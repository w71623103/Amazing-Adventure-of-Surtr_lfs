using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    GetComponent<AudioSource>().PlayOneShot(iceCreamClip);
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
