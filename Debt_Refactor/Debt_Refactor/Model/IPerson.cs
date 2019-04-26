namespace Debt_Refactor.Model
{
    public interface IPerson
    {
        string name { get; set; }
        double getTransactionSum();
        void addAmount(IDebt debit);
    }
}
