using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    private PlayerHealth playerHealth;
    public NavMeshAgent navMeshAgent;

    public int damageToPlayerHealth = 2;

    public float attackRange = 2f;
    public float intervalBetweenAttacks = 1f;
    public float timeBeforeNextAttack = 0f;

    void Start()
    {
        // stores the playerHealth component which is accessed from the player game object
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        // used to move towards players position, accessed by player.position
        navMeshAgent.SetDestination(player.position);

        // distance beteen enemy and player
        float distance = Vector3.Distance(transform.position, player.position);

        // for enemy to attack player:
        // 1. distance -> is player within the attack range firstly
        // 2. delay before each attack so player has enough time to get away so all their health isn't taken away all at once
        if (distance <= attackRange && Time.time >= timeBeforeNextAttack)
        {
            // update players health to reflect damage done to player
            playerHealth.UpdatePlayerHealth(damageToPlayerHealth);

            // update time to wait before next attack can take place depending on the intervalBetweenAttacks
            timeBeforeNextAttack = Time.time + 1f / intervalBetweenAttacks;
        }
    }


    public void KillEnemy()
    {

        Destroy(gameObject);
    }

}




