using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnController : MonoBehaviour
{
    public LayerMask player_layer;
    public Transform checkerTransform;

    Vector3 velocity;

    //Uzunluk
    public float verticles;

    //oyun ba�lad���nda direkt a�a�� inmesin diye olu�turdu�umuz bool de�i�keni
    bool broke = false;
    private void Update()
    {
        if (Physics.CheckBox(checkerTransform.position,new Vector3(verticles,2,verticles),Quaternion.identity,player_layer))
        {
            broke = true;
        }

        if (broke)
        {
            //translate fonksiyonunda z ekseni yukar� eksen oldu�undan velocity vekt�r�n�n z sini d���r�yoruz.
            velocity.z -= Time.deltaTime/100;
            transform.Translate(velocity);
        }
    }
}
