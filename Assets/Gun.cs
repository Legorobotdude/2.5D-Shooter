using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    [SerializeField]GameObject bulletGameObject;
    [SerializeField] Transform muzzle;
    [SerializeField] float firingForce = 100f;
    [SerializeField] AudioClip gunShot;
    [SerializeField] float damage = 10f;
    [SerializeField] protected bool semiAutoFire = true;
    [SerializeField] protected bool burstFire = true;
    [SerializeField] protected bool autoFire = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire1"))
        {
            //spawn bullet
            var bullet = Instantiate(bulletGameObject,muzzle.position,muzzle.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(firingForce * bullet.transform.right);
        }
		
	}
}
