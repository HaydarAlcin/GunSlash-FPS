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
        //Kameranýn baktýðý yere doðru silahýmýzýn Rotation ý deðiþecek.
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,Mathf.Infinity,obstacleLayer))
        {
            //hit.point Raycastin çarptýðý *Noktanýn* vector3 bilgilerini tutar.
            //transform.LookAt fonksiyonu ise bakacaðý yönü ayarlamaya yarar.

            transform.LookAt(hit.point);
            transform.rotation *= Quaternion.Euler(offset);
        }
    }
}
