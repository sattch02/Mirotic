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

    // Start is called before the first frame update
    void Start()
    {
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

    private void OnTriggerEnter(Collider other)
    {
        Damager damager = other.GetComponent<Damager>();
        if (damager != null)
        {
            Debug.Log("敵はダメージを受ける");
            animator.SetTrigger("Hurt");
        }
    }
}
