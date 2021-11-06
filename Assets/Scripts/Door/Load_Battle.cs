using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Load_Battle : MonoBehaviour
{
    public GameObject Lpanel;
    public GameObject isbattlecheck;
    private AudioSource doorsound;
    void Start()
    {
        Lpanel = GameObject.Find("Canvas/LoadPanel");
        isbattlecheck = GameObject.Find("Canvas/LoadPanel/isbattlecheck");
        Lpanel.SetActive(false);
        doorsound = GetComponent<AudioSource>();
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        Lpanel.SetActive(true);
        isbattlecheck.GetComponent<Text>().text = StringClass.Texts[12];
        if(Input.GetKeyDown(KeyCode.Z))
        {
            doorsound.PlayOneShot(doorsound.clip);
            StartCoroutine("WaitForFive");
            SceneManager.LoadScene("battle");
        }
    }

    void OnCollisionExit2D(Collision2D collide2)
  {
      Lpanel.SetActive(false);
  }

  private IEnumerator WaitForFive()
  {
      yield return new WaitForSeconds(5.0f);
  }
}
