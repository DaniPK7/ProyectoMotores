using System;
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
    float waitTimer=0f;

    //Health
    float enemyHP;
    bool enemyIsAlive;
    healthbar healthSC;

    //Atack
    private float distanceWithPlayer;
    public GameObject player;
    float chaseRange = 10f;
    bool inRange = false;
    bool chaseHim = false;
    bool playerSS = false;

    //anim
    Animator enemyAnim;

    // Start is called before the first frame update
    void Start()
    {

        healthSC = FindObjectOfType<healthbar>();

        navMesh = GetComponent<NavMeshAgent>();

        enemyAnim = GetComponent<Animator>();


        enemyHP = 100f;

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
        setState();

        patrolOrWait();

        enemyAnim.SetBool("Wait", waiting);
        enemyAnim.SetBool("InRange", inRange);
        enemyAnim.SetBool("Chase", chaseHim);




    }

    public void SetChase() 
    {
        chaseHim = true;
        navMesh.speed = 5;
        navMesh.Resume();

        waiting = true;
    }


    private void patrolOrWait()
    {
        if (enemyIsAlive)
        {
            distanceWithPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceWithPlayer < chaseRange)                   //Chase
            {
               
                print("TE REVIENTO");
                inRange = true;
                if (!chaseHim) {
                    navMesh.Stop();
                    

                }

                else {  
                    playerSS = true;                    
                    navMesh.SetDestination(player.transform.position);
                }

                Quaternion _lookRotation =  Quaternion.LookRotation((player.transform.position - transform.position).normalized);

                transform.rotation =   Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime *10f);
                //transform.LookAt(player.transform);

                //
            }

            else                                                    //Patrol
            {
                navMesh.Resume();
                
                navMesh.speed = 1.5f;
                inRange = false;
                chaseHim = false;

                if (playerSS) 
                {
                  
                    navMesh.Stop();
                    SetDestination();
                    playerSS = false;
                }
                /* if (!chaseHim && playerSS)
                 {
                     print("SS el negro");
                     traveling = false;
                     patrolWait = true;
                     playerSS = false;
                     navMesh.Stop();
                     //navMesh.SetDestination(transform.position);
                 }
                 else
                 {
                     navMesh.Resume();
                     SetDestination();
                 }*/
                //SetDestination();


                if (traveling && navMesh.remainingDistance <= 1.0f)
                {
                    traveling = false;
                    patrolWait = true;

                    if (patrolWait)
                    {
                        waiting = true;
                        
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
                    if (waitTimer >= totalWaitTime)
                    {
                        patrolWait = false;
                        waiting = false;
                        ChangePatrolPoint();
                        SetDestination();
                        waitTimer = 0f;
                    }

                }
            }

           
        }
    }

    void setState() 
    {
        if (enemyHP > 0)
        {
            enemyIsAlive = true;
        }
        else
        {
            enemyIsAlive = false;
        }
    }

    void SetDestination() 
    {
        navMesh.Resume();
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
