using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanban_Hyouji1 : MonoBehaviour
{
        public MessageManager messagemanager; 
    void OnCollisionStay2D(Collision2D collison){

        if(collison.gameObject.name == "Player(仮)"){
        Debug.Log("当たっている");
        }

    
    }
}
