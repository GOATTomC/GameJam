using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTraces : MonoBehaviour {

    [SerializeField] private GameObject m_FootStep;
    [SerializeField] private float m_FootStepRadius;

    private Vector2[] m_CampLocations;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGeneratingTraces(Vector2[] CampLocations)
    {
        m_CampLocations = CampLocations;

        PlaceFootsteps();
    }

    private void PlaceFootsteps()
    {
        for (int camp = 0; camp < m_CampLocations.Length; camp++)
        {
            Vector2 target = m_CampLocations[camp];
            int amountOfTraces = Random.Range(2, 4);

            for (int trace = 0; trace < amountOfTraces; trace++)
            {
                bool traceIsPlaced = false;

                while (!traceIsPlaced)
                {
                    Vector2 randTraceLocation = (Random.insideUnitCircle * m_FootStepRadius) + new Vector2(target.x, target.y);

                    if (CanPlace(randTraceLocation))
                    {
                        GameObject traceObj = Instantiate(m_FootStep, randTraceLocation, Quaternion.identity, this.transform);
                        traceObj.GetComponent<Footstep>().Initialize(target);
                        target = traceObj.transform.position;
                        traceIsPlaced = true;
                    }
                }
            }
        }
    }

    private bool CanPlace(Vector2 Location)
    {
        Collider2D[] colls = Physics2D.OverlapBoxAll(Location, new Vector2(4, 2), 0);

        if (colls.Length != 0)
            return false;

        return true;
    }


}
