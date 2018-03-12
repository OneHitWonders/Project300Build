
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in the scene");
            return;
        }
        instance = this;
    }

    public GameObject stage1wall;// potential problem

    public GameObject stage2wall;

    public GameObject stage3wall;

    public GameObject tent;

    private WallBlueprint wallToBuild;
    private BuildingBlueprint buildingToBuild;

    public bool CanBuild { get { return wallToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= wallToBuild.cost; } }


    public void BuildWallOn(WallNode node)
    {
        if (PlayerStats.Money < wallToBuild.cost)
        {
            Debug.Log("Not enough money to build that");
            return;
        }

        PlayerStats.Money -= wallToBuild.cost;

        GameObject wall = (GameObject)Instantiate(wallToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.wall = wall;

        Debug.Log("Wall Built! Money Remaining: " + PlayerStats.Money);

    }

    public void SelectWallToBuild(WallBlueprint wallBlueprint)
    {
        wallToBuild = wallBlueprint;
    }



    public bool CanBuildBuilding { get { return buildingToBuild != null; } }
    public bool HasMoneyForBuilding { get { return PlayerStats.Money >= buildingToBuild.cost; } }


    public void BuildBuildingOn(BuildingNode node)
    {
        if (PlayerStats.Money < buildingToBuild.cost)
        {
            Debug.Log("Not enough money to build that");
            return;
        }

        PlayerStats.Money -= buildingToBuild.cost;

        GameObject building = (GameObject)Instantiate(buildingToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.building = building;

        Debug.Log("Building Built! Money Remaining: " + PlayerStats.Money);

    }

    public void SelectBuildingToBuild(BuildingBlueprint buildingBlueprint)
    {
        buildingToBuild = buildingBlueprint;
    }
}
