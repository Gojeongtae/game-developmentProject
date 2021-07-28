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

    private enum Status
    {
        IDLE,
        Attack
    }

    private NavMeshAgent navMeshAgent;
    private Status status = Status.IDLE;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        base.Update();

        navMeshAgent.SetDestination(target.position);

        switch (status)
        {
            case Status.IDLE:
                float distance = Vector3.Distance(transform.position, target.position);
                if (distance <= navMeshAgent.stoppingDistance)
                    StartCoroutine(Attack());
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player.health -= contactDamage;
            if (type == Type.Range) // ���Ÿ� ���������
                Destroy(gameObject);
        }
    }

    IEnumerator Attack()
    {
        status = Status.Attack;

        yield return new WaitForSeconds(2f);

        // �̻��� �߻�
        foreach (Transform missilePort in missilePorts)
        {
            BossMissile missile = Instantiate<BossMissile>(missileTemplate, missilePort.position, missilePort.rotation);
            missile.transform.localScale = new Vector3(1f, 1f, 1f); 
            missile.target = target;
            missile.moveSpeed = 50f;
            missile.turnSpeed = 180f;
        }

        yield return new WaitForSeconds(1f);

        status = Status.IDLE;
    }
}
