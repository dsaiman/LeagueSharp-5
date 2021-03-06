﻿#region

using LeagueSharp;
using LeagueSharp.Common;

#endregion

namespace Godyr
{
    internal static class AICombos
    {
        public static void Combo()
        {

            var target = Config.Orbwalker.GetTarget() as Obj_AI_Base;

            if (target == null)
            {
                return;
            }

            switch (Udyr.Stance)
            {
                case Udyr.Stances.Tiger:
                    Udyr.R.Cast();
                    break;

                case Udyr.Stances.Turtle:
                    if (!Udyr.Q.Cast() && Udyr.Q.Level == 0)
                    {
                        Udyr.R.Cast();
                    }

                    break;

                case Udyr.Stances.Bear:
                    if (!target.HasBuff("udyrbearstuncheck", true))
                    {
                        break;
                    }

                    if (!Udyr.Q.Cast() && Udyr.Q.Level == 0)
                    {
                        Udyr.R.Cast();
                    }
                    break;

                case Udyr.Stances.Phoenix:

                    if (!target.HasBuff("udyrbearstuncheck", true) && Udyr.E.Cast()) {}
                    if (Config.CanUseShield() && Udyr.W.Cast()) {}

                    break;
            }
        }

        public static void Farm()
        {
            var target = Config.Orbwalker.GetTarget();

            if (target == null)
            {
                return;
            }

            switch (Udyr.Stance)
            {
                case Udyr.Stances.Tiger:
                    Udyr.R.Cast();
                    break;

                case Udyr.Stances.Turtle:
                    if (!Udyr.Q.Cast() && Udyr.Q.Level == 0)
                    {
                        Udyr.R.Cast();
                    }
                    break;

                case Udyr.Stances.Bear:
                    if (!Udyr.Q.Cast() && Udyr.Q.Level == 0)
                    {
                        Udyr.R.Cast();
                    }
                    break;

                case Udyr.Stances.Phoenix:
                    if (!Config.CanLeavePhoenix())
                    {
                        break;
                    }

                    if (Config.CanUseShield())
                    {
                        Udyr.W.Cast();
                    }
                    else
                    {
                        Udyr.Q.Cast();
                    }

                    break;

                default:
                    if (!Udyr.R.Cast())
                    {
                        Udyr.Q.Cast();
                    }
                    break;
            }
        }
    }
}