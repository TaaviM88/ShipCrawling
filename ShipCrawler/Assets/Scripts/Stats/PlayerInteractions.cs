using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public Interactable focus;
    Transform target;
    CharacterCombat combat;

    // Start is called before the first frame update
    void Start()
    {
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButton("Fire1"))
        {

            Ray ray = new Ray(transform.position + (new Vector3(0, 1, 0)), transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 1.5f))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    SetFocus(interactable);
                    interactable.Interact();
                    Debug.DrawLine(ray.origin, hit.point);
                    target = interactable.transform;

                    FaceTarget();

                    CharacterStats targetstat = interactable.GetComponent<CharacterStats>();
                    if(targetstat != null)
                    {
                        interactable.Interact();
                        combat.Attack(targetstat);
                        Debug.DrawLine(ray.origin, hit.point);
                    }

                }
            }
        }
    }
    
    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.Defocused();
            }
            focus = newFocus;
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.Defocused();

        focus = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position + transform.position.normalized);
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
