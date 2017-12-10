using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowingProjectile : MonoBehaviour {
    public Enemy enemyToFollow;
    public float moveSpeed = 15;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (enemyToFollow == null) { Destroy(gameObject); }
        else
        { 
            transform.LookAt(enemyToFollow.transform);
            GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed;
        }
    }
    public void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Enemy>() == enemyToFollow)
        {
            OnHitEnemy();
        }
    }

    protected abstract void OnHitEnemy();

}
