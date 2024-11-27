using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptOculto : MonoBehaviour
{
    public GameObject oculta;
    // Start is called before the first frame update
    void Start()
    {
        oculta.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
