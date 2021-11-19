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

    [SerializeField]
    HPButton hpButton;

    [SerializeField]
    MPButton mpButton;

    [SerializeField]
    ATKButton atkButton;

    [SerializeField]
    DEFButton defButton;

    [SerializeField]
    AGIButton agiButton;

    [SerializeField]
    BHP bhpButton;

    [SerializeField]
    BMP bmpButton;

    [SerializeField]
    BATK batkButton;

    [SerializeField]
    BDEF bdefButton;

    [SerializeField]
    BAGI bagiButton;

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
            SavePlayerStatus();
            StartCoroutine("WaitForFive");
            int floor = PrefsUtil.GetStageProgress();
            if (floor >= 7)
            {
                SceneManager.LoadScene("Clear");
                return;
            }
            SceneManager.LoadScene("Battle");
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

    private void SavePlayerStatus()
    {
        PrefsUtil.SetPlayerStatus(
            hpButton.status_hp,
            mpButton.status_mp,
            atkButton.status_atk,
            defButton.status_def,
            agiButton.status_agi
        );
    }

    private void SaveBuddyStatus()
    {
        PrefsUtil.SetBuddyStatus(
            bhpButton.status_hp,
            bmpButton.status_mp,
            batkButton.status_atk,
            bdefButton.status_def,
            bagiButton.status_agi
        );
    }
}
