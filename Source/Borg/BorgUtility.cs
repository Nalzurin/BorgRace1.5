using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using AlienRace;
namespace Borg
{
    public static class BorgUtility
    {
        public static bool IsBorg(this Pawn pawn)
        {
            return pawn.kindDef.IsBorg();
        }
        public static bool IsBorg(this PawnKindDef pawnKindDef)
        {
            return pawnKindDef.race == BorgDefOfs.Alien_Borg_Base;
        }
    }
}
