using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIVersion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Version
        gameObject.GetComponent<TextMeshProUGUI>().text = new string ("Forever Homes (Demo)" + "\n" + "Version " + Application.version);
    }
}
