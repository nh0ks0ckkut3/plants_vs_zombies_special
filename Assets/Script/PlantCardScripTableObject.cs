using UnityEngine;

[CreateAssetMenu(menuName ="Cards/Plant Card", fileName ="New Plant Card")]
public class PlantCardScriptTableObject : ScriptableObject
{
    public Texture2D plantIcon;
    public int cost;
    public float cooldown;
}
