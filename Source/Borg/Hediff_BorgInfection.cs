﻿using RimWorld;
using Verse;

namespace BorgAssimilate
{
    public class Hediff_BorgInfection : Hediff_Injury
    {
        public override void Notify_PawnDied(DamageInfo? dinfo, Hediff culprit = null)
        {
            base.Notify_PawnDied(dinfo, culprit);

            if (!pawn.def.race.Animal)
            {
                var corpse = pawn.Corpse;
                var newBorg = PawnGenerator.GeneratePawn(PawnKindDef.Named("BorgDrone3"),
                    FactionUtility.DefaultFactionFrom(FactionDef.Named("BorgCollective")));
                newBorg.Position = corpse.Position;
                newBorg.SpawnSetup(corpse.Map, false);

                corpse?.Destroy();

                return;
            }

            Messages.Message(
                "an animal has succumbed to nanite infection, and have been deemed inappropriate for assimilation. The nanites have consumed and destroyed the corpse.",
                MessageTypeDefOf.NeutralEvent);
            pawn.Corpse.Destroy();
        }
    }
}
