using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SurvivorController : MonoBehaviour {

    static Animator anim;
    public LinkedList<GameObject> listOfSurvivors = new LinkedList<GameObject>();
    public GameObject selectedSurvivor;
    private SurvivorMovement selectedMotor; // Used to move the current select
    private Survivor SurvivorDetails;
    private string IsWalking;
    private bool PlayerAlive;
    private GameOverScript gOver;


    private GameObject MainSurvivor;


    public List<GameObject> searchingSurvivors = new List<GameObject>();
    [SerializeField]
    private GameObject spawnPoint;

    //for minimap
    [SerializeField]
    private Camera minimapCamera;

    private Quaternion screenMovementSpace;
    private Vector3 screenMovementForward;
    private Vector3 screenMovementRight;
    private string Axis_Y = "Vertical";
    private string Axis_X = "Horizontal";


    //UI elements
    public Image selectSurvivorImage;
    public Text selectSurvivorName;
    public Text selectSurvivorHealth;
    public Text selectSurvivorStaminia;
    public Text selectSurvivorAccuracy;



    // Use this for initialization
    void Awake () {
        //DontDestroyOnLoad(gameObject);

    
    }

    void Start()
    {
        gOver = gameObject.GetComponent<GameOverScript>();

        anim = GetComponent<Animator>();

        // will rotate in relation to the camera's y axis, used to rotate player
        screenMovementSpace = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

        //Moving forwards or backwards on the z axis
       
        screenMovementForward = screenMovementSpace * Vector3.forward;
      

        //moving left or right on the x axis
        screenMovementRight = screenMovementSpace * Vector3.right;

 



        //sets minimap Camera
        minimapCamera = GameObject.FindGameObjectWithTag("MinimapCamera").GetComponent<Camera>();


        selectSurvivorName = GameObject.Find("SurvivorName").GetComponent<Text>();
        selectSurvivorHealth = GameObject.Find("SurvivorHealth").GetComponent<Text>();
        selectSurvivorStaminia = GameObject.Find("SurvivorStamina").GetComponent<Text>();
        selectSurvivorAccuracy = GameObject.Find("SurvivorAccuracy").GetComponent<Text>();

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Survivor"))
        {
            AddSurvivor(item);
            if (selectedSurvivor == null)
            {
                selectedSurvivor = item;

                selectedMotor = selectedSurvivor.GetComponent<SurvivorMovement>();
                SurvivorDetails = selectedSurvivor.GetComponent<Survivor>();
                selectedSurvivor.GetComponent<SurvivorMovement>().isSelected = true;
                Debug.Log("select");
                UpdateUIInfo();
            }

        }

     


    }


    // Update is called once per frame
    void Update () {
       
        //for testing to ensure survivors are added to list
        if (Input.GetKeyDown(KeyCode.K))
        {
            foreach (GameObject go in listOfSurvivors)
            {
                Debug.Log(go.name);
            }
        }
   


        //MouseClick For selecting Survivor
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit, 1000))
            {
                if (hit.collider.tag == "Survivor")
                {
                    selectedSurvivor = hit.transform.gameObject; // gets the hit Gameobject and sets as selected
                    selectedMotor = selectedSurvivor.GetComponent<SurvivorMovement>();
                    SurvivorDetails = selectedSurvivor.GetComponent<Survivor>();

                    selectedSurvivor.GetComponent<SurvivorMovement>().isSelected = true;
                    Debug.Log("select");
                    UpdateUIInfo();
                    
                }
            }
        }


        if (selectedSurvivor != null)
        {
            selectedMotor.movementDirection = Input.GetAxis("Horizontal") * screenMovementRight
                + Input.GetAxis("Vertical") * screenMovementForward;


            minimapCamera.transform.position =
                new Vector3(selectedSurvivor.transform.position.x,
                100,
                selectedSurvivor.transform.position.z);

            //if (Input.GetAxis(Axis_X) != 0 || Input.GetAxis(Axis_Y) != 0)
            //{
            //    anim.SetBool("IsWalking", true);
            //}
            //else
            //{
            //    anim.SetBool("IsWalking", false);

            //}


        }
      


    }

    private void FixedUpdate()
    {
        if (selectedSurvivor != null)
        {
            UpdateUIInfo();
            if (SurvivorDetails.Health <=0)
            {
                gOver.OnPlayerDeath();
            }
        }
    }

    public void UpdateUIInfo()
    {
     
      selectSurvivorName.text = "Name: " + SurvivorDetails.SurvivorName;
      selectSurvivorHealth.text = "Health: " + SurvivorDetails.Health.ToString();
      selectSurvivorStaminia.text = "Stamina: " + SurvivorDetails.Stamina.ToString();
      selectSurvivorAccuracy.text = "Accuracy: " + SurvivorDetails.Accuracy.ToString();


}

    public void UpdateCameraAngle()
    {
        // will rotate in relation to the camera's y axis, used to rotate player
        screenMovementSpace = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

        //Moving forwards or backwards on the z axis

        screenMovementForward = screenMovementSpace * Vector3.forward;


        //moving left or right on the x axis
        screenMovementRight = screenMovementSpace * Vector3.right;

    }



    
    public void AddSurvivor(GameObject survivorToAdd)
    {
        listOfSurvivors.AddLast(survivorToAdd);

        //Adjust UI and Data
    }

    public void RemoveSurvivor(GameObject survivorToRemove)
    {
        listOfSurvivors.Remove(survivorToRemove);

        //adjust Ui and Data
    }

  

    public void GAMEOVER()
    {

    }
 
}//end class
