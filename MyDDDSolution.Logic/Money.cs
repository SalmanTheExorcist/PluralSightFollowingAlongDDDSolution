namespace MyDDDSolution.Logic;

public sealed class  Money : ValueObject<Money>
{
    public static readonly Money NoneMoney = new Money(0,0,0,0,0,0);
    public static readonly Money A25FilsMoney = new Money(1,0,0,0,0,0);
    public static readonly Money A50FilsMoney = new Money(0,1,0,0,0,0);
    public static readonly Money A100FilsMoney = new Money(0,0,1,0,0,0);
    public static readonly Money OneDinarMoney = new Money(0,0,0,1,0,0);
    public static readonly Money FiveDinarMoney = new Money(0,0,0,0,1,0);
    public static readonly Money TwentyDinarMoney = new Money(0,0,0,0,0,1);

    public int A25FilsCoinCount { get; }
    public int A50FilsCoinCount { get;  }
    public int A100FilsCoinCount { get; }
    public int OneDinarCount { get; }
    public int FiveDinarCount { get; }
    public int TwentyDinarCount { get; }
    public decimal Amount => 
                A25FilsCoinCount +
                A50FilsCoinCount +
                A100FilsCoinCount +
                OneDinarCount * 1000 +
                FiveDinarCount * 1000 +
                TwentyDinarCount * 1000;
        
        
    


    public Money(int a25FilsCoinCount,
                            int a50FilsCoinCount,
                            int a100FilsCoinCount,
                            int oneDinarCount,
                            int fiveDinarCount,
                            int twentyDinarCount)
    {
        if(a25FilsCoinCount < 0)
            throw new InvalidOperationException();
        
        if(a50FilsCoinCount < 0)
            throw new InvalidOperationException();

        if(a100FilsCoinCount < 0)
            throw new InvalidOperationException();

        if(oneDinarCount < 0)
            throw new InvalidOperationException();

        if(fiveDinarCount < 0)
            throw new InvalidOperationException();

        if(TwentyDinarCount < 0)
            throw new InvalidOperationException();


        A25FilsCoinCount = a25FilsCoinCount;
        A50FilsCoinCount = a50FilsCoinCount;
        A100FilsCoinCount = a100FilsCoinCount;
        OneDinarCount = oneDinarCount;
        FiveDinarCount = fiveDinarCount;
        TwentyDinarCount = twentyDinarCount;
    }


 

    public static Money operator -(Money money1, Money money2)
    {
         return new Money(
            money1.A25FilsCoinCount - money2.A25FilsCoinCount,
            money1.A50FilsCoinCount - money2.A50FilsCoinCount,
            money1.A100FilsCoinCount - money2.A100FilsCoinCount,
            money1.OneDinarCount - money2.OneDinarCount,
            money1.FiveDinarCount - money2.FiveDinarCount,
            money1.TwentyDinarCount - money2.TwentyDinarCount
        );
     
    }

    public static Money operator +(Money money1, Money money2)
    {
        Money sumMoney = new Money(
            money1.A25FilsCoinCount + money2.A25FilsCoinCount,
            money1.A50FilsCoinCount + money2.A50FilsCoinCount,
            money1.A100FilsCoinCount + money2.A100FilsCoinCount,
            money1.OneDinarCount + money2.OneDinarCount,
            money1.FiveDinarCount + money2.FiveDinarCount,
            money1.TwentyDinarCount + money2.TwentyDinarCount
        );

        return sumMoney;
    }

    protected override bool EqualsCore(Money other)
    {
       return A25FilsCoinCount == other.A25FilsCoinCount
        && A50FilsCoinCount == other.A50FilsCoinCount
        && A100FilsCoinCount == other.A100FilsCoinCount
        && OneDinarCount == other.OneDinarCount
        && FiveDinarCount == other.FiveDinarCount
        && TwentyDinarCount == other.TwentyDinarCount;
    }

    protected override int GetHashCodeCore()
    {
        unchecked
        {
                int hashCode = A25FilsCoinCount;
                hashCode = (hashCode * 397) ^ A50FilsCoinCount;
                hashCode = (hashCode * 397) ^ A100FilsCoinCount;
                hashCode = (hashCode * 397) ^ OneDinarCount;
                hashCode = (hashCode * 397) ^ FiveDinarCount;
                hashCode = (hashCode * 397) ^ TwentyDinarCount;
                return hashCode;
        }

    }

    
}//--End--Class