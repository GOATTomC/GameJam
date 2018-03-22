using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    private float m_TimeLeftSeconds = 30;
    [SerializeField] private Text m_TimerText;
    private bool m_IsZero = false;

	// Use this for initialization
	void Start () {
		
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



