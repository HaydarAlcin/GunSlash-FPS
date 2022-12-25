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
    private float xRotation = 0f; //Mouse un yukarý ve aþaðý sýnýrýný belirlemek için oluþturduðumuz deðiþken


   //Jump and Gravity Check 
    private Vector3 velocity; //Yerçekimi vektörü
    private float gravity = -9.81f; //Yerçekimi büyüklüðü

    public Transform groundChecker; //Kontrol eden objemizin transformu
    public float groundCheckerRadius; //Oluþturduðumuz hayali kürenin çapý
    public LayerMask obstacleLayer;
    public bool isGrounded;

    public float jumpHeight = 0.1f; // Max Yükseklik deðeri
    public float gravityControl = 100f; //Yerçekimini böldüðümüz sayýyý deðiþken yaptýk Unity üzerinden deðiþtirmek daha kolay olsun diye
    public float jumpSpeed = 100f;
    
    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        //Cursor
        Cursor.visible = false; //Ýmlecin görünümünü kaldýrýyor.
        Cursor.lockState = CursorLockMode.Locked;  //Ýmleci ne akdar hareket ettirirsek ettirelim hep ortaya sabitliyor.
    }
    private void Update()
    {
        //Karakter yerde mi?
        isGrounded = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, obstacleLayer);

        //Movement                                         //x Ekseni                                   //z Ekseni
        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        //Hareketimizin sabit olmasý için ayrý olarak time deltatime ile çarpma yapabiliriz.
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;
        controller.Move(moveVelocity);


        //Camera Controller
        transform.Rotate(0, Input.GetAxis("Mouse X")* Time.deltaTime* mouseSens, 0);
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSens;
        
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Mathf.Clamp ile sýnýr belirliyoruz.
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation,0,0);

        


        //Jump and Gravity Check
        if (!isGrounded)
        {
            speed = Mathf.Lerp(speed, jumpSpeed, 1f*Time.deltaTime); //Mathf.Lerp fonksiyonu verilen iki deðer arasýnda belirlediðimiz süre içerisinde artma veya azalmayý gerçekleþtirir.
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
