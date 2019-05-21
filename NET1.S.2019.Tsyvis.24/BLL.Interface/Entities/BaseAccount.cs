namespace BLL.Interface.Entities
{
    public class BaseAccount : Account
    {
        public override int BalanceValue => 34;

        public override int DepositeCost => 24;
    }
}
