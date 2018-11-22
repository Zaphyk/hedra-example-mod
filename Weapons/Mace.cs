using Hedra;
using Hedra.Rendering;
using Hedra.EntitySystem;
using Hedra.WeaponSystem;

namespace HedraExample
{
    /// <summary>
    /// Description of TwoHandedSword.
    /// </summary>
    public class Mace : HeavyMeleeWeapon
    {
        protected override float SecondarySpeed => 1.0f;
        protected override float PrimarySpeed => 1.0f;

        public Mace(VertexData Contents) : base(Contents)
        {
        }

        protected override void OnPrimaryAttackEvent(AttackEventType Type, AttackOptions Options)
        {
            /* Just damage surrondings */
            if (AttackEventType.Mid != Type) return;
            Owner.AttackSurroundings(Owner.DamageEquation);
        }

        protected override void OnSecondaryAttackEvent(AttackEventType Type, AttackOptions Options)
        {
            /* Only do damage at the end of the animation. */
            if (Type != AttackEventType.End) return;
            /* Do damage to everything in the surroundings. */
            Owner.AttackSurroundings(Owner.DamageEquation * 1.25f * Options.DamageModifier, delegate (IEntity Mob)
            {
                /* 1 in 5 chance to knock for 3 seconds. */
                if(Utils.Rng.Next(0, 5) == 1 && Options.Charge > .5f)
                    Mob.KnockForSeconds(3);
            });
        }
    }
}