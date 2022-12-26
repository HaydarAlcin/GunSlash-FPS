using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathManager : MonoBehaviour
{
    private bool player_alive = true;

    public GameObject death_effect;
    public void Death()
    {
        if (player_alive)
        {
            player_alive = false;

            //Particle Effect
            Instantiate(death_effect, transform.position, Quaternion.identity);
        }
    }
}
