using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDroneManager : MonoBehaviour
{
    private Transform player;

    public Vector3 offset;

    public float speed;
    public float distance;
    public bool direction;

    //Ateþ etme süresi
    public float cooldown;

    public GameObject EnemyBullet;
    public AudioClip gunShot;

    public float health = 100;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        FollowPlayer();
        Shot();
        Dead();
    }

    private void FollowPlayer()
    {
        

        //Karaktere Bakma 
        transform.LookAt(player.position);
        //Objemizin Blender da bulunan eksenleri ile Unity içerisinde bulunan eksenleri ayný olmadýðýndna çevirme iþlemi yapýyoruz.
        transform.rotation *= Quaternion.Euler(offset);




        //uzaklýðýn mutlak deðerine göre karaktere yaklaþýyor eðer min yaklaþmaya gelirsek etrafýnda dönmeye baþlýyor.
        if (Vector3.Distance(transform.position,player.position)>=distance)
        {
            direction = !direction;
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            
        }



        
        else
        {

            if (direction)
            {
                transform.RotateAround(player.position, transform.forward, Time.deltaTime * speed * Random.Range(0.8f, 10f));
            }
            //RotateAround fonksiyonu girdiðimiz objenin etrafýnda verdiðimiz açý kadar dönmeyi saðlýyor.
            

            else
            {
                transform.RotateAround(player.position, transform.forward, Time.deltaTime * -speed * Random.Range(0.8f, 10f));
            }
            
            //transform.Translate(Vector3.right * Time.deltaTime * speed);
            //transform.Translate(Vector3.back * Time.deltaTime * speed * Mathf.Sin(Time.time));
        }
        


    }

    private void Shot()
    {
        
        if (cooldown>0)
        {
           
            cooldown -= Time.deltaTime;
        }

        else
        {
            cooldown = Random.Range(1.8f, 3f);

            //Shot
            transform.GetChild(0).GetComponent<Animator>().SetTrigger("shot");
            Instantiate(EnemyBullet,transform.position,transform.rotation*Quaternion.Euler(new Vector3(-90,0,0)));
            GetComponent<AudioSource>().PlayOneShot(gunShot);
        }
    }

    public void Damage()
    {
        health -= 20;
    }

    private void Dead()
    {
        if (health<=0)
        {
            Destroy(gameObject);
        }
    }
}
