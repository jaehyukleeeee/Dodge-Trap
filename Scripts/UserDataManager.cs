using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class UserDataManager : MonoBehaviour {

    #region Singleton Initialize

    private static UserDataManager sInstance;

    public static UserDataManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = FindObjectOfType(typeof(UserDataManager)) as UserDataManager;
                if (sInstance == null)
                {
                    GameObject newGameObject = new GameObject("_UserDataManager");
                    sInstance = newGameObject.AddComponent<UserDataManager>();
                }
            }

            return sInstance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        CoinText = GameObject.FindGameObjectWithTag("Coin");
        ScoreText = GameObject.FindGameObjectWithTag("BestScore");
    }

    #endregion

    public TextAsset UserDataJSON;

    public UserDataObject userData;

    public GameObject CoinText;
    public GameObject ScoreText;

    LitJson.JsonData getData;
    LitJson.JsonData setData;

    #region UserData
    private int best_score = 0;
    private int coin = 0;
    private bool chick = true;
    private bool duck1 = false;
    private bool duck2 = false;
    private bool duck3 = false;
    private bool goat1 = false;
    private bool goat2 = false;
    private bool hen1 = false;
    private bool hen2 = false;
    private bool hen3 = false;
    private bool rabbit1 = false;
    private bool rabbit2 = false;
    private bool sheep1 = false;
    private bool sheep2 = false;
    #endregion

    public UserDataObject createUserDataObejct()
    {
        userData.best_score = 0;
        userData.coin = 0;
        userData.chick = true;
        userData.duck1 = false;
        userData.duck2 = false;
        userData.duck3 = false;
        userData.goat1 = false;
        userData.goat2 = false;
        userData.hen1 = false;
        userData.hen2 = false;
        userData.hen3 = false;
        userData.rabbit1 = false;
        userData.rabbit2 = false;
        userData.sheep1 = false;
        userData.sheep2 = false;
        return userData;
    }

    #region JSON SET METHODS

    UserDataObject SetBestScore(int bs)
    {
        userData.best_score = bs;
        return userData;
    }

    UserDataObject SetCoin(int coin)
    {
        userData.coin = coin;
        Debug.Log(userData.coin);
        return userData;
    }

    UserDataObject SetChick(bool get)
    {
        userData.chick = get;
        return userData;
    }

    UserDataObject SetDuck1(bool get)
    {
        userData.duck1 = get;
        return userData;
    }

    UserDataObject SetDuck2(bool get)
    {
        userData.duck2 = get;
        return userData;
    }

    UserDataObject SetDuck3(bool get)
    {
        userData.duck3 = get;
        return userData;
    }

    UserDataObject SetGoat1(bool get)
    {
        userData.goat1 = get;
        return userData;
    }

    UserDataObject SetGoat2(bool get)
    {
        userData.goat2 = get;
        return userData;
    }

    UserDataObject SetHen1(bool get)
    {
        userData.hen1 = get;
        return userData;
    }

    UserDataObject SetHen2(bool get)
    {
        userData.hen2 = get;
        return userData;
    }

    UserDataObject SetHen3(bool get)
    {
        userData.hen3 = get;
        return userData;
    }

    UserDataObject SetRabbit1(bool get)
    {
        userData.rabbit1 = get;
        return userData;
    }

    UserDataObject SetRabbit2(bool get)
    {
        userData.rabbit2 = get;
        return userData;
    }

    UserDataObject SetSheep1(bool get)
    {
        userData.sheep1 = get;
        return userData;
    }

    UserDataObject SetSheep12(bool get)
    {
        userData.sheep2 = get;
        return userData;
    }

    #endregion

    public void OneCoin()
    {
        coin++;
        SetCoin(coin);
        SaveUserDataJSON();
    }

    public void BestScore(int score)
    {
        SetBestScore(score);
        SaveUserDataJSON();
    }

    public int GetCoin()
    {
        return coin;
    }

    public int GetBestScore()
    {
        return best_score;
    }

    [ContextMenu("Create User Save Data")]
    public void CreateSavaData()
    {
        createUserDataObejct();
       
        setData = LitJson.JsonMapper.ToJson(userData);
        Debug.Log(setData);

        File.WriteAllText(Application.dataPath + "/Resources/userData.json", setData.ToString());
    }

    public void LoadUserDataJSON()
    {
        getData = LitJson.JsonMapper.ToObject(UserDataJSON.text);
        best_score = (int)getData["best_score"];
        coin = (int)getData["coin"];
        chick = (bool)getData["chick"];
        duck1 = (bool)getData["duck1"];
        duck2 = (bool)getData["duck2"];
        duck3 = (bool)getData["duck3"];
        goat1 = (bool)getData["goat1"];
        goat2 = (bool)getData["goat2"];
        hen1 = (bool)getData["hen1"];
        hen2 = (bool)getData["hen2"];
        hen3 = (bool)getData["hen3"];
        rabbit1 = (bool)getData["rabbit1"];
        rabbit2 = (bool)getData["rabbit2"];
        sheep1 = (bool)getData["sheep1"];
        sheep2 = (bool)getData["sheep2"];
    }

    public void SaveUserDataJSON()
    {
        setData = LitJson.JsonMapper.ToJson(userData);
        Debug.Log(setData);
        File.WriteAllText(Application.dataPath + "/Resources/userData.json", setData.ToString());
    }

    public void LoadUserData()
    {
        best_score = PlayerPrefs.GetInt("best_score");
        coin = PlayerPrefs.GetInt("coin");
        chick = UserDataManager.GetBool("chick");
        duck1 = UserDataManager.GetBool("duck1");
        duck2 = UserDataManager.GetBool("duck2");
        duck3 = UserDataManager.GetBool("duck3");
        goat1 = UserDataManager.GetBool("goat1");
        goat2 = UserDataManager.GetBool("goat2");
        hen1 = UserDataManager.GetBool("hen1");
        hen2 = UserDataManager.GetBool("hen2");
        hen3 = UserDataManager.GetBool("hen3");
        rabbit1 = UserDataManager.GetBool("rabbit1");
        rabbit2 = UserDataManager.GetBool("rabbit2");
        sheep1 = UserDataManager.GetBool("sheep1");
        sheep2 = UserDataManager.GetBool("sheep2");
    }

    // Use this for initialization
    void Start () {
        /*UserDataJSON = Resources.Load("userData") as TextAsset;
        LoadUserDataJSON();
        if (GamePlayManager.Instance.isMain)
        {
            CoinText.text = coin.ToString();
            ScoreText.text = best_score.ToString();
        }*/
        LoadUserData();
        Debug.Log(best_score);
        Debug.Log(chick);
    }
	
	// Update is called once per frame
	void Update () {
        /*
        LoadUserDataJSON();
        */

        try
        {
            if (GamePlayManager.Instance.isMain)
            {
                CoinText.transform.GetChild(0).GetComponent<Text>().text = coin.ToString();
                ScoreText.transform.GetChild(0).GetComponent<Text>().text = best_score.ToString();
            }
        }
        catch(MissingReferenceException)
        {
            CoinText = GameObject.FindGameObjectWithTag("Coin");
            ScoreText = GameObject.FindGameObjectWithTag("BestScore");
        }


        
    }

    public static void SetBool(string key, bool state)
    {
        PlayerPrefs.SetInt(key, state ? 1 : 0);
    }

    public static bool GetBool(string key)
    {
        int value = PlayerPrefs.GetInt(key);

        if(value == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

[Serializable]
public class UserDataObject
{
    public int best_score = 0;
    public int coin = 0;
    public bool chick = true;
    public bool duck1 = false;
    public bool duck2 = false;
    public bool duck3 = false;
    public bool goat1 = false;
    public bool goat2 = false;
    public bool hen1 = false;
    public bool hen2 = false;
    public bool hen3 = false;
    public bool rabbit1 = false;
    public bool rabbit2 = false;
    public bool sheep1 = false;
    public bool sheep2 = false;
}
