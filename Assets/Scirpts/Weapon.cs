using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public enum Type { Melee, Range };
    public Type type;
    public int damage;
    public float rate;
    public BoxCollider meleeArea;
    public TrailRenderer trailEffect;

    public void Use()
    {
        if(type == Type.Melee)
        {
            Swing();
        }
    }

    IEnumerator Swing()
    {
        //1
        yield return null; //1������ ���
        //2
        yield return null; //1������ ���
        yield return new WaitForSeconds(0.1f); //0.1�� ���
        yield break; //break�� �ڷ�ƾ Ż�� ���� �׷��� break ���� �Լ��� 
        //���� �ȵǱ� ������ ������ ��.

    }

    //use() ���η�ƾ -> swing() �����ƾ -> Use() ���η�ƾ
    //use() ���η�ƾ + swing() �ڷ�ƾ(���� ����Ǵ� ����. co)
    //�츮�� �ڷ�ƾ�� ������, ������ �Լ� IEnumerator, ����� �����ϴ� yield
    //
}
