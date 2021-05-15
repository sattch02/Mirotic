using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public Transform target;
    public Collider weaponCollider;

    NavMeshAgent agent;
    Animator animator;
    public int maxHp = 100;
    private int hp;
    private bool isDie = false;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
        DisableColliderWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
        animator.SetFloat("Distance", agent.remainingDistance);
        transform.LookAt(target);
    }

    // 武器の当たり判定無効化
    public void DisableColliderWeapon()
    {
        weaponCollider.enabled = false;
    }

    // 武器の当たり判定有効化
    public void EnableColliderWeapon()
    {
        weaponCollider.enabled = true;
    }

    private void Damage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            isDie = true;
            hp = 0;
            animator.SetTrigger("Die");
            Destroy(gameObject, 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDie)
        {
            return;
        }

        Damager damager = other.GetComponent<Damager>();
        if (damager != null)
        {
            Debug.Log("敵はダメージを受ける");
            animator.SetTrigger("Hurt");
            Damage(damager.damage);
        }
    }
}
