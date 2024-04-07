using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_teste : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ( passa_dados.cont_fase2 > 10)
        {

            GetComponent< AudioSource >().Play();

        }

    }
}
