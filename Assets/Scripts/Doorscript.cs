using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Doorscript : MonoBehaviour
{
    public InputActionReference InteractInput;
    public bool open = false;
    public Sprite Opensprite;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && open == false && collision.GetComponent<Playercontrollerscript>().haskey == true)
        {
            if (InteractInput.action.IsPressed())
            {
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Opensprite;
                Destroy(GameObject.FindWithTag("Key"));
                Destroy(GameObject.FindWithTag("Player"));
            }
        }
    }
}
