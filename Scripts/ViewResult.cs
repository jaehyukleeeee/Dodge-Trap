using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewResult : MonoBehaviour {

    public Text BestScore;
    public Text MyScore;
    public Text Coin;

    private void OnEnable()
    {
        if(PlayerPrefs.GetInt("best_score") < GamePlayManager.Instance.GetScore())
        {
            PlayerPrefs.SetInt("best_score", (GamePlayManager.Instance.GetScore()));
            Debug.Log("신기록달성!");
        }
        BestScore.text = PlayerPrefs.GetInt("best_score").ToString();
        MyScore.text = GamePlayManager.Instance.GetScore().ToString();
        Coin.text = GamePlayManager.Instance.GetScore().ToString();
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
