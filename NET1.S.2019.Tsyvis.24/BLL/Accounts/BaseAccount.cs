namespace BLL.Interface.Entities
{
    public class BaseAccount : Account
    {
        public override int WithdrawCost => 2;

        public override int DepositCost => 5;

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
