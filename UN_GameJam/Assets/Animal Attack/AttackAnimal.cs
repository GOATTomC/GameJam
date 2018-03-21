using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimal : MonoBehaviour {

    private Transform m_Target;
    private Vector3 m_Direction;
    [SerializeField]private float m_Speed;
    [SerializeField] private float m_AttackDistance;
    private bool m_CanMove = false;
    CampInfo m_CampInfo;

	// Use this for initialization
	void Awake () {
        m_Direction = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        CheckDistance();
	}

    public void StartAttack(CampInfo Target)
    {
        m_CampInfo = Target;
        m_Target = Target.transform;
        CalculateDirection();
    }

    private void CalculateDirection()
    {
        m_Direction = m_Target.position - this.transform.position;
        m_Direction.Normalize();
        m_CanMove = true;
        Move();
    }

    private void Move()
    {
        if (!m_CanMove)
            return;

        this.transform.Translate((m_Direction * m_Speed) * Time.deltaTime);
    }

    private void CheckDistance()
    {
        if (!m_CanMove || m_Target == null)
            return;

        if (Vector3.Distance(this.transform.position, m_Target.position) < m_AttackDistance)
        {
            m_CanMove = false;
            SpawnParticle();
            Destroy(this.gameObject);
        }
    }

    private void SpawnParticle()
    {
        m_CampInfo.DestoryCamp();
    }
}
