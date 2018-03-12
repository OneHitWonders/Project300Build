using UnityEngine;

public class BuildingNode : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;
    public Vector3 positionOffsetRotate;

    [Header("Optional")]
    public GameObject building;

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

        if (building != null)
        {
            Debug.Log("Can't build here");
            return;
        }

        buildManager.BuildBuildingOn(this);
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
