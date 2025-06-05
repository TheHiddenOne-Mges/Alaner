// Alaner Memory Interface - Monitors memory file and sends updates to AlanerCore

using System;
using System.IO;
using UnityEngine;

public class MemoryInterface : MonoBehaviour
{
    public string memoryFilePath = "C:/Alaner/memory.txt";
    private string lastKnownContent = "";

    public AlanerCore alanerCore;

    void Start()
    {
        if (File.Exists(memoryFilePath))
        {
            lastKnownContent = File.ReadAllText(memoryFilePath);
        }

        if (alanerCore == null)
        {
            alanerCore = GetComponent<AlanerCore>();
        }

        InvokeRepeating("CheckForMemoryUpdate", 5f, 10f);
    }

    void CheckForMemoryUpdate()
    {
        if (!File.Exists(memoryFilePath)) return;

        string currentContent = File.ReadAllText(memoryFilePath);

        if (currentContent != lastKnownContent)
        {
            lastKnownContent = currentContent;
            alanerCore.AddMemory("update", currentContent.Trim(), "high");

            if (alanerCore.TryGetComponent(out AlanerAnimator animator))
            {
                animator.TriggerReact();
            }
        }
    }
}