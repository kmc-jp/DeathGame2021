using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entry_Option : MonoBehaviour
{
   void OnCollisionEnter2D(Collision2D collision)
   {
        FadeManager.Instance.LoadScene("Option", 1.0f);
   }
}
