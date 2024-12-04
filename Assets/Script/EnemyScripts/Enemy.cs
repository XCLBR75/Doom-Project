using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyManager enemyManager;
    private float enemyHealth = 3f;
    private AngleToPlayer angleToPlayer;
    private Animator spriteAnim;
    private float atk = 10f;
    public bool isBoss;

    public GameObject gunHitEffect;

    // Start is called before the first frame update
    private void Start()
    {
        spriteAnim = GetComponentInChildren<Animator>();
        angleToPlayer = GetComponent<AngleToPlayer>();

        enemyManager = FindObjectOfType<EnemyManager>();

        if (isBoss)
        {
            atk *= GameManager.Instance.enemyAttackMultiplier + 1.5f;
            enemyHealth += GameManager.Instance.enemyHealthMultiplier + 13f;
        }
        else
        {
            atk *= GameManager.Instance.enemyAttackMultiplier;
            enemyHealth += GameManager.Instance.enemyHealthMultiplier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        spriteAnim.SetFloat("spriteRot", angleToPlayer.lastIndex);

        if (enemyHealth <= 0)
        {
            enemyManager.RemoveEnemy(this);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        Instantiate(gunHitEffect, transform.position, Quaternion.identity);
        enemyHealth -= damage;
    }

    public void DealDamage(float atk)
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.DamagePlayer((int)atk); // Cast `atk` to an integer as `DamagePlayer` expects an `int`.
        }
        else
        {
            Debug.LogWarning("PlayerHealth script not found.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.DealDamage(atk); // Call DealDamage when the enemy collides with the player.
        }
    }

    public void ChangeDifficulty(GameManager.Difficulty multiplier)
    {
        GameManager.Instance.SetDifficulty(multiplier);
    }

}
