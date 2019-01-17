using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Journal : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text logText;
    [SerializeField] GameObject textboxObj;
    //UI_TextController ui;
    public static Journal Instance { get; set; }
    public float textCooldown = 3;
    float countdown;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
            Instance = this;

       /* ui = textboxObj.GetComponent<UI_TextController>();
        if (ui == null)
        {
            Debug.Log("Ei löytynyt");
        }
        else
            ToggleImageBox(false);*/

        countdown = textCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            logText.text = "";
        }
    }

    public void Log(string text)
    {
        logText.text = text;
        countdown = textCooldown;
    }

    public void ToggleImagebox(bool toggle)
    {
        // Luoda UI-textcontroller scripti mikä säätelee UI tekstiä, miten ilmestyy ja katoaa jne.
        //Sen voi toteuttaa muullakin tavalla.
        if (toggle)
        {
            //ui.ToggleOn(true);
        }
        else
        {
            //ui.ToggleOn(false);
        }
    }
}
