using System;
using System.Collections.Generic;
using Autobattler.Grid;
using Autobattler.MutationsSystem.Mutations;
using Autobattler.Unit.Fighter.CombatSystems;
using Autobattler.Unit.Unit;

namespace Autobattler.Unit.Fighter
{
    public class Fighter
    {
        private readonly Unit.Unit unit;

        public CombatValues combatValues;

        public Fighter(Unit.Unit unit)
        {
            this.unit = unit;
        }

        public Team Team => TeamsController.Instance.GetFighterTeam(this);
        public Position Position => App.GetBattlefield().GetItemPosition(this);
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

        public CombatValues(Unit.Unit build)
        {
            currentHealth = new CombatValue(build.stats.GetStatValue(StatsNames.HEALTH));
            currentVigor = new CombatValue(build.stats.GetStatValue(StatsNames.VIGOR));
            currentMana = new CombatValue(build.stats.GetStatValue(StatsNames.MANA));
        }
    }

    public class CombatValue
    {
        public Action<float> onValueChanged;
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
                onValueChanged?.Invoke(this.value);
            }
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