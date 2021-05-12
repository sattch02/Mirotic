using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;

    // 自キャラの移動方向
    public float xPos;
    public float zPos;

    public float moveSpeed = 5;
    public Collider weaponCollider;
    public PlayerUIManager playerUIManager;
    public int maxHp = 100;
    private int hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        playerUIManager.Init(this);

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        DisableColliderWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        // キー入力で移動
        xPos = Input.GetAxisRaw("Horizontal");
        zPos = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void FixedUpdate()
    {
        // 自キャラの向き
        Vector3 direction = transform.position + new Vector3(xPos, 0, zPos) * moveSpeed;
        transform.LookAt(direction);

        // 自キャラの速度と走行アニメーション
        rb.velocity = new Vector3(xPos, 0, zPos) * moveSpeed;
        animator.SetFloat("Speed", rb.velocity.magnitude);
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
            hp = 0;
        }
        playerUIManager.UpdateHp(hp);
    }

    private void OnTriggerEnter(Collider other)
    {
        // ダメージ与えるヤツの攻撃食らったら

        Damager damager = other.GetComponent<Damager>();
        if (damager != null)
        {
            Debug.Log("プレイヤーはダメージを受ける");
            animator.SetTrigger("Hurt");
            //Damage(damager.damage);
        }

    }
}
