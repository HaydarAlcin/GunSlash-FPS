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

        //Kameranýn baktýðý yere doðru silahýmýzýn Rotation ý deðiþecek.
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,Mathf.Infinity,obstacleLayer))
        {
            //hit.point Raycastin çarptýðý *Noktanýn* vector3 bilgilerini tutar.
            //transform.LookAt fonksiyonu ise bakacaðý yönü ayarlamaya yarar.

            transform.LookAt(hit.point);
            transform.rotation *= Quaternion.Euler(offset);
        }

        if (cooldown>0)
        {
            cooldown -= Time.deltaTime;
        }

        //FÝRE
        if (Input.GetMouseButtonDown(0)&& cooldown<=0)
        {
            Instantiate(bullet,firePoint.position,transform.rotation* Quaternion.Euler(90,0,0));
            cooldown = 1f;

            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(gunShot);
        }
    }
}
