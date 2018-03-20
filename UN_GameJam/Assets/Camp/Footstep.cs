using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour {

    [SerializeField]private Vector2 m_Target;

    public void Initialize(Vector2 Target)
    {
        m_Target = Target;

        Vector3 difference = new Vector3(m_Target.x, m_Target.y) - this.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
