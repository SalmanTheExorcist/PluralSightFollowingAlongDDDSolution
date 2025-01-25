namespace MyDDDSolution.Logic;

public sealed class MySnackMachine : Entity
{
    public Money MoneyInside { get; private set; } = Money.NoneMoney;
   
    //---------------------------------------------------
     public Money MoneyInTransaction { get; private set; } = Money.NoneMoney;
  
    //---------------------------------------------------
   



    //---------------------------------------------------
    public void InsertMoney(Money money)
    {
        Money[] allowedCoinsAndNotes = { Money.A25FilsMoney,
                                        Money.A50FilsMoney,
                                        Money.A50FilsMoney,
                                        Money.OneDinarMoney,
                                        Money.FiveDinarMoney,
                                        Money.TwentyDinarMoney };

        if(!allowedCoinsAndNotes.Contains(money))
           throw new InvalidOperationException();
        

       MoneyInTransaction += money;

    }//--End-InsertMoney
    //----------------------------------

    public void ReturnMoney()
    {
        MoneyInTransaction = Money.NoneMoney;
    }
    //----------------------------------

    public void BuySnack()
    {
       
     MoneyInside += MoneyInTransaction;

     MoneyInTransaction = Money.NoneMoney;
       
    }



}//--End-Class