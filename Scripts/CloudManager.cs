using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour {

    public List<GameObject> cloudList = new List<GameObject>();
    int count = 0;

	// Use this for initialization
	void Start () {
        //SpawnCloud();
        StartCoroutine("SpawnCloud");
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    IEnumerator SpawnCloud()
    {
        if(count == 10)
        {
            count = 0;
        }
        cloudList[count].SetActive(true);
        count++;
        yield return new WaitForSeconds(1.5f);
        StartCoroutine("SpawnCloud");
    }
}
