using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{

    public GameObject creditsPanel;


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        creditsPanel.gameObject.SetActive(!creditsPanel.gameObject.activeSelf);

 
    }
}
