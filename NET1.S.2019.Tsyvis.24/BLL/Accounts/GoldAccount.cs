using BLL.Interface.Entities;

namespace BLL.Accounts
{
    public class GoldAccount : Account
    {
        private const double minimumAmount = -100;

        public override AccountType Type => AccountType.Gold;

        protected override int WithdrawCost => 3;

        protected override int DepositCost => 10;

        public override bool CanWithdraw(double amount)
        {
            return this.Balance - amount > minimumAmount;
        }

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
