using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{

    private Animator animacion;
    private float Velocidad = 3f;
    private float inputHorizontal;
    private Quaternion rotacionPersonaje; 
    private CharacterController controladorPersonaje;
    private Vector3 movimiento;
    private float gravedad = 9.8f;
    private float fuerzaSalto = 6f;
    private bool enElAire = false; 


    // Start is called before the first frame update
    void Start()
    {
        animacion = this.GetComponent<Animator>();
        controladorPersonaje = this.GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MoverPersonaje(); 
    }

    void MoverPersonaje()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal"); 
        movimiento.z = inputHorizontal * Velocidad;
        if(controladorPersonaje.isGrounded)
        {
            enElAire = false; 
            animacion.SetBool("TocarSuelo", true); 
            animacion.SetBool("Saltando", false); 
            animacion.SetBool("Caminando", false);
        }
        else
        {
            movimiento.y -= gravedad * Time.deltaTime; 
        }

        if (inputHorizontal != 0)
        {
            rotacionPersonaje = Quaternion.LookRotation(new Vector3(0,0,inputHorizontal));
            this.transform.rotation = rotacionPersonaje;
            animacion.SetBool("Caminando", true); 
        }
        if (Input.GetButtonDown("Jump") && !enElAire)
        {
            enElAire = true; 
            animacion.SetBool("Saltando", true);
            movimiento.y = fuerzaSalto; 
        }
        controladorPersonaje.Move(movimiento * Time.deltaTime);
    }
}
