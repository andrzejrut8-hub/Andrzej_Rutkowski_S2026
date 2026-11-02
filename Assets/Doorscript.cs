using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Doorscript : MonoBehaviour
{
    public InputActionReference InteractInput;
    public bool open = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && open == false && collision.gameObject.GetComponent<Playercontrollerscript>().haskey == true)
        {
            if (InteractInput.action.WasPressedThisFrame())
            {

            }
        }
    }
}
