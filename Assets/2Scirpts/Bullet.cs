using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    private void Start()
    {
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            // �Ѿ��� ���� ���� �� ����
            Destroy(gameObject, 3);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            // �Ѿ��� ���� ���� �� ����
            Destroy(gameObject);
        }
    }

    public void DamageUp()
    {
        damage += 100;
    }
}
