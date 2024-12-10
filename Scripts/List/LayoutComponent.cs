using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutComponent : MonoBehaviour
{
    [Header("strength"), Tooltip("zelda related")]
    public string data1;
    public string data2;
    public string data3;
    [Header("wisdom")]
    public string data4;
    public string data5;
    [Header("courage")]
    public string data6;
   [Header("Power"), Range(0.1f,5f)]
    public float data7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    ///  요약해주는 기능
    /// </summary>
    void Summary()
    {
        
    }
}
