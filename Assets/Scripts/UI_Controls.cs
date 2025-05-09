using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controls : MonoBehaviour
{

    [SerializeField] public GameObject UIelements;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    }
}
