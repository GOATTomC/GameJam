using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour {

    private Transform[] m_WalkTargets;
    private int m_CurrentTargetIndex;
    private Vector3 m_MoveDirection;
    private bool m_IsWaiting = false;
    private bool m_IsScared = false;
    private Vector3 old_pos;
    Animator walk;

    [SerializeField] private float m_MoveSpeed;

    public Transform[] WalkTargets { get { return m_WalkTargets; } set { m_WalkTargets = value; } }

	// Use this for initialization
	void Start () {
        SetNewDirection();
        walk = GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        CheckDestination();
        Check_movement();
        old_pos = transform.position;
    }
    void Check_movement()
    {
        if (old_pos == transform.position)
        {
            walk.SetInteger("Speed", 0);
            old_pos = transform.position;
        }
        else
        {
            walk.SetInteger("Speed", 1);
        }
                }
    private void SetNewDirection()
    {
        int newIndex = Random.Range(0, m_WalkTargets.Length);
        if (m_CurrentTargetIndex != newIndex)
        {
            m_CurrentTargetIndex = newIndex;
            m_MoveDirection = m_WalkTargets[m_CurrentTargetIndex].position - this.transform.position;
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
        if (m_IsWaiting && !m_IsScared)
            return;

        this.transform.Translate((m_MoveDirection * m_MoveSpeed) * Time.deltaTime);
      
    }

    public void SetWalkTargets(Transform[] campObjects)
    {
        m_WalkTargets = campObjects;
    }

    private IEnumerator WaitBeforeNewTarget()
    {
        
        yield return new WaitForSeconds(Random.Range(2, 5));
        SetNewDirection();
        m_IsWaiting = false;
        
    }

    public void Scare()
    {
        m_MoveSpeed = 10;
        Vector2 direction = (Random.insideUnitCircle * 3) + new Vector2(this.transform.position.x, this.transform.position.y);
        direction.Normalize();

        m_MoveDirection = direction;
        m_IsScared = true;
        Destroy(this.gameObject, 5f);
    }
}
