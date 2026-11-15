using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallchecker : MonoBehaviour
{
    public Playercontrollerscript playerscript;
    public float requiredinput;
    public int returnedvalue;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(playerscript.moveinput == requiredinput)
        {
            playerscript.walljumping = true;
            playerscript.walljumpvalue = returnedvalue;
        }
        else
        {
            if(playerscript.walljumpvalue == returnedvalue)
            {
                playerscript.walljumpvalue = 0;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (playerscript.walljumpvalue == returnedvalue)
        {
            playerscript.walljumpvalue = 0;
        }
    }
}
