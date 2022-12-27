using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{
    public GameObject Hand;
    
    
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

            Hand.transform.LookAt(hit.point);
            Hand.transform.rotation *= Quaternion.Euler(offset);
        }

        //Cooldown
        if (cooldown>0)
        {
            cooldown -= Time.deltaTime;
        }


        //F�RE
        if (Input.GetMouseButtonDown(0)&& cooldown<=0)
        {
            //Create Bullet
            Instantiate(bullet,transform.position,transform.rotation* Quaternion.Euler(90,0,0));
            
            //Cooldown Reset
            cooldown = 0.30f;

            //Fire Sound
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(gunShot);

            //Animations
            GetComponent<Animator>().SetTrigger("shot");
        }
    }
}
