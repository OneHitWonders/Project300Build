using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney = 10000;

    void Start()
    {
        Money = startMoney;
    }

}
