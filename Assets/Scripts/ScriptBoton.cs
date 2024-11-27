using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBoton : MonoBehaviour
{
    public ScriptOculto scriptOculto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            scriptOculto.oculta.SetActive(true);
        }
    }
}
