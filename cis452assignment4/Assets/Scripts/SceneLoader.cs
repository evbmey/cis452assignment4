/*
* Evan Meyer
* SceneLoader.cs
* CIS452 Assignment 3
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }
}


