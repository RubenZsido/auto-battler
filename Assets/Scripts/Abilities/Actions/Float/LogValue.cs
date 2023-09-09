public class LogValue : BaseFloatAction
{
    public override void Activate(float value)
    {
        Messenger.Instance.Log("Event triggered with value: " + value);
    }
}