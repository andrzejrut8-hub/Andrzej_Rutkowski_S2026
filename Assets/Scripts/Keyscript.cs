using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyscript : MonoBehaviour
{
    public Followerscript followerscript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            followerscript.enabled = true;
            this.enabled = false;
        }
    }
}
