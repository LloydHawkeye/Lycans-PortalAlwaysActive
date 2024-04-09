using Fusion;
using UnityEngine;

namespace PortalAlwaysActive.Patch
{
    internal class PortalPatch
    {
        public static void patch()
        {
            On.Portal.StartActivationTimer += Portal_StartActivationTimer;
        }

        private static void Portal_StartActivationTimer(On.Portal.orig_StartActivationTimer orig, Portal self)
        {
            if (self.HasStateAuthority)
            {
                self.Active = false;
                //Désactivation du timer
                self.ActivationTimer = TickTimer.CreateFromSeconds(self.Runner, 0.5f);
            }
        }
    }
}
