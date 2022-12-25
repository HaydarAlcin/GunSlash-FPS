using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 100f;

    public float lifeTime = 5f;
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        lifeTime -= Time.deltaTime;
        if (lifeTime<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
