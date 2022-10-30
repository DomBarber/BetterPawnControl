﻿using System.Linq;
using HarmonyLib;
using Verse;
using RimWorld;
using System.Collections.Generic;
using System.Diagnostics;

namespace BetterPawnControl
{

    [HarmonyPatch(typeof(FloatMenu), "PostClose")]
    internal static class FloatMenu_PostClose
    {
        private static void Postfix()
        {
            if (Current.ProgramState == ProgramState.Playing)
            {
                //Everytime a float opens, BPC is saved regadless if any related pawns settings tracked by BPC are changed.
                //A better solution could be to Harmonize the exact function where the setting is changed but it is hard to pin-point exactly where it happens. 
                AnimalManager.UpdateState(AnimalManager.links, AnimalManager.Animals().ToList(), AnimalManager.GetActivePolicy());
                ScheduleManager.UpdateState(ScheduleManager.links, ScheduleManager.Colonists().ToList(), ScheduleManager.GetActivePolicy());
                AssignManager.UpdateState(AssignManager.links, AssignManager.Colonists().ToList(), AssignManager.GetActivePolicy());
                MechManager.UpdateState(MechManager.links, MechManager.Mechs().ToList(), MechManager.GetActivePolicy());
            }           
        }
    }
}