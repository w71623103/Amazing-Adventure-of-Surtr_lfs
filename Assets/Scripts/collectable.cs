using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{
    public string type;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (type == "Heal")
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCore>().model.inventory["heal"])
            {
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<CircleCollider2D>().enabled = false;
            }
        }
        
    }
}
