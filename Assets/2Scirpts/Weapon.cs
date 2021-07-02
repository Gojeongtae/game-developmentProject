using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    public enum Type { Melee, Range };
    public Type type;
    public int damage;
    public float rate;
    public BoxCollider meleeArea;
    public TrailRenderer trailEffect;
    public Transform bulletPos;
    public GameObject bullet;
    public Transform bulletCasePos;
    public GameObject bulletCase;


    public Text A;
    public Text B;
    public Text C;
    public Text D;


    public int wind_velocity;

    Vector3 myHeight;

    public void Use()
    {
        if(type == Type.Melee)
        {
            StopCoroutine("Swing");
            StartCoroutine("Swing");
        }
        else if (type == Type.Range)
        {
            StartCoroutine("Shot");
        }

    }

    IEnumerator Swing()
    {
        yield return new WaitForSeconds(0.1f); //0.1�� ���
        meleeArea.enabled = true;
        trailEffect.enabled = true;

        yield return new WaitForSeconds(0.3f);
        meleeArea.enabled = false;

        yield return new WaitForSeconds(0.3f);
        trailEffect.enabled = false;
    }

    IEnumerator Shot()
    {

        GameObject intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        Rigidbody bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.AddForce(bulletPos.forward * 1000);
        yield return new WaitForSeconds(4f);
        intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.AddForce(bulletPos.forward * 1200);
        yield return new WaitForSeconds(4f);
        intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.AddForce(bulletPos.forward * 1400);
       
        yield return new WaitForSeconds(4f);
        intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.AddForce(bulletPos.forward * 2000);
        bulletRigid.velocity = bulletPos.forward * wind_velocity;
        yield return new WaitForSeconds(4f);
        intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.AddForce(bulletPos.forward * 2200);
        bulletRigid.velocity = bulletPos.forward * wind_velocity;
        yield return new WaitForSeconds(4f);
        intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.AddForce(bulletPos.forward * 2400);
        bulletRigid.velocity = bulletPos.forward * wind_velocity;
        yield return new WaitForSeconds(4f);
        intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.AddForce(bulletPos.forward * 2600);
        bulletRigid.velocity = bulletPos.forward * wind_velocity;
        yield return new WaitForSeconds(4f);
        intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.AddForce(bulletPos.forward * 2800);
        bulletRigid.velocity = bulletPos.forward * wind_velocity;
        yield return new WaitForSeconds(4f);
        intantBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
        bulletRigid = intantBullet.GetComponent<Rigidbody>();
        bulletRigid.AddForce(bulletPos.forward * 3000);
        bulletRigid.velocity = bulletPos.forward * wind_velocity;
        yield return new WaitForSeconds(4f);
      
     
    }

/*    void Update()
    {
        GameObject obj = GameObject.Find("Sphere(Clone)");

        Rigidbody X = obj.GetComponent<Rigidbody>();

        

        A.text = string.Format("���� ��ź�� ��ġ {0}", obj.gameObject.transform.position);
        B.text = string.Format("���� ��ź�� ���߷� {0}", X.velocity.x);
        C.text = string.Format("���� ��ź�� mass {0:0.00}kg", X.mass);
        D.text = string.Format("���� �ٶ��� ����� �ӵ� {0:0.00}m/s", wind_velocity);
        
    }         

 */

    //use() ���η�ƾ -> swing() �����ƾ -> Use() ���η�ƾ
    //use() ���η�ƾ + swing() �ڷ�ƾ(���� ����Ǵ� ����. co)
    //�츮�� �ڷ�ƾ�� ������, ������ �Լ� IEnumerator, ����� �����ϴ� yield
    //
}
