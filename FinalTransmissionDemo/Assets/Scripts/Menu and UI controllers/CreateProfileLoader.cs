using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateProfileLoader : MonoBehaviour {

    private GameInstance instance;
    public InputField txtUsername;
    public Button BtnCreate;
    
    private string username;

    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");

        if (gameController != null)
        {
            instance = gameController.GetComponent<GameInstance>();

            if (instance.DoesProfileExist())
            {
                instance.Load();
                SceneManager.LoadScene("mainmenu");
            }
            else
            {

                txtUsername.onValueChanged.AddListener(ValidateTextBox);
                txtUsername.onEndEdit.AddListener(OnUsernameEntered);
                BtnCreate.onClick.AddListener(CreateProfile);

            }
        }
        else
        {
            Debug.Log("game controller has not been added to the scene");
        }
    }


    private void ValidateTextBox(string contents)
    {
        if (!string.IsNullOrEmpty(contents))
        {
            BtnCreate.interactable = true;
        }
        else
            BtnCreate.interactable = false;


    }

    private void OnUsernameEntered(string contents)
    {
        username = contents;
    }

    private void CreateProfile()
    {
        if (!string.IsNullOrEmpty(username))
        {
            instance.CreateProfile(username);
            SceneManager.LoadScene("mainmenu");
        }

    }
}
