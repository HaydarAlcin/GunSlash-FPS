using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilder : MonoBehaviour
{
    public GameObject Enemy;
   
    public float cooldown=8f;

    // Update is called once per frame
    void Update()
    {
        if (cooldown>0)
        {
            cooldown -= Time.deltaTime;
        }

        else
        {
            cooldown = 8f;
            Instantiate(Enemy, transform.position, Quaternion.identity);
        }
    }
}
