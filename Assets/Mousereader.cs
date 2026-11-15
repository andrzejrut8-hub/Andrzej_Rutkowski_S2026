using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousereader : MonoBehaviour
{
    public Camera jakkolwiekchcesznazwacswojakamere;
    public Vector2 naszapozycjamyszkiwswiecie;
    void Start()
    {
        
    }
    void Update()
    {
        naszapozycjamyszkiwswiecie = jakkolwiekchcesznazwacswojakamere.ScreenToWorldPoint(Input.mousePosition);
    }
}
