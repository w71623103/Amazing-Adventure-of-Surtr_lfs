using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHpBar : MonoBehaviour
{
    [SerializeField] private GameObject show;
    private float defaultScaleX;
    private float hpPer;
    // Start is called before the first frame update
    void Start()
    {
        defaultScaleX = transform.localScale.x;
        
    }


    // Update is called once per frame
    void Update()
    {
        if (show == null) show = GameObject.FindGameObjectWithTag("Enemy");

        if(show != null) hpPer = show.GetComponent<EnemyCore>().getHpPer();

        transform.localScale = new Vector3(defaultScaleX * hpPer, transform.localScale.y, transform.localScale.z);
        
    }
}
