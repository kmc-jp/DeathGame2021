using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entry_NewGame : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("New Game");
    }

}
