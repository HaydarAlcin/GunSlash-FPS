using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDroneManager : MonoBehaviour
{
    private Transform player;

    public Vector3 offset;

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
        transform.LookAt(Camera.main.transform.position);
        //Objemizin Blender da bulunan eksenleri ile Unity i�erisinde bulunan eksenleri ayn� olmad���ndna �evirme i�lemi yap�yoruz.
        transform.rotation *= Quaternion.Euler(offset);

    }
}
