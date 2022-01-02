using GTANetworkAPI;

namespace ULife.Core
{
    class Fingerpointing : Script
    {
        [RemoteEvent("fpsync.update")]
        public static void FingerPoint(Player sender, float camPitch, float camHeading)
        {
            NAPI.ClientEvent.TriggerClientEventInRange(sender.Position, 100, "fpsync.update", sender.Handle, camPitch, camHeading);
        }
        [RemoteEvent("pointingStop")]
        public void FingerStop(Player Player)
        {
            Player.StopAnimation();
        }
    }
}
