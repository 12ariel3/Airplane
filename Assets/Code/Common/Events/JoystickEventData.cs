namespace Assets.Code.Common.Events
{
    public class JoystickEventData : EventData
    {
        public readonly Joystick Joystick;
        public readonly int InstanceId;

        public JoystickEventData(Joystick joystick, int instanceId) : base(EventIds.SendJoystick)
        {
            Joystick = joystick;
            InstanceId = instanceId;
        }
    }
}