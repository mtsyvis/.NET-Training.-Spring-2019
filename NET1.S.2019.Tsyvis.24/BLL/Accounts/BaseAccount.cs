using BLL.Interface.Entities;

namespace BLL.Accounts
{
    public class BaseAccount : Account
    {
        public override AccountType Type => AccountType.Base;

        protected override int WithdrawCost => 2;

        protected override int DepositCost => 5;

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
