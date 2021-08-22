using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwlDamage : Bullet
{
    private void Awake()
    {
        Invoke("ColliderSystem", 0);
    }
    void Update()
    {
        
        Destroy(gameObject, 1f);
    }

    void ColliderSystem() 
    {
        // Awl�� Triger �����ϱ� ��� �и��� ���� �ذ��ϱ� ���ؼ� Awl ���� ������Ʈ�� Empty�� ������ �ְ� Damage�� ���� 
        Collider collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }

}
