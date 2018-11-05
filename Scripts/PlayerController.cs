using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public VirtualJoystick joystick;
    public float speed = 1.0f;
    private Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        //Move();
    }

    void Move()
    {
        float h = joystick.GetHorizontalValue();
        float v = joystick.GetVerticalValue();

        transform.Translate(h * Vector3.right * speed * Time.deltaTime);
        transform.Translate(v * Vector3.forward * speed * Time.deltaTime);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bomb")
        {
            Debug.Log("아야!트리거엔터");
            SceneManager.LoadScene(0);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            Debug.Log("아야!트리거스테이");
            SceneManager.LoadScene(0);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "poop")
        {
            //other.gameObject.SetActive(false);
            if(!GamePlayManager.Instance.isMain)
            {
                GamePlayManager.Instance.GameResult();
                //SceneManager.LoadScene(1);
            }
            else
            {
                Rigidbody rigdbody = transform.GetComponent<Rigidbody>();
                rigdbody.AddForce(Vector3.up * 9.0f, ForceMode.Impulse);
            }
            
        }
        if (other.gameObject.tag == "Block")
        {
            animator.SetBool("isGround", true);
        }
        if(other.gameObject.tag == "Finish")
        {
            GamePlayManager.Instance.StartFinsh[0].ChangeRows();
            GamePlayManager.Instance.StartFinsh[1].ChangeRows();
            Debug.Log("1점추가");
            Debug.Log(other.transform.parent.name+", "+other.gameObject.name);
            GamePlayManager.Instance.PlusScore();
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 1);
            if(GamePlayManager.Instance.isChallenge)
            {
                LoadJson.Instance.GetJsonFileAll();
            }
            else
            {
                GamePlayManager.Instance.GameResult();
            }

            if(transform.rotation.y == 0)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.back);
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(Vector3.forward);
            }
            
            

            GamePlayManager.Instance.Again();
        }
    }
}
