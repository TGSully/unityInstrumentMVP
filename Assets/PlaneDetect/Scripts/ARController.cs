using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;


public class ARController : MonoBehaviour {

    private List<TrackedPlane> m_NewTrackedPlanes = new List<TrackedPlane>();

    private GameObject GridPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Session.Status != SessionStatus.Tracking)
        {
            return;
        }

        Session.GetTrackables<TrackedPlane>(m_NewTrackedPlanes, TrackableQueryFilter.New);

        for (int i = 0; i < m_NewTrackedPlanes.Count; ++i)
        {
            GameObject grid = Instantiate(GridPrefab, Vector3.zero, Quaternion.identity, transform);

            grid.GetComponent<GridVisualizer>().Initialize(m_NewTrackedPlanes[i]);
        }
	}
}
