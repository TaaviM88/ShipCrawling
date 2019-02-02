using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : Interactable
{
    public int NextSceneIndex = 0;
    public static ChangeScene Instance { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        gameObject.SetActive(false);
    }


    public override void Interact()
    {
        base.Interact();
        ChooseSceneToLoad(NextSceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ChooseSceneToLoad (int i)
    {
        SceneManager.LoadScene(i);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(NextSceneIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }


}
