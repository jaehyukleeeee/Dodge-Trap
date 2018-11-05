using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EditorManager : MonoBehaviour {

    public Ray ray;
    public RaycastHit hitinfo;

    public int[,] editPattern = new int[7, 3];

    public int[] CurArrayPattern;

    public List<int[]> CurCustomPatternList = new List<int[]>();

    public Text patternCountText;

    public static int patternCount = 0;

	// Use this for initialization
	void Start () {
        Debug.Log(editPattern[0,0]);
        Array.Clear(editPattern, 0, editPattern.Length);
        
    }
	
	// Update is called once per frame
	void Update () {
        patternCountText.text = patternCount.ToString();
        if (GamePlayManager.Instance.isEditor)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Input.GetMouseButtonDown(0))
            {
                if(Physics.Raycast(ray, out hitinfo))
                {
                    hitinfo.transform.GetComponent<CubeController>().SetBomb();
                    editPattern[int.Parse(hitinfo.transform.parent.name), int.Parse(hitinfo.transform.gameObject.name)] = System.Convert.ToInt32(hitinfo.transform.GetComponent<CubeController>().GetBomb());
                    Debug.Log("["+ hitinfo.transform.parent.name + ", "+ hitinfo.transform.gameObject.name+"]");
                    Debug.Log(editPattern[int.Parse(hitinfo.transform.parent.name), int.Parse(hitinfo.transform.gameObject.name)]);
                }
            }

        }
    }

    public void NextButton()
    {
        //ConvertArrary();
        CurCustomPatternList.Add(ConvertArrary());
        SaveJson.Instance.SavePattern(patternCount, CurCustomPatternList[patternCount]);
        SaveJson.Instance.AutoNullMaker(patternCount++);
        //patternCount++;
        //Array.Clear(editPattern, 0, editPattern.Length);
    }

    int[] ConvertArrary()
    {
        int[] pattern;
        int Max = 0; //이거 밖으로 빼야됨(잘모르겟 일단실행은됨)

        if(Max < CurArrayPattern.Length)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    CurArrayPattern[Max] = editPattern[i, j];
                    Max++;
                }
            }
        }

        pattern = CurArrayPattern;

        return pattern;
    }
}
