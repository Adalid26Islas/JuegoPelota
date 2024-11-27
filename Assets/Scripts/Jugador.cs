using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Jugador : MonoBehaviour
{
    private GameManager gameManager;      
    public Text monedas;
    public Text vidas;
    public Text textMensaje;
    public Rigidbody cuerpo;
    public float velocidad = 5;
    public float salto = 10;
    private Vector3 posicionInicial; 
    public AudioSource sonidoMoneda;
    public AudioSource sonidoFondo;
    public AudioSource sonidoPerder;
    public AudioSource sonidoSaltar;
    public float movimientoVertical=0;
    public float movimientoHorizontal=0;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); 
        monedas.text = "Monedas: " + gameManager.monedas;
        vidas.text = "Vidas: " + gameManager.vidas;
        cuerpo = GetComponent<Rigidbody>();
        posicionInicial = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (gameManager.vidas > 0){
            MoverJugador();
            if (transform.position.y < -1){
                quitarVida();
            }
        }
        else{
            // mensaje de game over
            // gameManager.isJuego = false;
            sonidoFondo.Stop();
            textMensaje.text = "Game Over";
        }
    }

    void MoverJugador()
    {
        float movimientoH = Input.GetAxis("Horizontal") + movimientoHorizontal;
        float movimientoV = Input.GetAxis("Vertical") + movimientoVertical;
        Vector3 movimiento = new Vector3(movimientoH * velocidad, 0.0f, movimientoV * velocidad);
        cuerpo.AddForce(movimiento);
        if (Input.GetButton("Jump") && isSuelo())
        {
            sonidoSaltar.Play();
            cuerpo.velocity += Vector3.up * salto;
        }
    }

    private bool isSuelo()
    {
        
        Collider[] colisiones = Physics.OverlapSphere(transform.position, 0.5f);
        foreach (Collider colision in colisiones)
        {
            if (colision.tag == "Suelo")
            {
                return true;
            }
        }
        return false;
    }

    void quitarVida()
    {
        sonidoPerder.Play();
        gameManager.vidas--;
        vidas.text = "Vidas: " + gameManager.vidas;
        transform.position = posicionInicial; 
        cuerpo.velocity = Vector3.zero;  
    }

    void OnTriggerEnter(Collider moneda)  
    {
        if (moneda.gameObject.CompareTag("Moneda")){
            sonidoMoneda.Play();
            moneda.gameObject.SetActive(false);
            gameManager.monedas--;
            monedas.text = "Monedas: " + gameManager.monedas;
        }
    }

    public void moverVA(){
        movimientoVertical=1;
    }
    public void moverVR(){
        movimientoVertical=-1;
    }
    public void detener(){
        movimientoHorizontal=0;
        movimientoVertical=0;
        cuerpo.velocity = Vector3.zero;
    }
    public void moverHD(){
        movimientoHorizontal=1;
    }
    public void moverHI(){
        movimientoHorizontal=-1;
    }
    public void saltar(){
        if(isSuelo()){
            cuerpo.velocity += Vector3.up * salto;
        }
    }
}
