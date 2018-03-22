using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    [SerializeField] private GameObject m_PausePanel;
    public bool IsPaused;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandleInput();
	}

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {


            m_PausePanel.SetActive(!m_PausePanel.activeSelf);

            if (m_PausePanel.activeSelf)
            {
                IsPaused = true;
            }
            else
            {
                IsPaused = false;
            }
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        m_PausePanel.SetActive(!m_PausePanel.activeSelf);

        IsPaused = false;
    }
}
