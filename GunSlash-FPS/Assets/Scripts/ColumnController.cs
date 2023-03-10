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

    //oyun başladığında direkt aşağı inmesin diye oluşturduğumuz bool değişkeni
    bool broke = false;
    private void Update()
    {
        if (Physics.CheckBox(checkerTransform.position,new Vector3(verticles,2,verticles),Quaternion.identity,player_layer))
        {
            broke = true;
        }

        if (broke)
        {
            //translate fonksiyonunda z ekseni yukarı eksen olduğundan velocity vektörünün z sini düşürüyoruz.
            velocity.z -= Time.deltaTime/100;
            transform.Translate(velocity);
        }
    }
}
