using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class UIController : MonoBehaviour
{

    public TMP_Text debugText;

    public static UIController instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        
    }
}
