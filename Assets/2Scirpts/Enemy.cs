using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;
    public Transform target;
    /// <summary> 체력바 </summary>
    public Transform healthBar;
    public HealthHUD healthHUD;
    /// <summary> 피격 시 넉백 </summary>
    public float knockBack = 0f;


    Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;
    NavMeshAgent nav;
    protected Animator anim;
    public GameObject body;
    public GameObject Par;

    public bool isdead = false;

    public void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        //mat = GetComponent<MeshRenderer>().material;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        //nav.SetDestination(target.position);

        // 체력바 업데이트
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBar == null)
            return;

        float health = curHealth;
        if (health < 0f)
            health = 0f;

        float ratio = (float)health / maxHealth;
        healthBar.localPosition = new Vector3(1.6f - ratio * 1.6f, 0f, 0f);
        healthBar.localScale = new Vector3(ratio * 10f, 1f, 1f);

        if (healthHUD != null)
            healthHUD.UpdateHealthBar(health, maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 무기 타입에 따라 데미지
        if(other.tag == "Melee" && isdead == false)
        {
            
            Weapon weapon = other.GetComponent<Weapon>();
            curHealth -= weapon.damage;
            StartCoroutine(OnDamage());
        }
         else if (other.tag == "Bullet")
        {
            Bullet bullet = other.GetComponent<Bullet>();
            curHealth -= bullet.damage;
            StartCoroutine(OnDamage());
        }
    }

    IEnumerator OnDamage()
    {
        //TODO: mesh를 넣었음에도 찾을 수 없다는 오류가 뜸
        //mat.color = Color.red;

        // 피격 애니메이션
        
        anim.SetTrigger("doDamaged");
        Instantiate(Par, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), transform.rotation);

        yield return new WaitForSeconds(0.1f);

        if(curHealth > 0)
        {
          // mat.color = Color.white;
        }

        if (knockBack > 0f)
        {
            transform.Translate(0, 0, -knockBack);
        }
        else
        {
          // mat.color = Color.gray; 
        }
    }

   
}
