using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Base : MonoBehaviour, IHit
{
    private Transform resourceTranform = null;

    protected int HP;
    protected int damage = 0;

    protected GameObject resource = null;
    public GameObject[] ResourcePrefabs = null;

    private void Awake()
    {
        resourceTranform = GameObject.Find("GetResource").transform;
    }
    private void OnEnable()
    {
        HP = 10;
    }
    // ������Ʈ�� ���Ǿ��� �� ������ �Լ�
    public virtual void OnHit()
    {
        HP -= damage;
    }
    // ������Ʈ�� �ı��Ǿ��� �� ������ �Լ�
    protected void Destroyed()
    {
        Debug.Log("destroyed");
        resource.SetActive(false);
    }
    // �ڿ� ���� �Լ�
    public void ResourceGenerate()
    {
        int resourceType = Random.Range(0, ResourcePrefabs.Length);
        GameObject gameObject =  GameObject.Instantiate(ResourcePrefabs[resourceType], this.transform);
        gameObject.transform.parent = resourceTranform;
    }
}
