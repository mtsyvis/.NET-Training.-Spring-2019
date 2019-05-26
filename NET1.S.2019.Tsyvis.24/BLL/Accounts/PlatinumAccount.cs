using BLL.Interface.Entities;

namespace BLL.Accounts
{
    public class PlatinumAccount : Account
    {
        public override AccountType Type => AccountType.Platinum;

        protected override int WithdrawCost => 3;

        protected override int DepositCost => 20;

        protected override void RecountPoints(double oldSumValue)
        {
            if (this.Balance > oldSumValue)
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
