using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAscensor : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad = 3;
    private Vector3 direccion = Vector3.up;

    private int limiteSup = 4;
    private int limiteInf = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= limiteSup)
        {
            direccion = Vector3.down;
        } if (transform.position.y <= limiteInf)
        {
            direccion = Vector3.up;
        }

        transform.Translate(direccion * Time.deltaTime * velocidad);
    }
}
