using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Dialog;
    public GameObject Kanban1;
    
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //col = Kanban1.GetComponent<BoxCollider2D>();
        while(true)
        {
            
            if(Input.GetKeyUp(KeyCode.Z))
            {   
                Debug.Log("あいう");
                Panel.SetActive(true);
                Dialog.GetComponent<Text>().text = StringClass.Text0;
                StartCoroutine("Wait");
                Panel.SetActive(false);   
                
            }

        break;

        }

    }

private IEnumerator Wait()
{
    yield return new WaitForSeconds(5.0f);
}
}
