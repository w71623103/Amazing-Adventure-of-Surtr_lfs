using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitGame : MonoBehaviour
{
    private float timer = 0f;
    [SerializeField] private GameObject PAK;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 3) timer += Time.deltaTime;
        if (timer > 3f)
        {
            PAK.SetActive(true);
            if (Input.anyKeyDown) 
            {
                Application.Quit();
            }
        }
    }
}
