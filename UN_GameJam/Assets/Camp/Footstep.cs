using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour {

    [SerializeField]private Transform m_Target;

    public Transform Target { get { return m_Target; } set { m_Target = value; } }

	// Use this for initialization
	void Start () {
        Vector3 difference = m_Target.position - this.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
