using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_over_fase02 : MonoBehaviour {

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


            SceneManager.LoadScene("game_over");
            passa_dados.verificaTimer = 1;
            inicial.cenaAtual = 2;
            passa_dados.posicaoX = 30f;//fase 2
            passa_dados.chave = 1;//fase 2
            passa_dados.cont_fase2 = 0; //fase 2
            passa_dados.cronometro_fase2Time = 100;


        }



    }
}
