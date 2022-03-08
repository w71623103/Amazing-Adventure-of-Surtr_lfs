using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class shows the boss fight ui if it is the right scene
public class ShowBossUi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "final")
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
