using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemyPatrol : MonoBehaviour
{
    [SerializeField]
    bool patrolWait;

    [SerializeField]
    float totalWaitTime = 3f;

    [SerializeField]
    float switchProb =0.2f;

    [SerializeField]
    List<patrolPoints> patrolPoints;

    NavMeshAgent navMesh;
    int currentIndex;
    bool traveling, waiting, patrolForward;
    float waitTimer;

    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();

        if (navMesh == null)
        {
            print("Error non attached navmesh to"+ gameObject);
        }

        else 
        {
            if (patrolPoints !=null && patrolPoints.Count >=2)
            {
                currentIndex = 0;
                SetDestination();
            }
            else
            {

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (traveling && navMesh.remainingDistance<=1.0f)
        {
            traveling = false;

            if (patrolWait) 
            {
                waiting = true;
                waitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }

        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer>= totalWaitTime)
            {
                waiting = false;
                ChangePatrolPoint();
                SetDestination();
            }

        }
        
    }

    void SetDestination() 
    {
        if (patrolPoints != null) 
        {
            Vector3 targetVector = patrolPoints[currentIndex].transform.position;
            navMesh.SetDestination(targetVector);
            traveling = true;
        }
    }

    void ChangePatrolPoint() 
    {
        if (UnityEngine.Random.Range(0f, 1f) <= switchProb) 
        {
            patrolForward = !patrolForward;
        }

        if (patrolForward) 
        {
            /*currentIndex++;
            if (currentIndex >= patrolPoints.Count) { currentIndex = 0; }*/
            currentIndex = (currentIndex + 1) % patrolPoints.Count;
        }
        else
        {
            if (--currentIndex < 0) 
            {
                currentIndex = patrolPoints.Count - 1;
            }
        }
    }
}
