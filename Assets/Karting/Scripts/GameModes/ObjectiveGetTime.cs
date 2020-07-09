﻿using System.Collections;
using UnityEngine;

public class ObjectiveGetTime : Objective
{
    [Tooltip("If MustCollectAllPickups is false, this is the amount of pickups required")]
    public int pickupsToCompleteObjective = 2;

    IEnumerator Start()
    {
   
        TimeManager.OnSetTime(totalTimeInSecs, isTimed, gameMode);
        
        yield return new WaitForEndOfFrame();

        title = "Pass the rings to get more time";
        
        Register();
    }
    
    // Check every time the player pass through a checkpoint
    protected override void ReachCheckpoint(int remaining)
    {
        if (isCompleted)
            return;
        
        // Reduces the minimum quantity of timer objects required to complete the track
        pickupsToCompleteObjective -= remaining;

        // Check if the minimum quantity of timer objects was collected before crossing the finish line
        if (remaining == 0 && pickupsToCompleteObjective <= 0)
        {
            CompleteObjective(string.Empty, GetUpdatedCounterAmount(),
                "Objective complete: " + title);
        }
    }

    public override string GetUpdatedCounterAmount()
    {
        return m_PickupTotal + " / " + pickupsToCompleteObjective;
    }
    
}
