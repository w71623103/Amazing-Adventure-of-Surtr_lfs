using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//if the boss is defeated, change to the credit scene
public class SwitchToCredit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            SceneManager.LoadScene("Credit");
        }
    }
}
