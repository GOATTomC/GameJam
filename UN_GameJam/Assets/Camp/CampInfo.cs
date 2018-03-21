using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampInfo : MonoBehaviour {

    private bool m_IsMarked = false;

    private CampItem[] m_CampItems;
    //public CampItem[] CampItems { get { return m_CampItems; } set { m_CampItems = value; } }

    private Hunter m_Hunter;
    private bool m_IsAttacked = false;

    private GameObject m_Marker;

    [SerializeField] private GameObject AttackCloud;

    public Vector2 GetPosition()
    {
        m_IsMarked = true;
        return this.transform.position;
    }

    public bool CanMark()
    {
        if (m_IsMarked)
            return false;


        return true;
    }

    public void SetCampItems(CampItem[] Items)
    {
        m_CampItems = Items;
    }

    public void SetHunter(Hunter Hunter)
    {
        m_Hunter = Hunter;
    }

    public void AttackCamp(GameObject marker)
    {
        m_Marker = marker;
        StartCoroutine(CallAttackOnCamp());
    }

    private IEnumerator CallAttackOnCamp()
    {
        yield return new WaitForSeconds(Random.Range(2, 6));
        AttackManager.Instance.AttackCamp(m_CampItems, m_Hunter, this);
    }

    public void DestoryCamp()
    {
        if (m_IsAttacked)
            return;

        m_IsAttacked = true;
        Instantiate(AttackCloud, this.transform.position, Quaternion.identity);
        StartCoroutine(DestroyItems());
        Destroy(m_Marker);
    }

    private IEnumerator DestroyItems()
    {
        yield return new WaitForSeconds(1f);
        for (int campObject = 0; campObject < m_CampItems.Length; campObject++)
        {
            m_CampItems[campObject].Destroy();
        }
        m_Hunter.Scare();
    }
}
