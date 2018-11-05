using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFinshController : MonoBehaviour {

    [SerializeField] private bool StartRow = false;
    [SerializeField] private bool FinshRow = false;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (StartRow == true)
            {
                transform.GetChild(i).tag = "Start";
            }
            else if (FinshRow == true)
            {
                transform.GetChild(i).tag = "Finish";
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void ChangeRows()
    {
        if (StartRow == true)
        {
            StartRow = false;
            FinshRow = true;
        }
        else if (FinshRow == true)
        {
            StartRow = true;
            FinshRow = false;
        }
        ChangeBlocks();
    }

    void ChangeBlocks()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if (StartRow == true)
            {
                transform.GetChild(i).tag = "Start";
            }
            else if (FinshRow == true)
            {
                transform.GetChild(i).tag = "Finish";
            }
        }
    }
}
