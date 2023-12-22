using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] string newGameLevel = "Level2";
    // [SerializeField] ParticleSystem start;

    public void NewGameButton()
    {
        // start.Play();
        SceneManager.LoadScene(newGameLevel);
    }    
  
}
