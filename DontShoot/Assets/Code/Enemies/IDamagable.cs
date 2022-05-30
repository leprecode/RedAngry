namespace Assets.Code.Enemies
{
    public interface IDamagable
    {
        void ApplyDamage(float damage);
        void CheckHealth();
    }
}