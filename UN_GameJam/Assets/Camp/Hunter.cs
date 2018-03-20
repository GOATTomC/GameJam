using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour {

    private Transform[] m_WalkTargets;
    private int m_CurrentTargetIndex;
    private Vector3 m_MoveDirection;
    private bool m_IsWaiting = false;

    [SerializeField] private float m_MoveSpeed;

    public Transform[] WalkTargets { get { return m_WalkTargets; } set { m_WalkTargets = value; } }

	// Use this for initialization
	void Start () {
        SetNewDirection();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        CheckDestination();
	}

    private void SetNewDirection()
    {
        int newIndex = Random.Range(0, m_WalkTargets.Length);
        if (m_CurrentTargetIndex != newIndex)
        {
            m_CurrentTargetIndex = newIndex;
            m_MoveDirection = m_WalkTargets[m_CurrentTargetIndex].position - this.transform.position;
            Debug.Log(this.transform.name + " " + m_WalkTargets[m_CurrentTargetIndex].name);
            m_MoveDirection.Normalize();

        }
    }

    private void CheckDestination()
    {
        if (Vector3.Distance(this.transform.position, m_WalkTargets[m_CurrentTargetIndex].position) < 3f)
        {
            if (!m_IsWaiting)
            {
                m_IsWaiting = true;
                StartCoroutine(WaitBeforeNewTarget());
            }
        }
    }

    private void Move()
    {
        if (m_IsWaiting)
            return;

        this.transform.Translate((m_MoveDirection * m_MoveSpeed) * Time.deltaTime);
    }

    public void SetWalkTargets(Transform[] campObjects)
    {
        m_WalkTargets = campObjects;
    }

    private IEnumerator WaitBeforeNewTarget()
    {
        yield return new WaitForSeconds(Random.Range(2, 10));
        SetNewDirection();
        m_IsWaiting = false;
    }
}
