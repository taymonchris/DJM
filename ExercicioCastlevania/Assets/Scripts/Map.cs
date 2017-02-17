using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public float period = 0.0f;
    Vector3 pos;
    public GameObject enemy;

    // Use this for initialization
    void Start () {
        pos = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (period > 10.0f)
        {
            //Instantiate(Resources.Load("GiantSkel"));
            Instantiate(enemy,pos,Quaternion.identity);
            period = 0f;
        }
        period += UnityEngine.Time.deltaTime;
    }
}
