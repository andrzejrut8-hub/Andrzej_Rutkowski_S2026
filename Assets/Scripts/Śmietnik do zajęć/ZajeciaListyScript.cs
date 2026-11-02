using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZajeciaListyScript : MonoBehaviour
{
    public List<int> dane = new List<int>{1, 3, 3, 1, 2, 2, 3, 1, 3, 2};
    public List<int> jedynki = new List<int>();
    public List<int> dwojki = new List<int>();
    public List<int> trojki = new List<int>();

    void Start()
    {
        for(int i=0; i<10; i++)
        {
            if (dane[0] == 1)
            {
                jedynki.Add(dane[0]);
                dane.Remove(dane[0]);
            }else if (dane[0] == 2)
            {
                dwojki.Add(dane[0]);
                dane.Remove(dane[0]);
            }
            else if (dane[0] == 3)
            {
                trojki.Add(dane[0]);
                dane.Remove(dane[0]);
            }
        }
    }
}
