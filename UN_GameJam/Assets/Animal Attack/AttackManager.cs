using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {

    public static AttackManager Instance;

    [SerializeField] GameObject[] m_AttackAnimals;
    private     Vector2[] m_OutsideScreenPositions = new Vector2[8]; //0 topleft 1middleleft 2 bottomleft 3 bottommiddle 4 bottomright 5 middleright 6 topright 7 topmiddle

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateSpawnPositions();
	}

    public void AttackCamp(CampItem[] CampObjects, Hunter Hunter, CampInfo CampInfo)
    {
        SpawnAnimals(CampObjects, Hunter, CampInfo);
    }

    private void SpawnAnimals(CampItem[] CampObjects, Hunter Hunter, CampInfo CampInfo)
    {
        for (int animal = 0; animal < m_AttackAnimals.Length; animal++)
        {
            AttackAnimal tempAnimal = Instantiate(m_AttackAnimals[Random.Range(0, m_AttackAnimals.Length)], m_OutsideScreenPositions[Random.Range(0, m_OutsideScreenPositions.Length)], Quaternion.identity).GetComponent<AttackAnimal>();
            tempAnimal.StartAttack(CampInfo);
        }
    }

    private void UpdateSpawnPositions()
    {
        m_OutsideScreenPositions[0] = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height)) + new Vector3(-5, +5);
        m_OutsideScreenPositions[1] = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 2)) + new Vector3(-5, 0);
        m_OutsideScreenPositions[2] = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0)) + new Vector3(0, -5);
        m_OutsideScreenPositions[4] = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)) + new Vector3(+5, -5);
        m_OutsideScreenPositions[5] = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2)) + new Vector3(+5, 0);
        m_OutsideScreenPositions[6] = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)) + new Vector3(+5, +5);
        m_OutsideScreenPositions[7] = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height)) + new Vector3(0, +5);
    }
}
