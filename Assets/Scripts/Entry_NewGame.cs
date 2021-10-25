using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entry_NewGame : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision){
        StartCoroutine("Change");
        SceneManager.LoadScene("New Game");
    }

    private IEnumerator Change()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
