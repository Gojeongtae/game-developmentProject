using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    // ���� �������� �̵��ϴ� ��ũ��Ʈ

    public Player cam; //����ī�޶�
    private float speed = 0.5f; // �̵��ӵ�

    void Start()
    {
    }

    void Update()
    {
        MoveLookAt();
    }
    void MoveLookAt()
    {
        //����ī�޶� �ٶ󺸴� ����
        Vector3 dir = cam.transform.localRotation * Vector3.forward;
        //ī�޶� �ٶ󺸴� �������� �ٶ󺸰�
        transform.localRotation = cam.transform.localRotation;
        //Rotation.x���� freeze�س������� �������� ���� Rotation���� 0���� ����.
        transform.localRotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);
        //�ٶ󺸴� ���� �������� �̵�.
        gameObject.transform.Translate(dir * 0.1f * Time.deltaTime);
    }
}
