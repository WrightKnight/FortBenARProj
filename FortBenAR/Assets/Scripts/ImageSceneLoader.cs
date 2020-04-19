using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageSceneLoader : MonoBehaviour
{
    public string TargetScene;

    //the scene you're going to load
    public string PlayerPrefScene;
    public PictureLibrary activePictureLib;

    public void SceneLoad()
    {
        PlayerPrefs.SetString("PicLibrary", activePictureLib.name);

        //Checks if there was a scene from the last scene to load after this one
        if (PlayerPrefs.GetString("Scene") != "")
        {
            //Sets scene to load to that one, then sets it to blank
            TargetScene = PlayerPrefs.GetString("Scene");
            PlayerPrefs.SetString("Scene", "");
        }

        //Checks to see if a scene is marked to load after targeted scene
        if (PlayerPrefScene != null)
        {
            //Sets the scene to load to that if it's not blank
            PlayerPrefs.SetString("Scene", PlayerPrefScene);
        }

        //loads the scene
        SceneManager.LoadScene(TargetScene);
    }
}