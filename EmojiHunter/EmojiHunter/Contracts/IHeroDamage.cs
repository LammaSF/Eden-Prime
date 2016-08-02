namespace EmojiHunter.Contracts
{
    public interface IHeroDamage
    {
        int Damage { get; }
        
        int CurrentMaxDamage { get; set; }
    }
}
