using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passthroughplatform : MonoBehaviour
{
    public bool passThrough;
    public Collider2D col;
    public GameObject Player;
    void Start()
    {
        col = gameObject.GetComponent<Collider2D>();
        Player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if(Player!=null && Player.transform.position.y - (0.5f*Player.transform.localScale.y) < transform.position.y + (0.5f * transform.localScale.y))
        {
            passThrough = true;
        }
        else
        {
            passThrough=false;
        }
        if (passThrough)
        {
            col.enabled = false;
        }
        else
        {
            col.enabled=true;
        }
    }
}
