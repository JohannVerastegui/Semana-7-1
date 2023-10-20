using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOption : MonoBehaviour
{
    public string Text { get; set; }
    public int RequiredStrength { get; set; }
    public int RequiredDexterity { get; set; }
    public int HealthChange { get; set; }
    public Action<Player> Action { get; set; }
}
