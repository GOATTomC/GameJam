using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampItem : MonoBehaviour {

    private CampInfo m_CampInfo;
    [SerializeField] private Sprite m_DestroyedItem;
    
    public CampInfo CampInfo { get { return m_CampInfo; } set { m_CampInfo = value; } }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Destroy()
    {
        this.GetComponent<SpriteRenderer>().sprite = m_DestroyedItem;
    }
}
