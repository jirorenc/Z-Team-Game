using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class newmslbomb : MonoBehaviour {
    public ParticleSystem bomb;
    public ParticleSystem gun_efect;
    public GameObject misille;
    public GameObject soldier;
    public GameObject su_soldiers;
    private float misl_y, misl_z;
    public int a=0;
	// Use this for initialization
	void Start () {
        misl_y = misille.transform.position.y;
        misl_z = misille.transform.position.z;
        bomb.Pause();
        soldier.SetActive(false);
	}
	    
	// Update is called once per frame
	void Update () {
        
             Debug.Log(a);
        if (405==a)
        {
            bomb.Play();
            su_soldiers.SetActive(false);
            a++;
        } 
        else if (a == 505)
        {
            soldier.SetActive(true);
        }
        else if (a<506)
        {
          StartSingleOperation();
          if (a % 10 == 0)
          {
              gun_efect.Play();
          }
        }
       
       
    }
    public void StartSingleOperation()
    {
        Thread thread = new Thread(new ThreadStart(work1));
        thread.Start();
    }

    private void work1()
    {
        Thread.Sleep(100);
        a++;
    }
}
