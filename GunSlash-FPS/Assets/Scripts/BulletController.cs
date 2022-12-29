using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 100f;

    public float lifeTime = 5f;

    public bool enemyBullet = false;
    public float bullet_radius = 0.5f;
    public LayerMask player_layer;

    public GameObject HitParticle;

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        lifeTime -= Time.deltaTime;
        if (lifeTime<=0)
        {
            Destroy(this.gameObject);
        }


        //EnemyBullet
        if (enemyBullet)
        {
            if (Physics.CheckSphere(transform.position,bullet_radius,player_layer))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeathManager>().Death();
            }
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameObject drone = other.transform.parent.gameObject;
            drone.GetComponent<EnemyDroneManager>().Damage();

            Instantiate(HitParticle, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

        Instantiate(HitParticle, transform.position, transform.rotation);
        Destroy(this.gameObject);


    }

    
    


}
