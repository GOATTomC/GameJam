using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    private HighScore m_Scores;
    [SerializeField] private Text m_ScoreText;
    [SerializeField] private Text m_NameText;

    [SerializeField] private GameObject m_TextTemplate;
    [SerializeField] private GameObject m_ScoreParent;

    private List<int> m_ScoresB;
    private List<string> m_NamesB;

    // Use this for initialization
    void Start () {
        m_ScoreText.text = "Your Score: " + ScoreManager.Instance.GetScore().ToString();
        LoadData();
        GenerateScoreList();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/HighScore.json"))
        {
            string dataAsJson = File.ReadAllText(Application.persistentDataPath + "/HighScore.json");

            try
            {
                m_Scores = JsonUtility.FromJson<HighScore>(dataAsJson);
                m_ScoresB = new List<int>(m_Scores.Scores);
                m_NamesB = new List<string>(m_Scores.Names);

                for (int i = 0; i < m_Scores.Scores.Count; i++)
                {
                    Debug.Log(m_Scores.Scores[i]);
                }
            }
            catch
            {
                m_Scores = new HighScore();
                m_Scores.Scores = new List<int>();
                m_Scores.Names = new List<string>();
            }

        }
        else
        {
            m_Scores = new HighScore();
            m_Scores.Scores = new List<int>();
            m_Scores.Names = new List<string>();
        }
    }

    public void SaveScore()
    {
        m_ScoresB.Add(ScoreManager.Instance.GetScore());
        m_NamesB.Add(m_NameText.text);
        m_Scores.Scores = new List<int>(m_ScoresB);
        m_Scores.Names = new List<string>(m_NamesB);
        WriteData();
    }

    private void WriteData()
    {
        string json = JsonUtility.ToJson(m_Scores);
        string filePath = Application.persistentDataPath + "/HighScore.json";

        using (StreamWriter stw = new StreamWriter(filePath))
        {
            stw.WriteLine(json);
        }

    }

    private void GenerateScoreList()
    {

        if (m_Scores.Scores == null)
            return;

        int highestScoreIndex = 0;
        int highestScore = 0;
        List<int> scores = new List<int>(m_ScoresB);
        List<string> names = new List<string>(m_NamesB);

        for (int i = 0; i < m_ScoresB.Count; i++)
        {
            for (int j = 0; j < scores.Count; j++)
            {
                if (scores[j] >= highestScore)
                {
                    highestScoreIndex = j;
                    highestScore = scores[j];
                }
            }

            Text text = Instantiate(m_TextTemplate, m_ScoreParent.transform).GetComponent<Text>();
            text.text = names[highestScoreIndex] + ": " + scores[highestScoreIndex];
            scores.RemoveAt(highestScoreIndex);
            names.RemoveAt(highestScoreIndex);
            highestScore = 0;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(2);
    }
}
