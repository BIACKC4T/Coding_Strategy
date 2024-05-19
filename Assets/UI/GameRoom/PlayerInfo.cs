using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInfo : MonoBehaviour
{
    public TMP_Text Name;
    public TMP_Text ReadyState;
    public void setName(string name)
    {
        Name.SetText(name);
    }

    public void setReady(bool ready)
    {
        if(ready == true)
        {
            ReadyState.SetText("�غ� �Ϸ�");
        }
        else
        {
            ReadyState.SetText("�غ� ��");
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
