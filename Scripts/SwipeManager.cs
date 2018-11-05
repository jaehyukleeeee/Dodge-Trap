using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour {

    public Swipe swipeControls;
    public GameObject player;
    public Vector3 desiredPosition;

    private Animator animator;
    private Rigidbody rigid;

	// Use this for initialization
	void Start () {
        animator = player.GetComponent<Animator>();
        rigid = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        rigid.velocity = Vector3.zero;
        Vector3 jumpVelocity = new Vector3(0, 5f, 0);
        if (swipeControls.SwipeLeft)
        {
            animator.SetTrigger("isMove");
            player.transform.rotation = Quaternion.LookRotation(Vector3.left);
            desiredPosition += Vector3.left;
        }
            
        if (swipeControls.SwipeRight)
        {
            animator.SetTrigger("isMove");
            player.transform.rotation = Quaternion.LookRotation(Vector3.right);
            desiredPosition += Vector3.right;
        }
            
        if (swipeControls.SwipeUp)
        {
            animator.SetTrigger("isMove");
            player.transform.rotation = Quaternion.LookRotation(Vector3.forward);
            desiredPosition += Vector3.forward;
        }
            
        if (swipeControls.SwipeDown)
        {
            animator.SetTrigger("isMove");
            player.transform.rotation = Quaternion.LookRotation(Vector3.back);
            desiredPosition += Vector3.back;
        }

        rigid.AddForce(jumpVelocity, ForceMode.Impulse);
        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 10f * Time.deltaTime);

        if (swipeControls.Tap)
            Debug.Log("Tap");
    }
}
