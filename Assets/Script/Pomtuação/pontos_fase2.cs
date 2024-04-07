using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class pontos_fase2 : MonoBehaviour {

    public Text pontosFase2Txt;
    public Text timeFase2Txt;
    public Text regressivoFase2Txt;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        pontosFase2Txt.text = passa_dados.cont_fase2.ToString("f0");
        timeFase2Txt.text = passa_dados.cronometro_fase2Time.ToString("f0");

        if (passa_dados.cont_fase2 > 10) // mostra na tela o tempo restante para ele pegar as carinhas e fica abaixo de 10
        {
            regressivoFase2Txt.text = passa_dados.regressivo.ToString("f0");
        } else if (passa_dados.cont_fase2 < 10)
        {
            regressivoFase2Txt.text = " ";
        }

        //condiç]ão de vitoria da fase 2 
        if (passa_dados.cont_fase2 < 10 && passa_dados.cronometro_fase2Time < 0) {

            SceneManager.LoadScene("MenuGanhou");

        }
     
        if (passa_dados.regressivo < 0)
        {
            inicial.cenaAtual = 2;
            SceneManager.LoadScene("game_over");
            print("PERDEU!");
        }


    }
}
