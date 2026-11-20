using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playercontrollerscript : MonoBehaviour
{
    // ZATRZYMYWANIE PRZY UDERZENIU ŒCIANY
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
    public float jumpbuffer;
    public bool grounded;
    public bool walljumping;
    public int consecutivewalljumps;
    public int walljumpvalue;
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
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0, 0), Vector2.down, 0.66f, groundlayer);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0, 0), Vector2.down, 0.66f, groundlayer);
        if (hit.collider != null && jumping == false)
        {
            grounded = true;
            jumpcount = jumpcountbase;
            if (hit.collider.gameObject.GetComponent<BoxCollider2D>() != null && hit.collider.gameObject.GetComponent<BoxCollider2D>().sharedMaterial != null)
            {
                friction = hit.collider.gameObject.GetComponent<BoxCollider2D>().sharedMaterial.friction;
            }
        }
        else if (hit1.collider != null && jumping == false)
        {
            grounded = true;
            jumpcount = jumpcountbase;
            if (hit1.collider.gameObject.GetComponent<BoxCollider2D>() != null && hit1.collider.gameObject.GetComponent<BoxCollider2D>().sharedMaterial != null)
            {
                friction = hit1.collider.gameObject.GetComponent<BoxCollider2D>().sharedMaterial.friction;
            }
        }
        else if (hit2.collider != null && jumping == false)
        {
            grounded = true;
            jumpcount = jumpcountbase;
            if (hit2.collider.gameObject.GetComponent<BoxCollider2D>() != null && hit2.collider.gameObject.GetComponent<BoxCollider2D>().sharedMaterial != null)
            {
                friction = hit2.collider.gameObject.GetComponent<BoxCollider2D>().sharedMaterial.friction;
            }
        }
        else
        {
            if (grounded == true)
            {
                StartCoroutine(Jumpbuffer());
                grounded = false;
            }
        }
        /*RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, 0.55f, groundlayer);
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, 0.55f, groundlayer);
        if(((hitleft.collider != null && moveinput == -1) || (hitright.collider != null && moveinput == 1)) && hit.collider == null)
        {
            walljumping = true;
            jumpcount = 1;
            if (jumpinput.action.WasPressedThisFrame())
            {
                consecutivewalljumps += 1;
            }
        }
        else
        {
            consecutivewalljumps = 1;
            walljumping = false;
        }*/
        if(walljumpvalue == 0 || walljumpvalue!=moveinput)
        {
            walljumping = false;
        }
        if (jumpinput.action.IsPressed() && jumptemp != 0 && jumptemp < jumpforce && rb.velocity.y==0)
        {
            jumptemp = 0;
        }
        if(moveinput == walljumpvalue)
        {
            moveinput = 0;
            if (walljumping)
            {
                outsideforcehoriz = 0;
            }
        }
    }
    private void FixedUpdate()
    {
        if (moveinput == 0 && previousInput != moveinput)
        {
            outsideforcehoriz = previousInput * movespeed * Time.deltaTime * 40;
        }
        if (walljumping)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2((moveinput * movespeed * Time.deltaTime) + (outsideforcehoriz * Time.deltaTime), rb.velocity.y);
        }
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
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
                jumping = false;
            }
        }
    }
    public IEnumerator Jumpbuffer()
    {
        yield return new WaitForSeconds(jumpbuffer);
        if(jumpcount == jumpcountbase)
        {
            jumpcount -= 1;
        }
    }
}
