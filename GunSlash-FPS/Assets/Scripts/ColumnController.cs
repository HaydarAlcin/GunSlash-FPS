using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnController : MonoBehaviour
{
    public LayerMask player_layer;
    public Transform checkerTransform;

    Vector3 velocity;

    public float verticles;

    bool broke = false;
    private void Update()
    {
        if (Physics.CheckBox(checkerTransform.position,new Vector3(verticles,2,verticles),Quaternion.identity,player_layer))
        {
            broke = true;
        }

        if (broke)
        {
            velocity.z -= Time.deltaTime/300;
            transform.Translate(velocity);
        }
    }
}
