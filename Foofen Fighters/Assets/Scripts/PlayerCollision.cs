using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
 private void OnCollisionEnter2D(Collision2D collision){

    if(collision.gameObject.name == "Opposing_Chef 1")
    {
        Debug.Log("enter");
        
    }
 }
 private void OnCollisionStay2D(Collision2D collision){

    if(collision.gameObject.name == "Opposing_Chef 1")
    {
        Debug.Log("stay");
    }
 }
 private void OnCollisionExit2D(Collision2D collision){

    if(collision.gameObject.name == "Opposing_Chef 1")
    {
        Debug.Log("exit");
    }
 }
}
