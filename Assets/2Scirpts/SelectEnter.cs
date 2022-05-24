
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ʈ���� ������� ����� : ��ũ��Ʈ#2. Ʈ������
// ���� : ������ ������ �� Ʈ���ſ� ������ ��������� ����մϴ�.
//  �÷��̾��� tag �Ӽ��� 'myplayer'�� �����ְų�, �Ʒ��� �ҽ��� ������ �ֽø� �˴ϴ�.
// �ּ��� �������� �ʴ� �������� �����Ӱ� ����ϼŵ� �˴ϴ�.
// ���� : Cray
// ��α� : ũ������ IT Ž�� https://itadventure.tistory.com/415
public class SelectEnter : MonoBehaviour
{
    public GameObject UI;
    public GameObject MonsterA;
    public GameObject MonsterB;
    public GameObject MonsterC;
    public GameObject MonsterD;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UI.SetActive(true);
            MonsterA.SetActive(true);
            MonsterB.SetActive(true);
            MonsterC.SetActive(true);
            MonsterD.SetActive(true);
            Destroy(gameObject);
        }
    }
}