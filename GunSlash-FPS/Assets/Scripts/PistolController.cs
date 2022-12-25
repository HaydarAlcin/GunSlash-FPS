using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{
    RaycastHit hit;

    public Vector3 offset;

    public LayerMask obstacleLayer;

    //Fire
    public GameObject bullet;
    public Transform firePoint;

    private float cooldown;
    public AudioClip gunShot;


    private void Update()
    {

        //LOOK

        //Kameran�n bakt��� yere do�ru silah�m�z�n Rotation � de�i�ecek.
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,Mathf.Infinity,obstacleLayer))
        {
            //hit.point Raycastin �arpt��� *Noktan�n* vector3 bilgilerini tutar.
            //transform.LookAt fonksiyonu ise bakaca�� y�n� ayarlamaya yarar.

            transform.LookAt(hit.point);
            transform.rotation *= Quaternion.Euler(offset);
        }

        if (cooldown>0)
        {
            cooldown -= Time.deltaTime;
        }

        //F�RE
        if (Input.GetMouseButtonDown(0)&& cooldown<=0)
        {
            Instantiate(bullet,firePoint.position,transform.rotation* Quaternion.Euler(90,0,0));
            cooldown = 1f;

            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(gunShot);
        }
    }
}
