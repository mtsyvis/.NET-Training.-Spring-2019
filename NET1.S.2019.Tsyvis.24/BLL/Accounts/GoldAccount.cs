using BLL.Interface.Entities;

namespace BLL.Accounts
{
    public class GoldAccount : Account
    {
        public override AccountType Type => AccountType.Gold;

        protected override int WithdrawCost => 3;

        protected override int DepositCost => 10;

        protected override void RecountPoints(double oldSumValue)
        {
            if (this.Sum > oldSumValue)
            {
                this.Points += this.DepositCost;
            }
            else
            {
                this.Points -= this.WithdrawCost;
            }
        }
    }
}
