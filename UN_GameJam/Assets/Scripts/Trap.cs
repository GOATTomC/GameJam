using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    [SerializeField] private GameObject m_DismantleCloud;
    private Animator m_Animator;

    private void Awake()
    {
        m_Animator = this.GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Disable()
    {
        Destroy(this.gameObject, 3f);
    }

    private void Activate()
    {
        this.m_Animator.SetTrigger("Activate");
    }

    public void Dismantle()
    {
        GameObject temp = Instantiate(m_DismantleCloud, this.transform.position, Quaternion.identity);
        Destroy(temp, 2f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Activate();
    }

}
