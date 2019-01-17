using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatUpdate : MonoBehaviour
{
    public GameObject Player;
    private CharacterStats stats;

    public Slider healthSlider;


    // Start is called before the first frame update
    void Start()
    {

        stats = Player.GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = stats.currentHealth;


        //Journal.Instance.Log("took damage");

        if (Input.GetKeyDown("return"))
        {
            stats.TakeDamage(20);
        }
    }
}
