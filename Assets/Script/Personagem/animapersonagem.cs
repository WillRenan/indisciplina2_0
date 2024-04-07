using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class animapersonagem : MonoBehaviour {

    public static animapersonagem instance;

    //public int item = 0;

    //Animação 
    public bool face = true;
    public Transform play;
    public float vel = 3f; //velocidade andando
    public float vel1 = 7f;//velocidade correndo
    public float forca = 6f;//foca pulo
    public Rigidbody2D playerRB;
    public int liberapulo = 1;
    public Animator anim;
    public bool vivo = true;
    public int choro = 6;// objetivos  da fase 1
    public AudioSource toque;

    // passa dados
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        play = GetComponent<Transform>(); //pegando o componete de Transform
        playerRB = GetComponent<Rigidbody2D>();// pegando componete do player 
        anim = GetComponent<Animator>(); //pegando o componete de animação,  para trocar as animações
        
    }

    // Update is called once per frame
    void Update()
    {
        //CONDIÇÃO PARA IR PARA A PROXIMA FASE
        if (choro == 0){// se o choro zerar, chama a próxima fase 
            inicial.cenaAtual = 2;
            SceneManager.LoadScene("TutorialFase2");
            passa_dados.chave = 1;
        }

        if (passa_dados.cronometro < 0 ){ //perdendo se zerar o timer
            SceneManager.LoadScene("game_over");// chama a cena  de  game  over 
            
        }







        if (vivo == true)
        {
            if (Input.GetKey(KeyCode.RightArrow) && !face && !Input.GetKey(KeyCode.LeftArrow))
            {
                Flip();

            }
            else if (Input.GetKey(KeyCode.LeftArrow) && face && !Input.GetKey(KeyCode.RightArrow))
            {
                Flip();

            }

        }



        //MOVIMENTO E ANIMAÇÕES DO JOGADOR 
        if (vivo == true)
        {//correndo
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.C) && (liberapulo == 1))
            {

                transform.Translate(new Vector2(vel1 * Time.deltaTime, 0));
                anim.SetBool("Parado", false);
                anim.SetBool("Andar", false);
                anim.SetBool("Correr", true);
              //  anim.SetBool("Pulo ", false);

                print("oi");
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.C) && (liberapulo == 1))
            {
                transform.Translate(new Vector2(-vel1 * Time.deltaTime, 0));
                anim.SetBool("Parado", false);
                anim.SetBool("Andar", false);
                anim.SetBool("Correr", true);
              //  anim.SetBool("Pulo ", false);

             //andando
            }else if (liberapulo == 0 && Input.GetKey(KeyCode.RightArrow)) {
                transform.Translate(new Vector2(7f * Time.deltaTime, 0));
            }
            else if (liberapulo == 0 && Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector2(-7f * Time.deltaTime, 0));
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.C) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.Space))
            {
                transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
                anim.SetBool("Parado", false);
                anim.SetBool("Andar", true);
                anim.SetBool("Correr", false);
            }
            else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.C) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.Space))
            {
                transform.Translate(new Vector2(vel * Time.deltaTime, 0));
                anim.SetBool("Parado", false);
                anim.SetBool("Andar", true);
                anim.SetBool("Correr", false);
            }
        

         //parado 
            else if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && ( liberapulo == 1)  || Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow)
                        || Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.Space)  || Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.Space)

                    )
            {
                anim.SetBool("Parado", true);
                anim.SetBool("Andar", false);
                anim.SetBool("Correr", false);
                anim.SetBool("Pulo", false);

            }
            //PULO CORRENDO PARA A ESQUERDA 

            if (Input.GetKey(KeyCode.Space) && (liberapulo > 0) && Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.C))
            {

                playerRB.AddForce(new Vector2(0, forca), ForceMode2D.Impulse);
                liberapulo = 0;
               anim.SetBool("Parado", false);
                anim.SetBool("Pulo", true);
                anim.SetBool("Andar", false);
                anim.SetBool("Correr", false);

            } //PULLO QUANDO CORRENDO PARA A DIREITA
            else if (Input.GetKey(KeyCode.Space) && (liberapulo > 0) && Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.C))
            {

                playerRB.AddForce(new Vector2(0, forca), ForceMode2D.Impulse);
                liberapulo = 0;
                
                anim.SetBool("Pulo", true);
                anim.SetBool("Correr", false);

            }
            else if (Input.GetKey(KeyCode.Space) && (liberapulo > 0) ) //PULO PARADO 
            {
                playerRB.AddForce(new Vector2(0, forca), ForceMode2D.Impulse);
                liberapulo = 0;
                anim.SetBool("Parado", false);
                anim.SetBool("Pulo", true);
            }
            //pulo andando
           
        }


        
    }
    void Flip() //FAZ O PLAYER VIRAR PARA ESQUERDA OU PARA A DIREITA
    {
        face = !face;
        Vector3 scala = play.localScale;
        scala.x *= -1;
        play.localScale = scala;

    }

    void OnCollisionEnter2D(Collision2D chao)//FAZ ZERAR O PULO E ATIVA A ANIMAÇÃO DE PARADO
    {

        if (chao.gameObject.CompareTag("chao"))
        {
            anim.SetBool("Parado", true);
            anim.SetBool("Pulo", false);
            anim.SetBool("Correr", false);
            anim.SetBool("Andar", false);
            liberapulo = 1;

        }

    }







    //coleta intens, recebe os dados colatos pelo script  de *passa_ dados*

    void OnTriggerEnter2D(Collider2D outro) {
        if (outro.gameObject.CompareTag("cartilha")) {
         
            passa_dados.item++;
            Destroy(outro.gameObject);
                GetComponent<AudioSource>().Play();////////////toca um som quando pega a cartilha ////////////////////////
         
        }else if (outro.gameObject.CompareTag("objetivo") && passa_dados.item> 0){//colidindo com os menininhos da  fase 1 
            //decrementando cartilha
            passa_dados.item--;
            choro--;
            Destroy(outro.gameObject);
            GetComponent<AudioSource>().Play(); // toaca  um  som  quando  atinge o menino chorando na fase 1
        }
        ////////////fase2
        else if (outro.gameObject.CompareTag("objetivo_fase2"))
        {
           

            //GetComponent<AudioSource>().Play(); // playaudio

            Destroy(outro.gameObject);
            passa_dados.cont_fase2--;
            passa_dados.posicaoX = 30f;
            //GetComponent<AudioSource>().Play(); // toaca  um  som  quando  atinge o menino chorando na fase 1
            toque.Play(); //tocar musica
        }
        else if (outro.gameObject.CompareTag("ativa_fase2"))
        {
            passa_dados.chave = 1;
           
            //GetComponent<AudioSource>().Play(); // toaca  um  som  quando  pega uma carinha com raiva
        }


    }



}
