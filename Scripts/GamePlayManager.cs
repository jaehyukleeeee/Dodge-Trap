using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour {

    public GameObject GameResultPopup;

    public Text ScoreText;
    public Text CoinText;

    public StartFinshController[] StartFinsh = new StartFinshController[2];
    List<int[]> patternDataList = new List<int[]>();
    int[] patternData;
    public int[,] repackPattern;

    public bool isChallenge = false;
    public bool isEditor = false;
    public bool isMain = false;

    int CurPatternCount = 0;

    int a = 0;

    int score = 0;
    int coin = 0;

    #region Singleton Initialize

    private static GamePlayManager sInstance;

    public static GamePlayManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                sInstance = FindObjectOfType(typeof(GamePlayManager)) as GamePlayManager;
                if (sInstance == null)
                {
                    GameObject newGameObject = new GameObject("_GameManager");
                    sInstance = newGameObject.AddComponent<GamePlayManager>();
                }
            }

            return sInstance;
        }
    }

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        if(!isMain)
            patternDataList = LoadJson.Instance.pattern;
    }

    #endregion

    


    // Use this for initialization
    void Start () {
        if (!isEditor && !isMain)
        {
            coin = PlayerPrefs.GetInt("coin");
        }
        //Debug.Log(LoadJson.Instance.pattern[0][0]);
        //Debug.Log(LoadJson.Instance.pattern[1][0]);

        if(!isEditor && !isMain)
        {
            patternData = patternDataList[CurPatternCount];
            StartCoroutine("RefreshPattern");
        }

        UserDataManager.Instance.LoadUserData();

    }
	
	// Update is called once per frame
	void Update () {
        //json데이터를 가변배열로 repacking
        //Debug.Log(repackPattern[0, 0]);
        if(!isEditor && !isMain)
        {
            ScoreText.text = score.ToString();
            CoinText.text = PlayerPrefs.GetInt("coin").ToString();
        }
        
	}

    IEnumerator RefreshPattern()
    {
        while(true)
        {
            patternData = patternDataList[CurPatternCount];
            RepackArray();
            if (patternDataList.Count-1 <= CurPatternCount)
            {
                CurPatternCount = 0;
                Debug.Log("리셋");
            }
            else
            {
                CurPatternCount++;
                Debug.Log("추가");
            }
            
            //Debug.Log(repackPattern[0, 0] + " 앙 ");
            yield return new WaitForSeconds(0.5f);
        }
    }

    void RepackArray()
    {
        switch (LoadJson.Instance.difficulty)
        {
            case "Easy":
                a = 0;
                repackPattern = new int[7, 3];
                if(a <= 21)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            repackPattern[i, j] = patternData[a];
                            a++;
                        }
                    }
                }
                
                break;
            case "Normal":
                a = 0;
                repackPattern = new int[6, 4];
                if (a <= 24)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            repackPattern[i, j] = patternData[a];
                            a++;
                        }
                    }
                }
                break;
            case "Hard":
                a = 0;
                repackPattern = new int[6, 6];
                if (a <= 36)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            repackPattern[i, j] = patternData[a];
                            a++;
                        }
                    }
                }
                break;
        }
    }

    public int PlusScore()
    {
        return score++;
    }

    public void Again()
    {
        StopCoroutine("RefreshPattern");
        CurPatternCount = 0;
        patternData = patternDataList[CurPatternCount];
        StartCoroutine("RefreshPattern");
    }

    public void GameResult()
    {
        StopCoroutine("RefreshPattern");
        GameResultPopup.SetActive(true);
    }

    public int GetScore()
    {
        return score;
    }
}
