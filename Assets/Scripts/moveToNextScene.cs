using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveToNextScene : MonoBehaviour
{
    [SerializeField] private string nextSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (nextSceneName == "second") collision.GetComponent<PlayerCore>().model.respawnPos = new Vector3(1f, 0.0850000009f, 0);
            else if (nextSceneName == "final") collision.GetComponent<PlayerCore>().model.respawnPos = new Vector3(-0.129999995f, 2.49000001f, 0);
            SceneManager.LoadScene(nextSceneName);
        }
           
    }

}
