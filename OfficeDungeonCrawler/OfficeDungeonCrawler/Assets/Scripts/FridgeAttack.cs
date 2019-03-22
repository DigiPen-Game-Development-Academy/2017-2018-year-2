using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeAttack : MonoBehaviour
{

    public GameObject hitbox;

    public float attackDistance = 1.0f;

    [HideInInspector]
    public float fastAttackChargeTime = 0.5f;
    [HideInInspector]
    public float fastAttackCooldown = 0.5f;
    [HideInInspector]
    public float fastAttackDamage = 0.5f;
    [HideInInspector]
    float timeTillFastCharge = 0.0f;
    [HideInInspector]
    float timeTillFastAttack = 0.0f;

    [HideInInspector]
    public float longAttackChargeTime = 1.0f;
    [HideInInspector]
    public float longAttackCooldown = 1.5f;
    [HideInInspector]
    public float longAttackDamage = 2.0f;
    [HideInInspector]
    float timeTillLongCharge = 0.0f;
    [HideInInspector]
    float timeTillLongAttack = 0.0f;

    public bool cantGetUp = false;
    public  const float timeToDeleltion = 1.2f;
    public float attackCooldown = 0.1f;
    public float attackChargeTime = 1.0f;
    public float attackDamage = 20;
    public float splashdamage = 2.5f;
    float timeTillAttack = 0.0f;

    Vector2 attackPosition = Vector2.zero;

    EnemyMovement enemyMovement;
    GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyMovement = GetComponent<EnemyMovement>();
        timeTillFastAttack = fastAttackCooldown;
        timeTillLongAttack = longAttackCooldown;
        timeTillAttack = attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(cantGetUp == true) Destroy(gameObject);
    
        if (player == null) return;
        float distance = Vector2.Distance(transform.position, player.transform.position);

        timeTillAttack -= Time.deltaTime;

        if (distance <= attackDistance)
        {
            if (timeTillAttack <= 0.0f)
            {
                enemyMovement.canMove = false;
            }
            else
            {
                attackPosition = player.transform.position;
                enemyMovement.canMove = true;
            }
            if (timeTillAttack <= -attackChargeTime)
            {
                GameObject newHitbox = Instantiate(hitbox, Vector2.Lerp(attackPosition, player.transform.position, 0.5f), Quaternion.Euler(Vector2.zero));
                Hitbox hitboxComponent = newHitbox.GetComponent<Hitbox>();
                hitboxComponent.isEnemy = true;
                hitboxComponent.damage = attackDamage;
                timeTillAttack = attackCooldown;
                cantGetUp = true;
                enemyMovement.canMove = false;
                Debug.Log("attacking");
            }
        }
    }
}
