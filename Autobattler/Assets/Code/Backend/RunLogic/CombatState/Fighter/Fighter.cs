using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.MutationsSystem;
using Auttobattler.Backend.RunLogic.ManagementState;
using Auttobattler.Backend.MutationSystem;
using Assets.Code.Backend.RunLogic.CombatState.Controllers.Battlefield;

namespace Auttobattler.Backend.RunLogic.CombatState
{
    public class Fighter
    {
        public Team Team { get => TeamsController.Instance.GetFighterTeam(this); }
        public Position Position { get => Battlefield.Instance.GetFighterPosition(this); }
       
        private readonly Unit unit;
        public Stats Stats { get { return unit.stats; } }
        public List<Mutation> Mutations { get => unit.enabledMutations;  }

        public CombatValues combatValues;

        #region SYSTEMS

        public HealthSystem healthSys;
        public AttackSystem attackSys;
        public DefenseSystem defenseSys;
        public EnergySystem energySys;
        public ChargerSystem ChargerSys;

        #endregion

        public Fighter(Unit unit)
        {
            this.unit = unit;
        }

        public void Refresh()
        {
            ChargerSys.Refresh();
        }
    }

    public class CombatValues
    {
        public CombatValue currentHealth;
        public CombatValue currentVigor;
        public CombatValue currentMana;

        public CombatValues(Unit build)
        {
            currentHealth = new CombatValue(build.stats.GetStatValue(StatsNames.HEALTH));
            currentVigor = new CombatValue(build.stats.GetStatValue(StatsNames.VIGOR));
            currentMana = new CombatValue(build.stats.GetStatValue(StatsNames.MANA));
        }
    }

    public class CombatValue
    {
        private float value;
        public Action<float> onValueChanged;

        public float Value
        {
            get => value;
            set
            {
                this.value = value;
                onValueChanged?.Invoke(this.value);
            }
        }

        public CombatValue(float value)
        {
            this.value = value;
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