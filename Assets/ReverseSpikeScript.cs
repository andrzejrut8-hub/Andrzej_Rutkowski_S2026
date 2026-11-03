using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseSpikeScript : MonoBehaviour
{
    public float timetoturn;
    public float turnduration;
    public bool timergoing=false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(TurnTimer(timetoturn));
    }
    public IEnumerator TurnTimer(float timer)
    {
        timergoing = true;
        yield return new WaitForSeconds(timer);
        float duration = 1;
        while(duration > -1)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, duration, gameObject.transform.localScale.x);
            duration -= Time.deltaTime*0.5f;
        }
        yield return new WaitForSeconds(turnduration);
        while (duration < 1)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, duration, gameObject.transform.localScale.x);
            duration += Time.deltaTime*0.5f;
        }
        timergoing = false;
    }
}
