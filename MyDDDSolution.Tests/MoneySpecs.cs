namespace MyDDDSolution.Tests;

using Xunit;
using MyDDDSolution.Logic;
using FluentAssertions;

public class MoneySpecs
{
    [Fact]
    public void Sum_of_two_money_produces_correct_result()
    {
        //--Step-1:Arrange
        Money moneyONE = new Money(1,2,3,4,5,6);
        Money moneyTWO = new Money(1,2,3,4,5,6);

        //--Step-2:Act
        Money sumMoney = moneyONE + moneyTWO;

        //--Step-3:Assert
        sumMoney.A25FilsCoinCount.Should().Be(2);
        sumMoney.A50FilsCoinCount.Should().Be(4);
        sumMoney.A100FilsCoinCount.Should().Be(6);
        sumMoney.OneDinarCount.Should().Be(8);
        sumMoney.FiveDinarCount.Should().Be(10);
        sumMoney.TwentyDinarCount.Should().Be(12);

        
    }
    //---------------------------------------

    [Fact]
    public void Two_moeny_instances_equall_if_contain_the_same_money_amount()
    {
         //--Step-1:Arrange
        Money moneyONE = new Money(1,2,3,4,5,6);
        Money moneyTWO = new Money(1,2,3,4,5,6);

         //--Step-3:Assert
        moneyONE.Should().Be(moneyTWO);

        moneyONE.GetHashCode().Should().Be(moneyTWO.GetHashCode());

    }
    //---------------------------------------

    [Fact]
    public void Two_money_instances_do_not_equall_if_contains_different_money_amounts()
    {
        Money oneDinarMoney = new Money(0,0,0,1,0,0);
        Money a100FilsMoney = new Money(0,0,100,0,0,0);

        oneDinarMoney.Should().NotBe(a100FilsMoney);
        oneDinarMoney.GetHashCode().Should().NotBe(a100FilsMoney.GetHashCode());



    }
    //---------------------------------------

    [Theory]
    [InlineData(-1,0,0,0,0,0)]
    [InlineData(0,-2,0,0,0,0)]
    [InlineData(0,0,-3,0,0,0)]
    [InlineData(0,0,0,-4,0,0)]
    [InlineData(0,0,0,0,-5,0)]
    [InlineData(0,0,0,0,0,-6)]
    public void Cannot_create_money_with_negative_value(
                            int a25FilsCoinCount,
                            int a50FilsCoinCount,
                            int a100FilsCoinCount,
                            int oneDinarCount,
                            int fiveDinarCount,
                            int twentyDinarCount)
    {
        Action myAction = ()=> new Money(
                              a25FilsCoinCount,
                              a50FilsCoinCount,
                              a100FilsCoinCount,
                              oneDinarCount,
                              fiveDinarCount,
                              twentyDinarCount);
        
        myAction.Should().ThrowExactly<InvalidOperationException>();

    }
    //---------------------------------------

    [Theory]
    [InlineData(0,0,0,0,0,0,0)]
    [InlineData(1,0,0,0,0,0,25)]
    [InlineData(1,2,0,0,0,0,125)]
    [InlineData(1,2,3,0,0,0,225)]
    [InlineData(1,2,3,4,0,0,4225)]
    [InlineData(1,2,3,4,5,0,29225)]
    [InlineData(1,2,3,4,5,6,149225)]
    public void Amount_is_calculated_correctly( 
                            int a25FilsCoinCount,
                            int a50FilsCoinCount,
                            int a100FilsCoinCount,
                            int oneDinarCount,
                            int fiveDinarCount,
                            int twentyDinarCount,
                            decimal expectedAmount)
    {

        Money myMoney = new Money(
                              a25FilsCoinCount,
                              a50FilsCoinCount,
                              a100FilsCoinCount,
                              oneDinarCount,
                              fiveDinarCount,
                              twentyDinarCount);

        myMoney.Amount.Should().Be(expectedAmount);
    }
    //---------------------------------------

    [Fact]
    public void Subtraction_of_two_money_produces_correct_result()
    {
        Money moneyONE = new Money(10,10,10,10,10,10);
        Money moneyTWO = new Money(1,2,3,4,5,6);

        Money moneyResults = moneyONE - moneyTWO;

        moneyResults.A25FilsCoinCount.Should().Be(9);
        moneyResults.A50FilsCoinCount.Should().Be(8);
        moneyResults.A100FilsCoinCount.Should().Be(7);
        moneyResults.OneDinarCount.Should().Be(6);
        moneyResults.FiveDinarCount.Should().Be(5);
        moneyResults.OneDinarCount.Should().Be(4);

    }
    //---------------------------------------

    [Fact]
    public void Cannot_subtract_more_than_exists()
    {
        Money moneyONE = new Money(0,1,0,0,0,0);
        Money moneyTWO = new Money(1,0,0,0,0,0);

        Action myAction = ()=>
        {
            Money resultsMoney = moneyONE - moneyTWO;
        };
        
        myAction.Should().Throw<InvalidOperationException>();
    }
    //---------------------------------------
}//--End-Class
