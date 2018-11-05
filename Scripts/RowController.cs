using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowController : MonoBehaviour {

    [SerializeField]private string diff = "None";
    public bool GameReady = false;
    // Use this for initialization
    void Start () {
        GameReady = false;
        diff = LoadJson.Instance.difficulty;

        switch (diff)//난이도 정하기
        {
            case "Easy":
                /*transform.GetChild(0).name = "x";
                transform.GetChild(0).gameObject.SetActive(false);

                transform.GetChild(1).name = "x";
                transform.GetChild(1).gameObject.SetActive(false);
                

                transform.GetChild(2).name = "0";
                transform.GetChild(3).name = "1";

                transform.GetChild(4).name = "2"; //x
                //transform.GetChild(4).gameObject.SetActive(false);

                transform.GetChild(5).name = "x";
                transform.GetChild(5).gameObject.SetActive(false);*/

                GameReady = true;
                break;
            case "Normal":
                transform.GetChild(0).name = "x";
                transform.GetChild(0).gameObject.SetActive(false);

                transform.GetChild(1).name = "0";
                transform.GetChild(2).name = "1";
                transform.GetChild(3).name = "2";
                transform.GetChild(4).name = "3";
       
                transform.GetChild(5).name = "4"; //x
                //transform.GetChild(5).gameObject.SetActive(false);
                GameReady = true;
                break;
            case "Hard":
                GameReady = true;
                break;
            case "None":
                Debug.Log("초기화 에러");
                break;
        }

        //if (transform.name != "Start" && transform.name != "Finish")
        //{
        //    for (int i = 0; i < transform.childCount; i++)
        //    {
        //        if (transform.name == i.ToString())
        //        {
        //            if (transform.GetChild(i).name != "x")
        //            {
        //                GameManager.Instance.cubeList.Add(transform.GetChild(i).gameObject);
        //            }
        //        }
        //    }
        //}



    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
