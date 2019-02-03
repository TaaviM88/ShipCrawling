using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable
{
    Animator anime;
    Animator animeDoor;
    public bool isLocked = false, doorStaysOpen = false, useSeparateDoor = false;
    bool doorIsOpen = false;
    public float closingTime = 2f;
    float countdown;
    public string doorDescription = "Hellou, this is a door. Good bye...FUCK FACE";
    public string hintIfDoorLocked = "Hey mate! Guess what?!?! This door is locked. Try find a key you idiot.";
    public Equipment requiedItemObject;
    [Header("Add seperate door object with animation if you need one.")]
    public GameObject door;
 
    Collider col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        anime = GetComponent<Animator>();
        countdown = closingTime;
        if(door == null)
        {
            return;
        }
        else if(door != null && useSeparateDoor)
        {
            animeDoor = door.GetComponent<Animator>();
        }
    }

    public override void Interact()
    {
        base.Interact();

        if(!doorIsOpen && !isLocked)
        {
            InteractiveDoor(true);
        }
        else if(isLocked)
        {
            Equipment a = EquipmentManager.instance.ReturnCurrentEquipment();
            if(requiedItemObject.name == a.name)
            {
                isLocked = false;
                Journal.Instance.Log("Door is now open");
            }
            else
            {
                InformJournalDoorIsLocked();
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        if(doorIsOpen && doorStaysOpen == false)
        {
            countdown -= Time.deltaTime;
            if(countdown <= 0)
            {
                InteractiveDoor(false);
            }
        }
    }

    public void InteractiveDoor(bool open)
    {

        if(!isLocked)
        {
            doorIsOpen = open;
            //anime.SetBool("OpenDoor", open);
            if (open)
            {
                anime.SetTrigger("Open");
                if(useSeparateDoor)
                {
                    animeDoor.SetTrigger("Open");
                }
            }
            else if(!open && doorStaysOpen == false)
            {
                anime.SetTrigger("Close");
                if (useSeparateDoor)
                {
                    animeDoor.SetTrigger("Close");
                }
            }

            if (open)
            {
                // Laitetaan ovien colliderit triggeriksi että päästään läpi
               // Collider col = door.GetComponent<Collider>();
                if (door != null)
                {
                    col.isTrigger = true;
                    if(useSeparateDoor)
                    {
                        Collider doorCol = door.GetComponent<Collider>();
                        doorCol.isTrigger = true;
                    }   
                    
                }
                else
                    Debug.Log($"Nyt meni jotain vikaa {gameObject.name}");
                countdown = closingTime;
            }
            else
            {
                //Collider col = door.GetComponent<Collider>();
                if(door != null)
                {
                    col.isTrigger = false;
                    if (useSeparateDoor)
                    {
                        Collider doorCol = door.GetComponent<Collider>();
                        doorCol.isTrigger = false;
                    }
                }
            }
        }
        else
        {
            
            InformJournalDoorIsLocked();
        }
                
    }

    public void OpenDoor()
    {
        InteractiveDoor(true);
    }

    public void CloseDoor()
    {
        InteractiveDoor(false);
    }

    public void InformJournalDoorIsLocked()
    {
        Journal.Instance.Log(hintIfDoorLocked);
        
    }
}
