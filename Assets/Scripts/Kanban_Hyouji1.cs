using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanban_Hyouji1 : MonoBehaviour
{
        void OnCollisionStay2D(Collision2D collison){

        if(collison.gameObject.name == "Player"){
        Debug.Log("当たっている");
        }

    
    }
}
