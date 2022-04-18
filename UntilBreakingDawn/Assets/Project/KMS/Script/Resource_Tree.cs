using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum WeaponDamage_Tree
{
    Hand = 3,
    Knife = 15,
    Pickax = 10,
    Axe = 30,
    Default = 5
}
public class Resource_Tree : Resource_Base
{    
    WeaponDamage_Tree weaponDamage = WeaponDamage_Tree.Knife;

    public AudioSource[] AudioSources;

    public override void OnHit()
    {
        // Resource_Base�� damage�� ������ ��������ġ�� ��ȯ �� ������ ��� �Լ� ����
        base.damage = (int)weaponDamage;
        base.OnHit();
        AudioSources[0].Play();
        if (HP <= 0)
        {
            AudioSources[1].Play();
            base.ResourceGenerate();
            ResourceObject.Inst.Type = 1;
            base.Destroyed();
        }
    }

    // ������ ������ ���� Ȯ��
    // ���� ���� �÷��̾ ���� �� �ڿ��� ���� ����
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ******************************** test�� ���� Player tag ��� �� ���� �������� tag�� �����Ұ� ****************************
        {
            resource = this.gameObject;
            weaponDamage = WeaponDamage_Tree.Hand;
        }
        else
        {
            weaponDamage = WeaponDamage_Tree.Default;
        }
    }
}
