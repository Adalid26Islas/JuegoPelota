using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class TiempoScript : MonoBehaviour
{
    private GameManager gameManeger;
    public Text tiempo;
    // Start is called before the first frame update
    void Start()
    {
        tiempo.text = "Tiempo 00:00";
        gameManeger = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManeger.isJuego)
        {
            tiempo.text = "Tiempo: " + formatearTiempo();
        }
    }

    public string formatearTiempo()
    {
        if (gameManeger.isJuego)
        {
            gameManeger.tiempo += Time.deltaTime;
        }
        string minutos = Mathf.Floor(gameManeger.tiempo / 60).ToString("00");
        string segundos = Mathf.Floor(gameManeger.tiempo % 60).ToString("00");
        return minutos + ":" + segundos;
    }
}
 