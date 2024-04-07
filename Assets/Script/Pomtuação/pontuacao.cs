using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pontuacao : MonoBehaviour {

    public Text txtCartilha;
    public Text timerTxt;
  
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        txtCartilha.text = passa_dados.item.ToString();
        timerTxt.text = passa_dados.cronometro.ToString("f0");
     
    }
}
