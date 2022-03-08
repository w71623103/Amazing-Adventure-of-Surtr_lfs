using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//initialize cinemachine and player start position
public class initializer : MonoBehaviour
{
    [SerializeField] private GameObject cm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = collision.GetComponent<PlayerCore>().model.respawnPos;
            cm.GetComponent<CinemachineVirtualCamera>().Follow = collision.gameObject.transform;
            Destroy(gameObject);
        }
    }
}
