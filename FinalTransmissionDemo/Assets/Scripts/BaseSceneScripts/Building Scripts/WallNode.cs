using UnityEngine;

public class WallNode : MonoBehaviour
{

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;
    public Vector3 positionOffsetRotate;

    [Header("Optional")]
    public GameObject wall;


    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;

        //GameObject wallToBuild = buildManager.GetWallToBuild();
        //wall = (GameObject)Instantiate(wallToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseDown()
    {
        if (!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

        if (wall != null)
        {
            Debug.Log("Can't build here");
            return;
        }

        buildManager.BuildWallOn(this);
        Destroy(gameObject);
    }

    void OnMouseEnter()
    {


        if (!buildManager.CanBuild)
            return;

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}


