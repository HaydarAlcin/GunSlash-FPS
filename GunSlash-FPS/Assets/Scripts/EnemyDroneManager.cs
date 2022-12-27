using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDroneManager : MonoBehaviour
{
    private Transform player;

    public Vector3 offset;

    public float speed;
    public float distance;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        

        //Karaktere Bakma 
        transform.LookAt(player.position);
        //Objemizin Blender da bulunan eksenleri ile Unity içerisinde bulunan eksenleri ayný olmadýðýndna çevirme iþlemi yapýyoruz.
        transform.rotation *= Quaternion.Euler(offset);



        if (transform.position.x - player.position.x < distance && transform.position.y - player.position.y < distance && transform.position.z - player.position.z < distance)
        {

            transform.Translate(Vector3.right* Time.deltaTime*speed);
        }



        //Karaktere doðru hareket etme
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        


    }
}
