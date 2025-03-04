using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borg
{
    public class CompProperties_AbilityImplantNanites : CompProperties_AbilityEffect
    {
        public CompProperties_AbilityImplantNanites()
        {
            compClass = typeof(CompAbilityEffect_ImplantNanites);
        }
    }
}
