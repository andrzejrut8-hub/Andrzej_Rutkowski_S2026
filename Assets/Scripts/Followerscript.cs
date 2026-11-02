using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followerscript : MonoBehaviour
{
    public GameObject Target;
    public float distance;
    public GameObject RotateTarget;
    public Vector3 initialscale;
    public float smoothing = 1;
    void Start()
    {
        initialscale = transform.localScale;
    }
    void Update()
    {
        if (Target != null && Vector3.Distance(Target.transform.position, gameObject.transform.position) > distance)
        {
            Vector3 direction = (Target.transform.position - gameObject.transform.position).normalized;
            gameObject.transform.position += direction * (Vector3.Distance(Target.transform.position, gameObject.transform.position) - distance) * smoothing * Time.deltaTime;
        }
        if (RotateTarget != null)
        {
            if (gameObject.transform.position.x - RotateTarget.transform.position.x < 0)
            {
                gameObject.transform.localScale = new Vector3(initialscale.x, initialscale.y, initialscale.z);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(initialscale.x * -1, initialscale.y, initialscale.z);
            }
        }
    }
}
