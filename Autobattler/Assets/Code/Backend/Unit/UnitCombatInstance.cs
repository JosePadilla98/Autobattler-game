using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auttobattler.MutationsSystem;

namespace Auttobattler.Combat
{
    public class UnitCombatInstance
    {
        public Team Team { get => CombatController.Instance.GetFighterTeam(this); }
        public Position Position { get => Battlefield.Instance.GetFighterPosition(this); }
        public CombatValues combatValues;

        private readonly Unit unit;
        public Stats Stats { get { return unit.stats; } }
        public List<Mutation> Mutations { get => unit.enabledMutations;  }

        #region SYSTEMS

        public HealthSystem healthSys;
        public AttackSystem attackSys;
        public DefenseSystem defenseSys;
        public EnergySystem energySys;
        public ChargerSystem ChargerSys;

        #endregion

        public UnitCombatInstance(Unit unit)
        {
           
        }

        public void Refresh()
        {

        }
    }

    public class CombatValues
    {
        public CombatValues(Unit build)
        {
            
        }
    }

    public class CombatValue
    {
        private float value;
        public delegate void ValueChanged(float value);
        public event ValueChanged OnValueChanged;
        public float Value
        {
            get => value;
            set
            {
                this.value = value;
                OnValueChanged?.Invoke(this.value);
            }
        }

        public CombatValue(float value)
        {
            this.value = value;
        }
    }

    #region ATTACK DATA TYPES

   

    #endregion

    public abstract class CombatSystem
    {
        protected UnitCombatInstance parent;

        public CombatSystem(UnitCombatInstance parent)
        {
            this.parent = parent;
        }
    }
}