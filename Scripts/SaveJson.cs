using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;

public class SaveJson : MonoBehaviour {

    public Text stageidText;
    public Text authorText;
    public Text difficultyText;

    public MainObjectData mainObject;
    public InnerObjectData innerObject;

    public Canvas defaultSettingUI;
    public Canvas editorUI;

    List<InnerObjectData> pattenList = new List<InnerObjectData>();

    LitJson.JsonData setData;
    MapEditorConfig mapConfig = new MapEditorConfig();

    public MainObjectData createMainObejct(int stageid, string author, string difficulty, int level)
    {
        mainObject.stage_id = stageid;
        mainObject.author = author;
        mainObject.difficulty = difficulty;
        mainObject.level = level;
        return mainObject;
    }

    public InnerObjectData createSubObject(int count, int[] pattern)
    {
        InnerObjectData myInnerObject = new InnerObjectData();
        myInnerObject.patternCount = count;
        myInnerObject.pattern = pattern;
        return myInnerObject;
    }

    #region Singleton Initialize

    private static SaveJson sInstance;

    public static SaveJson Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = FindObjectOfType(typeof(SaveJson)) as SaveJson;
                if (sInstance == null)
                {
                    GameObject newGameObject = new GameObject("_JsonManager");
                    sInstance = newGameObject.AddComponent<SaveJson>();
                }
            }

            return sInstance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    #endregion


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    string CustomJSON(int stageid, string author, string difficulty,int level, int count, int[] pattern)
    {
        string[] patternString = new string[pattern.Length];
        for(int i = 0; i < pattern.Length; i++)
        {
            patternString[i] = pattern[i].ToString();
        }

        string resultPattern = string.Join(",", patternString);

        string defaultSet = "{\"stage_id:\"" + stageid+"}";

        //"\"stage_id: \"" + stageid + ","
            //"\"stage_id: \""
        string result = "{"+ "\"stage_id\":" + stageid + "," + "\"author\":" + "\"" + author + "\"," + "\"difficulty\":" + "\"" + difficulty + "\"," + "\"level\":" + level + "," + "\"pattern\":[{\""+count+"\":["+ resultPattern + "]}]}";
        return result;
    }

    public void DefaultSettingOK()
    {
        mapConfig.stage_id = int.Parse(stageidText.text);
        mapConfig.author = authorText.text;
        mapConfig.difficulty = difficultyText.text;

        //pattenList.Add(createSubObject("0", new int[] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 }));
        //pattenList.Add(createSubObject("1", new int[] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 }));
        //mainObject.pattern = pattenList.ToArray();
        createMainObejct(int.Parse(stageidText.text), authorText.text, difficultyText.text, 1);
        //Debug.Log(CustomJSON(0, new int[] { 1,0,1,0,1,1}));
        setData = LitJson.JsonMapper.ToJson(mainObject);
        Debug.Log(setData);
        //setData = LitJson.JsonMapper.ToJson(mapConfig) + CustomJSON(0, new int[] { 1, 0, 1, 0, 1, 1 });
        //Debug.Log(setData);
        File.WriteAllText(Application.dataPath + "/customSetting.json", setData.ToString());//CustomJSON(mapConfig.stage_id, mapConfig.author, mapConfig.difficulty, mapConfig.level, 0, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));

        Debug.Log(mapConfig.stage_id + " " + mapConfig.author + " " + mapConfig.difficulty);
        defaultSettingUI.gameObject.SetActive(false);
        editorUI.gameObject.SetActive(true);
    }

    public void SavePattern(int count,int[] pattern)
    {
        pattenList.Add(createSubObject(count, (int[])pattern.Clone()));//new int[] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 }));
        //pattenList.Add(createSubObject(count, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
    }

    public void AutoNullMaker(int count)
    {
        pattenList.Add(createSubObject(count, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
    }

    public void SaveJSON()
    {
        //pattenList.Add(createSubObject(0, new int[]{ 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0 }));
        //pattenList.Add(createSubObject(0, new int[]{ 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 }));
        mainObject.pattern = pattenList.ToArray();
        //createMainObejct(101, "Jaehyuk", "Normal", 1);
        setData = LitJson.JsonMapper.ToJson(mainObject);
        Debug.Log(setData);
        File.WriteAllText(Application.dataPath + "/Resources/" + mainObject.stage_id+".json", setData.ToString());
    }
}

public class MapEditorConfig
{
    public int stage_id = 0;
    public int level = 0;
    public string author = null;
    public string difficulty = null;
}

[Serializable]
public class MainObjectData
{
    public int stage_id = 0;
    public string author = "Jaehyuk";
    public string difficulty = "Normal";
    public int level = 0;
    public InnerObjectData[] pattern;
}

[Serializable]
public class InnerObjectData
{
    public int patternCount = 0;
    public int[] pattern;
}
