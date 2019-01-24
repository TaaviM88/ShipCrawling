using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRandomPatrol : MonoBehaviour
{
    public int currentRandomPoint;
    public Transform Player;
    public Transform[] randomPoints;
    private float playerDist, randomPointDist;
    private bool chasing, chaseTime, attacking;
    private float chaseStopwatch, attackingStopwatch;

    public float perceptionDistance = 30, chaseDistance = 20, walkVelocity = 2, chaseVelocity = 6, attackDistance = 1;

    public bool seeingPlayer;

    private NavMeshAgent agent;

    CharacterCombat combat;

    // Start is called before the first frame update
    void Start()
    {
        currentRandomPoint = Random.Range(0, randomPoints.Length);
        agent = transform.GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update() {
        playerDist = Vector3.Distance(Player.transform.position, transform.position);
        randomPointDist = Vector3.Distance(randomPoints[currentRandomPoint].transform.position, transform.position);
        RaycastHit hit;

        Vector3 startRay = transform.position;
        Vector3 endRay = Player.transform.position;
        Vector3 direction = endRay - startRay;

        if (Physics.Raycast (transform.position, direction, out hit, 1000) && playerDist < perceptionDistance) {
            if (hit.collider.gameObject.CompareTag("Player")) {
                seeingPlayer = true;
            } else {
                seeingPlayer = false;
            }
        }

        //And walk while our player distance is greater than perception distance
        if (playerDist > perceptionDistance)
            walk();

        if (playerDist <= perceptionDistance && playerDist > chaseDistance) {
            if (seeingPlayer == true)
                look();
            else
                walk();
        }

        if (playerDist <= perceptionDistance && playerDist > attackDistance) {
            if (seeingPlayer == true)
            {
                chase();
                chasing = true;
            } else {
                walk();
            }
        }

        //Taavin hyökkäys sekoiluja
        if(seeingPlayer && playerDist < attackDistance)
        {
            CharacterStats targetPlayer = Player.GetComponent<CharacterStats>();
            combat.Attack(targetPlayer);
        }

        if (randomPointDist <= 8) {
            currentRandomPoint = Random.Range(0, randomPoints.Length);
            walk();

        if (chaseTime == true)
            chaseStopwatch += Time.deltaTime;

        if (chaseStopwatch >= 10 && seeingPlayer == false) {
                chaseTime = false;
                chaseStopwatch = 0;
                chasing = false;
            }
        }
    }

    void walk () {
        if (chasing == false)
        {
            agent.acceleration = 4;
            agent.speed = walkVelocity;
            agent.destination = randomPoints[currentRandomPoint].position;
        } else if (chasing == true) {
            chaseTime = true;
        }
    }

    void look () {
        agent.speed = 0;
        transform.LookAt(Player);
    }

    void chase () {
        agent.acceleration = 5;
        agent.speed = chaseVelocity;
        agent.destination = Player.position;
    }
}

