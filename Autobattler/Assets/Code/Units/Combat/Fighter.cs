﻿using System;
using System.Collections.Generic;
using Autobattler.Grid;
using Autobattler.MutationsSystem.Mutations;
using Autobattler.Units.Combat.CombatSystems;
using Autobattler.Units.Management;
using UnityEngine;

namespace Autobattler.Units.Combat
{
    public enum Team
    {
        PLAYER, ENEMY
    }

    public class Fighter
    {
        private readonly Unit unit;
        public CombatValues combatValues;

        public Team Team => Team.PLAYER;
        public Position Position => new Position();

        public Sprite Sprite => unit.sprite;

        public Fighter(Unit unit)
        {
            this.unit = unit;
        }

        public StatsContainer StatsContainer => unit.statsContainer;
        public List<Mutation> Mutations => unit.enabledMutations;

        public void Refresh()
        {
            ChargerSys.Refresh();
        }

        #region SYSTEMS

        public HealthSystem healthSys;
        public AttackSystem attackSys;
        public DefenseSystem defenseSys;
        public EnergySystem energySys;
        public ChargerSystem ChargerSys;

        #endregion
    }

    public class CombatValues
    {
        public CombatValue currentHealth;
        public CombatValue currentMana;
        public CombatValue currentVigor;

        public CombatValues(Unit build)
        {
            currentHealth = new CombatValue(build.statsContainer.GetStatValue(StatsNames.HEALTH));
            currentVigor = new CombatValue(build.statsContainer.GetStatValue(StatsNames.VIGOR));
            currentMana = new CombatValue(build.statsContainer.GetStatValue(StatsNames.MANA));
        }
    }

    public class CombatValue : IValueExpositor
    {
        public Action OnValueChanged { get; set; }
        private float value;

        public CombatValue(float value)
        {
            this.value = value;
        }

        public float Value
        {
            get => value;
            set
            {
                this.value = value;
                OnValueChanged?.Invoke();
            }
        }

        public float Get()
        {
            return value;
        }
    }

    public abstract class CombatSystem
    {
        protected Fighter parent;

        public CombatSystem(Fighter parent)
        {
            this.parent = parent;
        }
    }
}