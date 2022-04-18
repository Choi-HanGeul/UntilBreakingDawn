using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum WeaponDamage_Rock
{
    Hand = 2,
    Knife = 5,
    Pickax = 30,
    Axe = 10
}
public class Resource_Rock : Resource_Base
{
    WeaponDamage_Rock weaponDamage = WeaponDamage_Rock.Knife; // ���� ���� : �⺻ �������� hand

    public AudioSource[] AudioSources;

    private void OnEnable()
    {
        base.HP = 10; // ******************************** ���� ��ġ = 100 **************************************
    }
    public override void OnHit()
    {
        // Resource_Base�� damage�� ������ ��������ġ�� ��ȯ �� ������ ��� �Լ� ����
        base.damage = (int)weaponDamage;
        //Debug.Log(damage);
        base.OnHit();
        //Debug.Log(HP);
        AudioSources[0].Play();
    }
    // ������ ������ ���� Ȯ��
    private void OnCollisionExit(Collision collision)
    {
        // ������ ����(�ö��̴�)�� ������ ���� ������ ����
        if (collision.gameObject.CompareTag("Player"))
        {
            weaponDamage = WeaponDamage_Rock.Hand;
        }
        OnHit();
        // �ڿ��� HP==0�� �ڿ� �ı�
        if (HP <= 0)
        {
            AudioSources[1].Play();
            Destroyed();
        }
    }

    // ���� ���� �÷��̾ ���� �� �ڿ��� �⺻���� ����
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            resource = this.gameObject;
        }
    }
}
