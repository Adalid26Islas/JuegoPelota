using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptTiempo : MonoBehaviour
{
    private ScriptManager scriptManager;
    public Text tiempo;
    // Start is called before the first frame update
    void Start()
    {
        tiempo.text = "Tiempo: 00:00";
        scriptManager = FindObjectOfType<ScriptManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptManager.isJuego){
            tiempo.text = "Tiempo: " + formatearTiempo();
        }
    }
    public string formatearTiempo(){
        if (scriptManager.isJuego){
            scriptManager.tiempo += Time.deltaTime;
        }
        string minutos = Mathf.Floor(scriptManager.tiempo / 60).ToString("00");
        string segundos = Mathf.Floor(scriptManager.tiempo % 60).ToString("00");
        return minutos + ":" + segundos;
    }
}
