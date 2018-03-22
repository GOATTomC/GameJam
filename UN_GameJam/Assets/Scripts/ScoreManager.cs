using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private int m_CurrentScore;
    [SerializeField]private Text m_ScoreText;

    public static ScoreManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start () {
        UpdateText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddScore(int amountToAdd)
    {
        m_CurrentScore += amountToAdd;
        UpdateText();
    }

    public void SubstractScore(int amountToSubstract)
    {
        if ((m_CurrentScore - amountToSubstract) < 0)
            return;

        m_CurrentScore -= amountToSubstract;
        UpdateText();
    }

    private void UpdateText()
    {
        m_ScoreText.text = "Score: " + m_CurrentScore;
    }

    public int GetScore()
    {
        return m_CurrentScore;
    }
}

[System.Serializable]
public class HighScore
{
    public List<int> Scores;
    public List<string> Names;
}
