using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//damage enemy if hit
public class PlayerAttackEffect : MonoBehaviour
{
    [SerializeField] private float atk = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(collision.gameObject.GetComponent<EnemyCore>().takeDamage(atk, transform.position.x))
            {
                if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCore>().model.healNum <= 2)
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCore>().model.healNum++;
            }
        }
    }

}
