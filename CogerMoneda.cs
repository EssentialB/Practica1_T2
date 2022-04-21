using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CogerMoneda : MonoBehaviour
{
    private CatPlayer CatplayerController;

    public void SetCatController(CatPlayer CatPlayerController)
    {
        CatplayerController = CatPlayerController; 
    }
    private void OnTrigger2D(Collider2D Other)
    {
        {
            var tag = Other.gameObject.tag;
            if (tag == "Plata")
            {
                Destroy(this.gameObject);
                CatplayerController.Incrementar_Puntaje(10);
            }

        }
    }
}
