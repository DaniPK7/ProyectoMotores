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
    Movement playerSC;
    bool playerAlive;

    //Atack
    private float distanceWithPlayer;
    public GameObject player;
    float chaseRange = 10f;

    float attackRange = 3.5f;
    bool attackPlayer;

    bool inRange = false;
    bool chaseHim = false;
    bool playerSS = false;
    //
    bool nocked = false;
    //
    //anim
    Animator enemyAnim;


    // Start is called before the first frame update
    //
    batteryManagement batManSC;
    //
    manageAudio audioManage;
    int wendigoId;
    void Start()
    {
        wendigoId = Convert.ToInt32(this.name.Substring(this.name.Length - 1));
        healthSC = FindObjectOfType<healthbar>();
        playerSC = FindObjectOfType<Movement>();
        //
        batManSC = FindObjectOfType<batteryManagement>();
        audioManage = FindObjectOfType<manageAudio>();

        navMesh = GetComponent<NavMeshAgent>();

        enemyAnim = GetComponent<Animator>();

        attackPlayer = false;

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
        playerAlive = playerSC.playerAlive;

        enemyAnim.SetBool("Wait", waiting);
        enemyAnim.SetBool("InRange", inRange);
        enemyAnim.SetBool("Chase", chaseHim);
        enemyAnim.SetBool("Attack", attackPlayer);
        //
        enemyAnim.SetBool("Nocked", nocked);
        //

    }
    //
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("light") && batManSC.lanternOn)
        {
            nocked = true;
            chaseHim = false;
            navMesh.Stop();
        }
    }
    //
    public void SetChase() 
    {
        //
        nocked = false;
        //
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
            

            if (distanceWithPlayer < chaseRange && playerAlive)                   //Chase
            {
                

                if (distanceWithPlayer <= attackRange)      //ataca
                {
                    navMesh.Stop();
                    audioManage.SetClip(wendigoId, 2);

                    attackPlayer = true;
                    print("TE REVIENTO");


                }
                else
                {

                    navMesh.Resume();
                    attackPlayer = false;
                    

                    inRange = true;
                    if (!chaseHim)
                    {
                        navMesh.Stop();
                        audioManage.SetClip(wendigoId, 1);

                    }

                    else
                    {
                        playerSS = true;
                        navMesh.SetDestination(player.transform.position);
                    }

                    Quaternion _lookRotation = Quaternion.LookRotation((player.transform.position - transform.position).normalized);

                    transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * 10f);
                    //transform.LookAt(player.transform);

                    //
                }
            }

            else                                                    //Patrol
            {
                audioManage.SetClip(wendigoId, 0);

                attackPlayer = false;


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

    public void StopAndAttack() 
    {
        print("aja1");

        navMesh.Stop();
    }
    public void PostAttack() 
    {
        print("aja2 ");
        navMesh.Resume();

    }

}
