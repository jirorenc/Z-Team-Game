using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class newtrysound : MonoBehaviour {
    public AudioClip helicopter_gun_sound;
    AudioSource aSource;
    public ParticleSystem helicopter_fire;
    private int a = 0;
	// Use this for initialization
	void Start () {
        aSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (a == 0)
        {
            aSource.Play();
        }
        
        if (a >= 1000)
        {
            aSource.Stop();
            helicopter_fire.Stop();
            
        }
        else
        {
                a++;
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
