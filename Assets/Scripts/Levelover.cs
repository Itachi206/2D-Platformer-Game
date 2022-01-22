using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelover : MonoBehaviour
{
    private void onTriggerEnter2D(Collision2D collision){
        if(collision.gameObject.GetComponent<PlayerController>() != null){
            Debug.Log("Level is finished");
        }
    }
}
