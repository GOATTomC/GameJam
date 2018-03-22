using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    private float m_TimeLeftSeconds = 30;
    [SerializeField] private Text m_TimerText;
    [SerializeField] private AudioSource m_TickAudio;
    [SerializeField] private AudioClip m_Tick;
    [SerializeField] private AudioClip m_Tock;
    private bool m_IsZero = false;
    private bool m_IsEven;
    private bool m_Previous = false;
    private Color m_NormalColor;

	// Use this for initialization
	void Start () {
        m_NormalColor = m_TimerText.color;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateTimer();
        CheckTimer();
	}

    private void UpdateTimer()
    {

        if (!m_IsZero)
            m_TimeLeftSeconds -= Time.deltaTime;

        m_IsEven = Mathf.Floor(m_TimeLeftSeconds % 2) > 0 ? false : true;

        if (m_IsEven != m_Previous)
        {
            if (m_TimeLeftSeconds <= 10)
            {
                m_TickAudio.clip = m_IsEven == true ? m_Tock : m_Tick;
                m_TickAudio.Play();
                m_Previous = m_IsEven;
            }
        }

        m_TimerText.color = m_IsEven == true ? Color.red : m_NormalColor;

        float minutes = Mathf.Floor(m_TimeLeftSeconds / 60);
        float seconds = Mathf.RoundToInt(m_TimeLeftSeconds % 60);

        m_TimerText.text = "Time Left " + (minutes < 0 ? 0.ToString() : minutes.ToString()) + ":" + Mathf.Abs(seconds).ToString();


    }

    private void CheckTimer()
    {
        if (m_TimeLeftSeconds <= 0)
        {
            Debug.Log("End Game");
            this.GetComponent<AudioSource>().Play();
            if (!m_IsZero)
                StartCoroutine(SwitchToEnd());
            m_IsZero = true;
        }

    }

    private IEnumerator SwitchToEnd()
    {
        yield return null;
        
        SceneManager.LoadScene(3);
    }
}



