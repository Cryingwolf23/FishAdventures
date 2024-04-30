using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{


    public void AquariumMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("FishTank mode");
    }

    public void AdventureMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        Debug.Log("Aquarium mode");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
