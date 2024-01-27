using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Pranks/Item")]
public class PrankItem : ScriptableObject
{
    public int ID;
    public string itemName;
    public string itemDescription;
    public GameObject prefab;
    public Sprite Icon;
}
