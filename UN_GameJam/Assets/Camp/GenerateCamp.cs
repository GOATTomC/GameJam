using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCamp : MonoBehaviour {

    [SerializeField] private GameObject[] m_CampObjects;
    [SerializeField] private GameObject m_HunterObject;
    [SerializeField] private GameObject m_CampInfoPrefab;
    [SerializeField] private GameObject m_TrapPrefab;


    [SerializeField] private int m_AmountOfCamps;
    [SerializeField] private Vector2 m_RadiusBox;
    [SerializeField] private float m_GenCheckRadius;
    [SerializeField] private float m_TrapAmount;

	// Use this for initialization
	void Awake () {

	}

    private void Start()
    {
        ChooseGenPosition();
        GenTraps();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void ChooseGenPosition()
    {
        Vector2[] spawnPositions = new Vector2[m_AmountOfCamps];

        for (int i = 0; i < spawnPositions.Length; i++)
        {
            spawnPositions[i].x = Random.Range(transform.position.x - m_RadiusBox.x / 2, transform.position.x + m_RadiusBox.x / 2);
            spawnPositions[i].y = Random.Range(transform.position.y - m_RadiusBox.y / 2, transform.position.y + m_RadiusBox.y / 2);

            //TODO ? Check if it is even possible to gen there?
        }

        GenCamp(spawnPositions);
        
    }

    private void GenCamp(Vector2[] spawnPositions)
    {
        for (int spawnPos = 0; spawnPos < spawnPositions.Length; spawnPos++)
        {
            Transform[] objects = new Transform[4];
            for (int campObj = 0; campObj < m_CampObjects.Length; campObj++)
            {
                bool isPlaced = false;

                while (!isPlaced)
                {

                    Vector2 randomLocation = (Random.insideUnitSphere * m_GenCheckRadius) + new Vector3(spawnPositions[spawnPos].x, spawnPositions[spawnPos].y);
                    if (CanPlace(randomLocation, m_CampObjects[campObj]))
                    {
                        objects[campObj] = Instantiate(m_CampObjects[campObj], randomLocation, Quaternion.identity, this.transform).transform;
                        isPlaced = true;
                    }
                }
            }
            GenCampInfo(objects);
        }

        this.GetComponent<GenerateTraces>().StartGeneratingTraces(spawnPositions);
    }

    private bool CanPlace(Vector2 location, GameObject objectToSpawn)
    {
        Collider2D[] colls = Physics2D.OverlapBoxAll(location, new Vector2(4, 4), 0);

        if (colls.Length != 0)
            return false;

        return true;
    }

    private void SpawnHunter(Vector2 SpawnPosition, Transform[] campObjects, CampInfo CampInfo)
    {
        GameObject tempHunter = Instantiate(m_HunterObject, SpawnPosition, Quaternion.identity, this.transform);
        tempHunter.GetComponent<Hunter>().SetWalkTargets(campObjects);
        CampInfo.SetHunter(tempHunter.GetComponent<Hunter>());
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(this.transform.position, m_RadiusBox);
    }

    private void GenCampInfo(Transform[] objects)
    {
        Vector3 averagePosition = Vector2.zero;

        CampItem[] items = new CampItem[objects.Length];
        for (int objectCamp = 0; objectCamp < objects.Length; objectCamp++)
        {
            items[objectCamp] = objects[objectCamp].GetComponent<CampItem>();
        }

        for (int campObject = 0; campObject < objects.Length; campObject++)
        {
            averagePosition += objects[campObject].position;
        }

        averagePosition /= objects.Length;

        CampInfo tempCampInfo = Instantiate(m_CampInfoPrefab, averagePosition, Quaternion.identity, this.transform).GetComponent<CampInfo>();

        for (int campObject = 0; campObject < objects.Length; campObject++)
        {
            if (tempCampInfo != null)
            {
                objects[campObject].GetComponent<CampItem>().CampInfo = tempCampInfo;
                tempCampInfo.SetCampItems(items);
            }

        }

        SpawnHunter(averagePosition, objects, tempCampInfo);
    }

    private void GenTraps()
    {
        for (int i = 0; i < m_TrapAmount; i++)
        {
            Instantiate(m_TrapPrefab, new Vector3(Random.Range(this.transform.position.x - (m_RadiusBox.x / 2), this.transform.position.x + (m_RadiusBox.y / 2)), Random.Range(this.transform.position.y - (m_RadiusBox.y / 2), this.transform.position.y + (m_RadiusBox.y) / 2)), Quaternion.identity);
        }
    }


}
