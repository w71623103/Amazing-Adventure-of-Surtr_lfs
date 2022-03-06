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
            collision.GetComponent<PlayerCore>().model.respawnPos = new Vector3(1f, 0.0850000009f, 0);
            SceneManager.LoadScene(nextSceneName);
        }
           
    }

}
