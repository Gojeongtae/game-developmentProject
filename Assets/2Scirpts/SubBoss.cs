using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SubBoss : Enemy
{
    public enum Type
    {
        Range,
        Melee
    };

    /// <summary> ���Ÿ�/�ٰŸ� ���� </summary>
    public Type type;
    /// <summary> �÷��̾� </summary>
    public Player player;
    /// <summary> �̻��� ���ø� Prefab, Ŭ���Ͽ� ���� </summary>
    public BossMissile missileTemplate;
    /// <summary> �̻��� �߻� ��ġ </summary>
    public Transform[] missilePorts;
    /// <summary> ���� ������ </summary>
    public int contactDamage = 10;

    public GameObject Wall;


    private enum Status
    {
        IDLE,
        Attack,
        Die

    }

    private NavMeshAgent navMeshAgent;
    private Status status = Status.IDLE;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        base.Update();

        if(isdead == false)
            navMeshAgent.SetDestination(target.position);
        
       
        switch (status)
        {
            case Status.IDLE:
                float distance = Vector3.Distance(transform.position, target.position);
                if (distance <= navMeshAgent.stoppingDistance && isdead == false)
                {
                    StartCoroutine(Attack());
                    anim.SetTrigger("doAttack");
                }
                break;

        }

        if ((float)curHealth / maxHealth <= 0f && isdead == false)
        {
            anim.SetTrigger("doDie");
            isdead = true;
            Destroy(gameObject, 3f);
            Wall.SetActive(false);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            player.health -= contactDamage;

        }
    }

    IEnumerator Attack()
    {
        status = Status.Attack;

        yield return new WaitForSeconds(.5f);

        // �̻��� �߻�
        foreach (Transform missilePort in missilePorts)
        {
            BossMissile missile = Instantiate<BossMissile>(missileTemplate, missilePort.position, missilePort.rotation);
            missile.transform.localScale = new Vector3(.1f, .1f, .1f); 
            missile.target = target;
            missile.moveSpeed = 50f;
            missile.turnSpeed = 180f;
        }

        yield return new WaitForSeconds(2f);

        status = Status.IDLE;
    }
}
