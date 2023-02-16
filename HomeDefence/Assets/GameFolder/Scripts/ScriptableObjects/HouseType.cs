
using UnityEngine;

[CreateAssetMenu(fileName = "New House Type", menuName = "HouseType" )]
public class HouseType : ScriptableObject
{
    public Color houseColor = Color.white;
    public Vector3 houseScale = Vector3.one;
    public int needMoney2Upgrade;
    public float intervalSpeed = 5f;
    public string houseLevel = "Level 1";
    public float health;

}
