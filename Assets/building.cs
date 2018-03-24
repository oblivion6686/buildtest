using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour {

    public GameObject foundation;
    public GameObject roof;
    public GameObject wall;
    public GameObject slope;

    public GameObject barrel;
    public float fireRate; 
    public int distance;
    bool buildmode;

    public GameObject ammo;

    private float nextFire = 0.0f;


    public int currentbuildable;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("BuildMode"))
        {
            if (buildmode == false)
            {
                buildmode = true;
                Debug.Log("false");
                return;
            }
            else if (buildmode == true)
            {
                buildmode = false;
                Debug.Log("true");
                return;
            }
        }
        if (buildmode == true)
        {
            buildM();
        }
        if(buildmode==false)
        {
            fight();
        }
    }

    void buildM()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            create(currentbuildable);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            cBuild();
        }
        if (Input.GetButtonDown("Fire3"))
        {
            cSize();
        }
    }

    void create(int build)
    {
        if (currentbuildable == 0)
        {
            Debug.Log("you are build Floor");
            Instantiate(foundation, transform.position + transform.forward * distance, transform.rotation);
            return;
        }
        if (currentbuildable == 1)
        {
            Debug.Log("you are build Wall");
            Instantiate(roof, transform.position + transform.forward * distance, transform.rotation);
            return;
        }
        if (currentbuildable == 2)
        {
            Debug.Log("you are build Roof");
            Instantiate(wall, transform.position + transform.forward * distance, transform.rotation);
            return;
        }
        if (currentbuildable == 3)
        {
            Debug.Log("you are buil Foundation");
            Instantiate(slope, transform.position + transform.forward * distance, transform.rotation);
            return;
        }
    }

    void cBuild()
    {
        if (currentbuildable == 0)
        {
            Debug.Log("you are building Floor");
            currentbuildable++;
            return;
        }
        if (currentbuildable == 1)
        {
            Debug.Log("you are building Wall");
            currentbuildable++;
            return;
        }
        if (currentbuildable == 2)
        {
            Debug.Log("you are building Roof");
            currentbuildable++;
            return;
        }
        if (currentbuildable == 3)
        {
            Debug.Log("you are building Foundation");
            currentbuildable = 0;
            return;
        }
    }

    void cSize()
    {
        Debug.Log("change size");
    }

    void fight()
    {
        
        if (Input.GetButtonDown("Fire1") && Time.time > fireRate)
        {
            fire();
        }
    }


    void fire()
    {
        {

            Vector3 barrelpos = barrel.transform.forward; 
            Instantiate(ammo, barrelpos, Quaternion.identity);
            ammo.GetComponent<Rigidbody>().velocity = ammo.transform.forward * 6;
        }
    }
}
