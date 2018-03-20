using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampInfo : MonoBehaviour {

    private bool m_IsMarked = false;

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
}
