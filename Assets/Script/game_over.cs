using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_over : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {

            passa_dados.verificaTimer = 0;
            inicial.cenaAtual = 1;
            passa_dados.item = 0;
            SceneManager.LoadScene("game_over");
            

            
        }



    }
}
