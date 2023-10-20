using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    private List<DialogOption> dialogOptions;
    private Player player;
    public List<IObserver> Observers { get; set; }

    private GameManager()
    {
        dialogOptions = new List<DialogOption>();
        player = new Player();
        Observers = new List<IObserver>();
    }

    public void AddDialogOption(DialogOption option)
    {
        dialogOptions.Add(option);
    }

    public void CreatePlayer(string name, int strength, int dexterity)
    {
        player.Name = name;
        player.Strength = strength;
        player.Dexterity = dexterity;
        player.Health = 100 - strength - dexterity;
    }

    public void SelectOption(int optionIndex)
    {
        DialogOption selectedOption = dialogOptions[optionIndex];
        if (selectedOption.RequiredStrength <= player.Strength &&
            selectedOption.RequiredDexterity <= player.Dexterity)
        {
            player.Health += selectedOption.HealthChange;
            selectedOption.Action?.Invoke(player);
            NotifyObservers();
        }
        else
        {
            // Handle option requirements not met
        }
    }

    private void NotifyObservers()
    {
        foreach (var observer in Observers)
        {
            observer.OnNotify();
        }
    }

}
