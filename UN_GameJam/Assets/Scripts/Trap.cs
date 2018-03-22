using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    [SerializeField] private GameObject m_DismantleCloud;
    private Animator m_Animator;
    [SerializeField] private AudioClip m_DisClip;
    private bool m_CanDoDamage = true;

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
        if (!m_CanDoDamage)
            return;

        this.m_Animator.SetTrigger("Activate");
        ScoreManager.Instance.SubstractScore(100);

    }

    public void PlaySFX()
    {
        this.GetComponent<AudioSource>().Play();
    }

    public void Dismantle()
    {
        this.GetComponent<AudioSource>().clip = m_DisClip;
        this.GetComponent<AudioSource>().Play();
        GameObject temp = Instantiate(m_DismantleCloud, this.transform.position, Quaternion.identity);
        Destroy(temp, 2f);
        Destroy(this.gameObject, 1.9f);
        ScoreManager.Instance.AddScore(50);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Activate();
    }

}
