namespace EmojiHunter.Models.LivingObjectStates
{
    using System.Runtime.Serialization;

    [DataContract]
    class DefaultState : State
    {
        public DefaultState() : base(0, 0, 0, 0)
        {
        }
    }
}
