using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputIntroControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
