using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    private List<DialogOption> dialogOptions;

    public Dialogue()
    {
        dialogOptions = new List<DialogOption>();
    }

    public void AddOption(DialogOption option)
    {
        dialogOptions.Add(option);
    }

    public void StartDialog()
    {
        foreach (var option in dialogOptions)
        {
            
        }
    }

}
