using System;
using AutobattlerOld.Grid;
using AutobattlerOld.Units.Combat.CombatSystems;
using AutobattlerOld.Units.Management;
using UnityEngine;

namespace AutobattlerOld.Units.Combat
{
    public enum Team
    {
        PLAYER,
        ENEMY
    }

    public class Fighter
    {
        private readonly Unit unit;
        public CombatValues combatValues;

        public Team Team => Team.PLAYER;
        public Position Position => new Position();
        public String name => unit.name;

        public Sprite Sprite => unit.sprite;

        public Fighter(Unit unit)
        {
            this.unit = unit;
            CreateSystems();
        }

        public StatsContainer StatsContainer => unit.statsContainer;

        public void Refresh()
        {
            basicAttackSys.Refresh();
        }

        /// <summary>
        /// Returns true if the attack is successfully made
        /// </summary>
        /// <param name="damageData"></param>
        /// <returns></returns>
        public bool ReceiveAttack(DamageData damageData)
        {
            defenseSys.ReceiveAttack(damageData);
            return true;
        }

        #region SYSTEMS

        public HealthSystem healthSys;
        public DefenseSystem defenseSys;
        public BasicAttackSystem basicAttackSys;

        private void CreateSystems()
        {
            healthSys = new HealthSystem(this);
            basicAttackSys = new BasicAttackSystem(this);
            defenseSys = new DefenseSystem(this);
        }

        #endregion
    }

    public class CombatValues
    {
        public CombatValue currentHealth;

        public CombatValue basicAttackProgress;

        public CombatValues(Unit build)
        {
            currentHealth = new CombatValue(build.statsContainer.GetStatValue(StatsNames.HEALTH));
            basicAttackProgress = new CombatValue(0f);
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
