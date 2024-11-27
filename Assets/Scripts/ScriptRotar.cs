using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRotar : MonoBehaviour
{
    public float velocidad = 30;
    private Vector3 direccion = Vector3.up;

    private int limiteSup = 270;
    private int limiteInf = 90;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.eulerAngles.y >= limiteSup)
        {
            direccion = Vector3.down;
        } if (transform.rotation.eulerAngles.y <= limiteInf)
        {
            direccion = Vector3.up;
        }
        transform.Rotate(direccion * Time.deltaTime * velocidad);
    }
}
