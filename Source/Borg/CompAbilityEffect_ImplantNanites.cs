using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using Verse.AI;

namespace Borg
{
    public class CompAbilityEffect_ImplantNanites : CompAbilityEffect
    {

        private new CompProperties_AbilityImplantNanites Props => (CompProperties_AbilityImplantNanites)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            Pawn pawn = target.Pawn;
            if (pawn != null)
            {
                pawn.health.AddHediff(BorgDefOfs.BorgInfectionPlayer);
                FleckMaker.AttachedOverlay(pawn, FleckDefOf.FlashHollow, new Vector3(0f, 0f, 0.26f));
                if (PawnUtility.ShouldSendNotificationAbout(parent.pawn) || PawnUtility.ShouldSendNotificationAbout(pawn))
                {
                    Find.LetterStack.ReceiveLetter("LetterLabelNanitesImplanted".Translate(), "LetterTextNanitesImplanted".Translate(parent.pawn.Named("CASTER"), pawn.Named("TARGET")), LetterDefOf.NeutralEvent, new LookTargets(parent.pawn, pawn));
                }
            }
        }

        public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
        {
            Pawn pawn = target.Pawn;
            if (pawn == null)
            {
                return base.Valid(target, throwMessages);
            }
            if (pawn.IsQuestLodger())
            {
                if (throwMessages)
                {
                    Messages.Message("MessageCannotImplantInTempFactionMembers".Translate(), pawn, MessageTypeDefOf.RejectInput, historical: false);
                }
                return false;
            }
            if (pawn.HostileTo(parent.pawn) && !pawn.Downed)
            {
                if (throwMessages)
                {
                    Messages.Message("MessageCantUseOnResistingPerson".Translate(parent.def.Named("ABILITY")), pawn, MessageTypeDefOf.RejectInput, historical: false);
                }
                return false;
            }
            if (pawn.IsBorg())
            {
                if (throwMessages)
                {
                    Messages.Message("MessageCannotUseOnFellowBorg".Translate(pawn), pawn, MessageTypeDefOf.RejectInput, historical: false);
                }
                return false;
            }

            return base.Valid(target, throwMessages);
        }

        public override IEnumerable<Mote> CustomWarmupMotes(LocalTargetInfo target)
        {
            Pawn pawn = target.Pawn;
            yield return MoteMaker.MakeAttachedOverlay(pawn, ThingDefOf.Mote_XenogermImplantation, new Vector3(0f, 0f, 0.3f));
        }

        

    }
}
