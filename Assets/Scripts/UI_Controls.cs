using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Controls : MonoBehaviour
{

     public GameObject SimElements;
     
     public Slider SimSpeed;

    public TMP_InputField Beetles_Amount;
    public TMP_InputField Bushes_Amount;
    public TMP_InputField Foods_Amount;


    public int startBeetles;
    public int startBushes;
    public int startFoods;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //PlayerPrefs.SetInt("Beetles", 10);
        //PlayerPrefs.SetInt("Bushes", 25);
        //PlayerPrefs.SetInt("Foods", 3);
        Beetles_Amount.text = PlayerPrefs.GetInt("Beetles").ToString();
        Bushes_Amount.text = PlayerPrefs.GetInt("Bushes").ToString();
    }



    public void pause()
    {
        Time.timeScale = 0f;
    }

    public void resume()
    {
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Beetle_Plains");
        

    }

    public void Start_Sim()
    {
        
        SimElements.SetActive(true);
        
    }

    public void Speed()
    {
        Time.timeScale = SimSpeed.value;
    }

    public int StartBeetles()
    {

        startBeetles = PlayerPrefs.GetInt("Beetles");
        return startBeetles;
    }

    public int StartBush()
    {
        startBushes = PlayerPrefs.GetInt("Bushes");
        return startBushes;
    }

    public int StartFoods() 
    {
        startFoods = PlayerPrefs.GetInt("Foods");
        return startFoods;
    }

    public void SaveValues()
    {
       PlayerPrefs.SetInt("Beetles",int.Parse(Beetles_Amount.text));
       PlayerPrefs.SetInt("Bushes", int.Parse(Bushes_Amount.text));
       PlayerPrefs.SetInt("Foods", int.Parse(Foods_Amount.text));
    }
}
