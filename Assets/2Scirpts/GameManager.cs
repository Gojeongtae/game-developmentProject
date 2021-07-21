using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuCam;
    public GameObject gameCam;
    public Player player;
    public int stage;
    public float playTime;
    public bool isBattle;
    public int enemyCntA;
    public int enemyCntB;
    public int enemyCntC;

    public GameObject menuPanel;
    public GameObject gamePanel;
    public Text A;
    public Text B;
    public Text C;


    void LateUpdate()
    {

        A.text = "�÷��̾� ü�� " + player.health + " / " + player.maxHealth;
        B.text = string.Format("�÷��̾� ���� {0} / {1}", player.coin, player.maxCoin);
        C.text = string.Format("���� �� {0} / {1}", player.ammo, player.maxAmmo);

    }
}
