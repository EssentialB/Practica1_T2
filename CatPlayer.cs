using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatPlayer : MonoBehaviour
{
    public float JumpForce = 10;
    public float Velocity = 10;
    public GameObject Bala;
    public Text PuntajeTexto;
    private int puntaje = 0;

    private static readonly string Animator_State = "Estado";
    private static readonly int Animation_Idle = 0;
    private static readonly int Animation_Run = 1;
    private static readonly int Animation_Jump = 2;
    private static readonly int Animation_Slice = 3;
    private static readonly int Rigth = 1;
    private static readonly int Left = -1;

    private SpriteRenderer spriteRenderer;  
    private Rigidbody2D rigidbody; 
    private Animator animator;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        var velocidadActualX = rigidbody.velocity.x;
        var velocidadActualY = rigidbody.velocity.y;

        rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        Change_Animation(Animation_Idle);

       PuntajeTexto.text = "Puntaje: " + puntaje;

        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            Desplazarse(Rigth);
        }

        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            Desplazarse(Left);
        }

        if (Input.GetKey(KeyCode.C))
        {
            Deslizarse();
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            Disparar();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            Change_Animation(Animation_Jump);
        }
    }
    public void Incrementar_Puntaje(int puntos)
    {
        puntaje += puntos;
    }
    private void Disparar()
    {
        var x = this.transform.position.x;
        var y = this.transform.position.y;

        var BalitaGo = Instantiate(Bala, new Vector3(x, y), Quaternion.identity);
        var Controller = BalitaGo.GetComponent<Bala>();
        Controller.SetCatController(this);
        if (spriteRenderer.flipX)
        {

            Controller.Velocidad = Controller.Velocidad * -1;
        }

    }
    
    private void Deslizarse()
    {
        Change_Animation(Animation_Slice);
    }
    private void Desplazarse(int Position)
    {
        rigidbody.velocity = new Vector2(Velocity * Position, rigidbody.velocity.y); 
        spriteRenderer.flipX = Position == Left;
        Change_Animation(Animation_Run);
    }
    private void Change_Animation(int Animation)
    {
        animator.SetInteger(Animator_State, Animation);
    }
}
