using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System;

public class GameInstance : MonoBehaviour
{

    public Profile UserProfile;
    private string savePath;

    void Start()
    {
        savePath = Application.persistentDataPath + "\\profile.json";
        //copies objects between game scenes
        DontDestroyOnLoad(this);

    }

    public void Save()
    {
        using (StreamWriter sw = new StreamWriter(savePath))
        {
            string json = JsonUtility.ToJson(UserProfile, true);
            sw.Write(json);
        }
    }

    public void Load()
    {
        using (StreamReader sr = new StreamReader(savePath))
        {
            string json = sr.ReadToEnd();
            UserProfile = JsonUtility.FromJson<Profile>(json);

        }

    }

    public void CreateProfile(string username)
    {
        UserProfile = new Profile(username);
        Save();
    }

    public void DeleteProfile()
    {
        if (DoesProfileExist())
        {
            File.Delete(savePath);
        }
    }

    public bool DoesProfileExist()
    {
        return File.Exists(savePath);
    }

    public void Quit()
    {
        Application.Quit();
    }


    public void LoadScene(string name)
    {

        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    [Serializable]
    public class Profile
    {
        public string Username;
        public Profile(string name)
        {
            Username = name;
          
        }
    }

}
