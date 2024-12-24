namespace Player
{
    public interface ICharacter
    {
         void Damage(int damage);
         void Heal(int heal);
         void Move();
         void Die();
         void ChangeState(ECharacterFightState characterFightState);
         void ChangeCamp(ECharacterCamp characterCamp);
         
    }
}