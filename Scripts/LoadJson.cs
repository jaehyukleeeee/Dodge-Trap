using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadJson : MonoBehaviour {

    public List<TextAsset> JsonPatternList = new List<TextAsset>();

    public TextAsset jsonData;

    public string JsonDataNum;

    public int stage_id = 0;
    public string author = null;
    public string difficulty = null;
    public int level = 0;

    ArrayList patternData = new ArrayList();
    [SerializeField]public List<int[]> pattern = new List<int[]>();
    LitJson.JsonData getData;

    #region Singleton Initialize

    private static LoadJson sInstance;

    public static LoadJson Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = FindObjectOfType(typeof(LoadJson)) as LoadJson;
                if(sInstance == null)
                {
                    GameObject newGameObject = new GameObject("_JsonManager");
                    sInstance = newGameObject.AddComponent<LoadJson>();
                }
            }

            return sInstance;
        }
    }

    #endregion

    private void Awake()
    {
        if(JsonDataNum == null)//if (GamePlayManager.Instance.isChallenge)
            GetJsonFileAll();
        else
            GetJsonFileOne(JsonDataNum);
        
        //DontDestroyOnLoad(gameObject);
        //LitJson.JsonData 

    }

    public void GetJsonFileAll()
    {
        patternData.Clear();
        pattern.Clear();

        int rand = Random.Range(0, JsonPatternList.Count);
        getData = LitJson.JsonMapper.ToObject(JsonPatternList[rand].text);//jsonData.text);
        stage_id = (int)getData["stage_id"];
        author = getData["author"].ToString();
        difficulty = getData["difficulty"].ToString();
        level = (int)getData["level"];


        for (int i = 0; i < getData["pattern"].Count; i++)
        {
            for (int j = 0; j < getData["pattern"][i]["pattern"].Count; j++)
            {
                int value = 0;
                value = (int)getData["pattern"][i]["pattern"][j];
                patternData.Add(value);
            }
            pattern.Add((int[])patternData.ToArray(typeof(int)));
            Debug.Log(pattern[i][0] + " " + i.ToString());
            patternData.Clear();
        }

        Debug.Log("stage_id : " + stage_id.ToString());
        Debug.Log("author : " + author);
        Debug.Log("difficulty : " + difficulty);
        Debug.Log("level : " + level.ToString());
    }

    public void GetJsonFileOne(string dataNum)
    {
        patternData.Clear();
        pattern.Clear();

        //int rand = Random.Range(0, JsonPatternList.Count);
        jsonData = Resources.Load(dataNum) as TextAsset;

        getData = LitJson.JsonMapper.ToObject(jsonData.text);
        stage_id = (int)getData["stage_id"];
        author = getData["author"].ToString();
        difficulty = getData["difficulty"].ToString();
        level = (int)getData["level"];


        for (int i = 0; i < getData["pattern"].Count; i++)
        {
            for (int j = 0; j < getData["pattern"][i]["pattern"].Count; j++)
            {
                int value = 0;
                value = (int)getData["pattern"][i]["pattern"][j];
                patternData.Add(value);
            }
            pattern.Add((int[])patternData.ToArray(typeof(int)));
            Debug.Log(pattern[i][0] + " " + i.ToString());
            patternData.Clear();
        }

        Debug.Log("stage_id : " + stage_id.ToString());
        Debug.Log("author : " + author);
        Debug.Log("difficulty : " + difficulty);
        Debug.Log("level : " + level.ToString());
    }

    private void Start()
    {
        //LitJson.JsonData getData = LitJson.JsonMapper.ToObject(jsonData.text);
        //stage_id = (int)getData["stage_id"];
        //author = getData["author"].ToString();
        //difficulty = getData["difficulty"].ToString();
        //level = (int)getData["level"];

        
    }
}
