using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(GamePlayManager.Instance.isMain)
        {
            animator.SetBool("isMain", true);
        }
        else
        {
            animator.SetBool("isMain", false);
        }
		
	}
}
