namespace MyDDDSolution.Tests;

using Xunit;
using MyDDDSolution.Logic;
using FluentAssertions;
public class SnackMachineSpecs 
{

    [Fact]
    public void Return_money_empties_money_in_transaction()
    {
        MySnackMachine mySnackMachine = new MySnackMachine();
        mySnackMachine.InsertMoney(Money.OneDinarMoney);

        mySnackMachine.ReturnMoney();

        mySnackMachine.MoneyInTransaction.Amount.Should().Be(0m);

    }   

    [Fact]
    public void Inserted_money_goes_to_money_in_transaction()
    {
        MySnackMachine mySnackMachine = new MySnackMachine();
        mySnackMachine.InsertMoney(Money.A25FilsMoney);
        mySnackMachine.InsertMoney(Money.OneDinarMoney);

        mySnackMachine.MoneyInTransaction.Should().Be(1025m);

    }

    [Fact]
    public void Cannon_insert_more_than_one_coin_or_note_at_a_time()
    {
         MySnackMachine mySnackMachine = new MySnackMachine();
         var twoA25FilsCoins = Money.A25FilsMoney + Money.A25FilsMoney;

         Action myAction = () => 
         {
            mySnackMachine.InsertMoney(twoA25FilsCoins);
         };

         myAction.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Money_in_transaction_goes_to_money_inside_after_purchase()
    {
         MySnackMachine mySnackMachine = new MySnackMachine();
         mySnackMachine.InsertMoney(Money.OneDinarMoney);
         mySnackMachine.InsertMoney(Money.A100FilsMoney);
         mySnackMachine.InsertMoney(Money.A100FilsMoney);
         mySnackMachine.InsertMoney(Money.A50FilsMoney);

         mySnackMachine.BuySnack();

         mySnackMachine.MoneyInTransaction.Should().Be(Money.NoneMoney);
         mySnackMachine.MoneyInside.Should().Be(1250m);
    }


}//--End-Class