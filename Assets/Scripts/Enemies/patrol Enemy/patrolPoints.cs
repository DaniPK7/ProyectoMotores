using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolPoints : MonoBehaviour
{
    public Color color=Color.green;
    float debugRadius = 1.0f;

   /* private void Update()
    {
        Gizmos.color = color;
        
        
    }*/
    public virtual void OnDrawGizmos() {
        Gizmos.color = color;


        Gizmos.DrawWireSphere(transform.position, debugRadius);
    }
}
