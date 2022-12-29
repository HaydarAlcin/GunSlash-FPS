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

    //oyun baþladýðýnda direkt aþaðý inmesin diye oluþturduðumuz bool deðiþkeni
    bool broke = false;
    private void Update()
    {
        if (Physics.CheckBox(checkerTransform.position,new Vector3(verticles,2,verticles),Quaternion.identity,player_layer))
        {
            broke = true;
        }

        if (broke)
        {
            //translate fonksiyonunda z ekseni yukarý eksen olduðundan velocity vektörünün z sini düþürüyoruz.
            velocity.z -= Time.deltaTime/100;
            transform.Translate(velocity);
        }
    }
}
