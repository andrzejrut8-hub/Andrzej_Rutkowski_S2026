using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playercontrollerscript : MonoBehaviour
{
    public InputActionReference moveinputaccess;
    public InputActionReference jumpinput;
    public float moveinput;
    public Rigidbody2D rb;
    public float movespeed;
    public float jumpforce;
    public int jumpcountbase;
    public int jumpcount;
    public bool jumping = false;
    public float jumptemp = 0;
    public float outsideforcehoriz;
    public float friction;
    public bool haskey = false;
    public LayerMask groundlayer;
    private float previousInput;
    void Start()
    {

    }
    void Update()
    {
        moveinput = moveinputaccess.action.ReadValue<float>();
        if (jumpinput.action.WasPressedThisFrame() && jumpcount > 0)
        {
            jumpcount--;
            jumptemp = jumpforce;
            jumping = true;
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.66f, groundlayer);
        if (hit.collider != null && jumping == false)
        {
            jumpcount = jumpcountbase;
            if (hit.collider.gameObject.GetComponent<BoxCollider2D>() != null)
            {
                friction = hit.collider.gameObject.GetComponent<BoxCollider2D>().sharedMaterial.friction;
            }
        }
    }
    private void FixedUpdate()
    {
        if (moveinput == 0 && previousInput != moveinput)
        {
            outsideforcehoriz = previousInput * movespeed * Time.deltaTime * 40;
        }
        rb.velocity = new Vector2((moveinput * movespeed * Time.deltaTime) + (outsideforcehoriz * Time.deltaTime), rb.velocity.y);
        previousInput = moveinput;
        if (Mathf.Abs(outsideforcehoriz) > 0)
        {
            if (Mathf.Abs(outsideforcehoriz) < 0.1f)
            {
                outsideforcehoriz = 0;
            }
            else
            {
                outsideforcehoriz *= (1 - friction);
            }
        }
        if (jumping)
        {
            if (jumpinput.action.IsPressed() && jumptemp != 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumptemp);
                if (jumptemp > 0)
                {
                    jumptemp -= (jumpforce / 25);
                }
                else
                {
                    jumptemp = 0;
                }
            }
            else
            {
                jumping = false;
            }
        }
    }
}
