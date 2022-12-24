using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolLook : MonoBehaviour
{
    RaycastHit hit;

    public Vector3 offset;

    public LayerMask obstacleLayer;
    private void Update()
    {
        //Kameran�n bakt��� yere do�ru silah�m�z�n Rotation � de�i�ecek.
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,Mathf.Infinity,obstacleLayer))
        {
            //hit.point Raycastin �arpt��� *Noktan�n* vector3 bilgilerini tutar.
            //transform.LookAt fonksiyonu ise bakaca�� y�n� ayarlamaya yarar.

            transform.LookAt(hit.point);
            transform.rotation *= Quaternion.Euler(offset);
        }
    }
}
