using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inicial : MonoBehaviour {

    public static int cenaAtual = 1;
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    public void iniciaJogo()
    {
        SceneManager.LoadScene("controles");
        //SceneManager.LoadScene("controles");
    }
    public void IniJogo()// botoes de  game over 
    {

        if (cenaAtual == 1) {
            Time.timeScale = 1f;
            //passa_dados.verificaTimer = 0;//Zera o tempo depois que  uma nova fase é iniciada ou reiniciada ***
            //  passa_dados.chave = 0;//***
            passa_dados.cronometro = 200;
            SceneManager.LoadScene("fase_1");//fase 01
           

        } else if (cenaAtual == 2) {
            Time.timeScale = 1f;
            passa_dados.chave = 1;//***
            passa_dados.verificaTimer = 1;
                        SceneManager.LoadScene("lab_info");//fase 02

        }
    }
    public void Menu() // vai para o menu inicial 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menuInicial");
        //cenaAtual = 1;
    }
    public void Fases() // vai para o menu inicial 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("opcoes_fases");
        //cenaAtual = 1;
    }
    public void Fases1 (){
        Time.timeScale = 1f;
        cenaAtual = 1;
        SceneManager.LoadScene("TutorialFase");
    
    }

    public void Fases2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TutorialFase2");
        cenaAtual = 2;

    }
    public void Fases1_sem_tuto()
    {
        Time.timeScale = 1f;
        //passa_dados.verificaTimer = 1;
        SceneManager.LoadScene("fase_1");
        cenaAtual = 1;

    }
    public void Fases2_sem_tuto()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("lab_info");
        cenaAtual = 2;

    }
}
