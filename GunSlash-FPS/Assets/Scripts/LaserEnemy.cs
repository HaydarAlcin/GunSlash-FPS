using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    RaycastHit hit;

    public LayerMask obstacle;
   
    void Update()
    {
        if (Physics.Raycast(transform.position,transform.forward,out hit,Mathf.Infinity,obstacle))
        {
            GetComponent<LineRenderer>().enabled=true;

            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);

            GetComponent<LineRenderer>().startWidth = 0.05f + Mathf.Sin(Time.time)/25;
        }

        else
        {
            GetComponent<LineRenderer>().enabled = false;
        }
    }
}
