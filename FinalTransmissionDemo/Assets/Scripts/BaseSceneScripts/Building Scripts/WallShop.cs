
using UnityEngine;

public class WallShop : MonoBehaviour {

    public WallBlueprint stage1wall;
    public WallBlueprint stage2wall;
    public WallBlueprint stage3wall;

    public BuildingBlueprint tent;


    BuildManager buildManager;

    void Start()
    {
        {
            buildManager = BuildManager.instance;
        }
    }

    public void SelectWallOne ()
    {
        Debug.Log("Wall One Selected");
        buildManager.SelectWallToBuild(stage1wall);
    }

    public void SelectWallTwo()
    {
        Debug.Log("Wall Two Selected");
        buildManager.SelectWallToBuild(stage2wall);

    }

    public void SelectWallThree()
    {
        Debug.Log("Wall Three Selected");
        buildManager.SelectWallToBuild(stage3wall);

    }

    public void SelectTent()
    {
        Debug.Log("Tent Selected");
        buildManager.SelectBuildingToBuild(tent);
    }

}
