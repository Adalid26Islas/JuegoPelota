using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorScripts : MonoBehaviour
{
    private Rigidbody cuerpo;
    public float velocidad = 5;
    public float salto = 7;
    // Start is called before the first frame update
    void Start() {
        cuerpo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() {
        // CAPTURAR MOVIMIENTO
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        // GENERAR VECTOR DE MOVIMIENTO 
        Vector3 movimiento = new Vector3(movimientoH * velocidad, 0.0f, movimientoV * velocidad);
        // AGREGAR FUERZA PARA EMPLUJAR EL RIGIDBODY
        cuerpo.AddForce(movimiento);
        if (Input.GetButton("Jump") && isSuelo()) {
            cuerpo.velocity += Vector3.up * salto;
        }

    }
    private bool isSuelo() {
        Collider[] colisiones = Physics.OverlapSphere(transform.position, 0.5f);
        foreach(Collider colision in colisiones) {
            if (colision.tag == "suelo")
            {
                return true;
            }
        }
        return false;
    }
}
