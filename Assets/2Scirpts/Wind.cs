using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Wind : MonoBehaviour
{
    public Transform bulletPos;
    public GameObject bullet;

    void OnTriggerStay()  // WindZone Trigger
    {
        Rigidbody bulletRigid = GetComponent<Rigidbody>();
        bulletRigid.velocity = bulletPos.forward * -500;
        // Ʈ���� �ȿ� �ִµ��� ��� ����
    }
}
