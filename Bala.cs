using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float Velocidad = 10;
    private Rigidbody2D rigidbody;
    private CatPlayer CatplayerController;

    public void SetCatController(CatPlayer CatPlayerController)
    {
        CatplayerController = CatPlayerController;
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        Destroy(this.gameObject, 5);
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(Velocidad, rigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D Other)
    {
        var tag = Other.gameObject.tag;

    }
    private void OnTriggerEnter2D(Collider2D Other)
    {
        var tag = Other.gameObject.tag;
        if (tag == "Enemigo")
        {
            Destroy(this.gameObject);
            Destroy(Other.gameObject);
            CatplayerController.Incrementar_Puntaje(10);
        }

    }
}
