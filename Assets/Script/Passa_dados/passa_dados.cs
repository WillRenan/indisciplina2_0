using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using System.Collections;



public class passa_dados : MonoBehaviour{

    public static passa_dados instance;
    //cartilhar fase 1

    ////////////////fase2 //////////////////////
    public static int cont_fase2 = 0;
    public float aleatorio;
    public static float regressivo;
    public static int chave = 0;
    public static float cronometro_fase2Time;
    public static float cronometro_fase2;
    public static float posicaoX = 30f; //posiçãop das carinha que aparecerão na tala
    public static float posicaoY1 = 0.32f;
    public static float posicaoY2 = 1.54f;
    public int posicaoXY = 0;
    public GameObject objeto_fase2;
    //public  AudioSource toque;
    ////////////////fase1////////////////////
    public static int item = 0;
    public static float cronometro; //cronometro
    public static int verificaTimer = 0;//verifica se o tempo da fase foi exedido
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);// nao destroi o script durando o jogo
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        cont_fase2 = 0;
        cronometro = 200;
        cronometro_fase2 = 3;
        cronometro_fase2Time = 100;
        regressivo = 5;
    }
    void Update()
    {
        if (chave == 1 ) { // valida o cronometro usado na  fase 02
            print("YYYYYYYY!");
            cronometro_fase2Time -= Time.deltaTime;
        }

        if ( chave == 0  &&  verificaTimer == 0) // valida o cronometro usado na fase 01
        {
            print("XXXXXXXXX!");
            cronometro -= Time.deltaTime;// pega os segundos, nesse caso esta decrementando a variável cronometro
            
        }
        else if (verificaTimer == 1)
        {
            cronometro = 200;
        }

        ////////////fase 2  random.range() gerar aleatoriamente  os carinha da fase 2

        cronometro_fase2 -= Time.deltaTime;//fase 2, decremeta o tempo

        if (chave == 1 && cont_fase2 < 20)// gera somente 20 carinhas
        {
            if (posicaoXY == 0)// alterna a posicap Y da carinha para cima
            {
                if (cronometro_fase2 <= 0)// se o tempo da carinha zerar, cria - se um nova
                {
                    aleatorio = Random.Range(3, 10);// gera numeros aleatorios
                    Instantiate(objeto_fase2, new Vector3((aleatorio * 10), posicaoY2, 100.0f), Quaternion.identity); // cria a carinha com raiva na fase 2 
                    cont_fase2++;// fase 2, conta quantas carianha  ja foram criadas 
                    print(cont_fase2);//printa no console
                    cronometro_fase2 = 2;// muda o tempo  para 3 segundos
                    posicaoXY = 1;
                }
            }
            else if (posicaoXY == 1)// alterna a posicap Y da carinha para baixo
            {
                if (cronometro_fase2 <= 0)// se o tempo da carinha zerar, cria - se um nova
                {
                    aleatorio = Random.Range(3, 10);// gera numeros aleatorios
                    Instantiate(objeto_fase2, new Vector3((aleatorio * 10), posicaoY1, 100.0f), Quaternion.identity); // cria a carinha com raiva na fase 2 
                    cont_fase2++;// fase 2, conta quantas carianha  ja foram criadas 
                    print(cont_fase2);//printa no console
                    cronometro_fase2 = 2;// muda o tempo  para 3 segundos
                    posicaoXY = 0;

                }
            }
        }


        // condições para o game over 
        if (cont_fase2 < 10)
        {
            regressivo = 10;
        }

        if (cont_fase2 > 10)
        {
            
            regressivo -= Time.deltaTime;
          
        }
      




    }
}
