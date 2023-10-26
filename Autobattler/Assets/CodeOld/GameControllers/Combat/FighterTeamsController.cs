﻿using AutobattlerOld.ScriptableCollections;
using UnityEngine;

namespace AutobattlerOld.GameControllers.Combat
{
    [CreateAssetMenu(fileName = "TeamsController", menuName = "ScriptableObjects/TeamsController")]
    public class FighterTeamsController : ScriptableObject
    {
        public FightersCollection enemies;
        public FightersCollection playerFighters;

        public void Refresh()
        {
            foreach (var fighter in enemies.Collection)
            {
                fighter.Refresh();
            }

            foreach (var fighter in playerFighters.Collection)
            {
                fighter.Refresh();
            }
        }
    }
}