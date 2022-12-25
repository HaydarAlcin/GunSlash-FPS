using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    private CharacterController controller;
    public float speed;


    //Camera Controller
    public float mouseSens = 100f;
    private float xRotation = 0f; //Mouse un yukar� ve a�a�� s�n�r�n� belirlemek i�in olu�turdu�umuz de�i�ken


   //Jump and Gravity Check 
    private Vector3 velocity; //Yer�ekimi vekt�r�
    private float gravity = -9.81f; //Yer�ekimi b�y�kl���

    public Transform groundChecker; //Kontrol eden objemizin transformu
    public float groundCheckerRadius; //Olu�turdu�umuz hayali k�renin �ap�
    public LayerMask obstacleLayer;
    public bool isGrounded;

    public float jumpHeight = 0.1f; // Max Y�kseklik de�eri
    public float gravityControl = 100f; //Yer�ekimini b�ld���m�z say�y� de�i�ken yapt�k Unity �zerinden de�i�tirmek daha kolay olsun diye
    public float jumpSpeed = 100f;
    
    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        //Cursor
        Cursor.visible = false; //�mlecin g�r�n�m�n� kald�r�yor.
        Cursor.lockState = CursorLockMode.Locked;  //�mleci ne akdar hareket ettirirsek ettirelim hep ortaya sabitliyor.
    }
    private void Update()
    {
        //Karakter yerde mi?
        isGrounded = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, obstacleLayer);

        //Movement                                         //x Ekseni                                   //z Ekseni
        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        //Hareketimizin sabit olmas� i�in ayr� olarak time deltatime ile �arpma yapabiliriz.
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;
        controller.Move(moveVelocity);


        //Camera Controller
        transform.Rotate(0, Input.GetAxis("Mouse X")* Time.deltaTime* mouseSens, 0);
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSens;
        
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Mathf.Clamp ile s�n�r belirliyoruz.
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation,0,0);

        


        //Jump and Gravity Check
        if (!isGrounded)
        {
            speed = Mathf.Lerp(speed, jumpSpeed, 1f*Time.deltaTime); //Mathf.Lerp fonksiyonu verilen iki de�er aras�nda belirledi�imiz s�re i�erisinde artma veya azalmay� ger�ekle�tirir.
            velocity.y += gravity * Time.deltaTime/ gravityControl;
            
        }
        else
        {
            velocity.y = -0.01f;
            speed = 10f;
        }

        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight*-2f*gravity/gravityControl);
        }
        controller.Move(velocity);
        
        
    }
}
