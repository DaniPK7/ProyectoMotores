using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolPoints : MonoBehaviour
{
    float debugRadius = 1.0f;

    public virtual void OnDrawGizmos() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, debugRadius);
    }
}
