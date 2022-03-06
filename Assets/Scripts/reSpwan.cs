using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reSpwan : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = player.GetComponent<PlayerCore>().model.respawnPos;
            SceneManager.LoadScene(player.GetComponent<PlayerCore>().model.respawnSceneName);
        }
    }
}
