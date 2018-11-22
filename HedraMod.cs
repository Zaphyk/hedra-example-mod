using Hedra.API;

namespace HedraExample
{
    public class HedraMod : Mod
    {
        public override string Name => "Example Mod";

        public override void RegisterContent()
        {
            base.AddWeaponType("Mace", typeof(Mace));
        }
    }
}
