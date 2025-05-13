using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using System.IO;
using System;

public class Display_Counter : MonoBehaviour
{
    [SerializeField] private float updateTime = 10f;

    private int Beetles_Amount;
    private GameObject[] Beetles;  
    List<GameObject> allBeetles = new List<GameObject>();

    List<GameObject> aliveBeetle = new List<GameObject>();

    public TextMeshProUGUI total_Beetles;
    public TextMeshProUGUI avg_Speed;
    public TextMeshProUGUI avg_Range;

    private Beetle_Stats Beetle_Stats;

    private float speed;
    private float avgSpeed;

    private float range;
    private float avgRange;

    private string filename = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnEnable()
    {
        Application.logMessageReceived += Log;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= Log;
    }

    private void Log(string logString, string stackTrace, LogType type)
    {
        TextWriter tw = new StreamWriter(filename, true);
        tw.WriteLine("[" + System.DateTime.Now + "]" + logString);
        tw.Close();
    }

    void Start()
    {
        StartCoroutine(Display());
        filename = Application.dataPath + "/Logfile.txt";
    }

    IEnumerator Display()
    {
        
        yield return new WaitForSeconds(updateTime);
        speed = 0;
        range = 0;
        Beetles = GameObject.FindGameObjectsWithTag("Beetle");
        allBeetles = Beetles.ToList();
        for (int i = 0; i < allBeetles.Count; i++)
        {
            if (allBeetles[i] == null)
            {
                allBeetles.RemoveAt(i);
            }
           
            Beetle_Stats = allBeetles[i].GetComponent<Beetle_Stats>();
            speed = speed + Beetle_Stats.speed;
            range = range + Beetle_Stats.detectRange;
        }
        avgSpeed = speed / allBeetles.Count;
        avgRange = range / allBeetles.Count;
        avg_Speed.text = "|Average Speed: |" + (avgSpeed).ToString();
        avg_Range.text = "|Average Range: |" + (avgRange).ToString();
        total_Beetles.text = "|Total Beetles: |" + allBeetles.Count.ToString();
        //Debug.Log(total_Beetles.text + avg_Speed.text + avg_Range.text);
        StartCoroutine(Display());
    }
}
