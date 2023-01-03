using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathManager : MonoBehaviour
{
    private bool player_alive = true;

    public GameObject death_effect;
    public GameObject Panel;
    public LayerMask fireLayer;
    public void Death()
    {
        if (player_alive)
        {
            player_alive = false;

            //Particle Effect
            Instantiate(death_effect, transform.position, Quaternion.identity);

            Panel.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Hand").gameObject);
            Cursor.visible = true; //Ýmlecin görünümünü kaldýrýyor.
            Cursor.lockState = CursorLockMode.Confined;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="fire")
        {
            Death();
        }
    }




}
