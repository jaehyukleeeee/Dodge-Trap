using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudControll : MonoBehaviour {

    Vector3 StartPos; //new Vector3(5.5f, 1.5f, 5f);

    private void OnEnable()
    {
        int randZ = Random.Range(-1, 12);
        transform.position = new Vector3(5.5f, -1.5f, randZ);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x < -4f)
        {
            transform.gameObject.SetActive(false);
        }
        else
        {
            transform.Translate(-Vector3.up * 1f * Time.deltaTime);
        }
	}


}
