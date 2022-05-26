﻿using System;
using System.Collections.Generic;
using Autobattler.Grid;
using Autobattler.MutationsSystem.Mutations;
using UnityEngine;

namespace Autobattler.Units
{
    public enum Team
    {
        PLAYER, ENEMY
    }

    public class Fighter
    {
        private readonly _Unit unit;
        public CombatValues combatValues;

        public Team Team => Team.PLAYER;
        public Position Position => new Position();

        public Sprite Sprite => unit.sprite;

        public Fighter(_Unit unit)
        {
            this.unit = unit;
        }

        public Stats Stats => unit.stats;
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

        public CombatValues(_Unit build)
        {
            currentHealth = new CombatValue(build.stats.GetStatValue(StatsNames.HEALTH));
            currentVigor = new CombatValue(build.stats.GetStatValue(StatsNames.VIGOR));
            currentMana = new CombatValue(build.stats.GetStatValue(StatsNames.MANA));
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