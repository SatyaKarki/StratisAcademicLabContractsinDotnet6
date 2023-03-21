using Stratis.SmartContracts;
public class HelloWorld2:SmartContract
{
    public HelloWorld2(ISmartContractState smartContractState) : base(smartContractState)
    {
        this.Bounds = 0;
        this.Index = -1;
        this.Greeting = "Hello World!";
    }
    private int Index
    {
        get
        {
            return this.State.GetInt32("Index");
        }
        set
        {
            this.State.SetInt32("Index", value);
        }
    }

    private int Bounds
    {
        get
        {
            return this.State.GetInt32("Bounds");
        }
        set
        {
            this.State.SetInt32("Bounds", value);
        }
    }
    private string Greeting
    {
        get
        {
            this.Index++;
            if (this.Index >= this.Bounds)
            {
                this.Index = 0;
            }

            return this.State.GetString("Greeting" + this.Index);
        }
        set
        {
            this.State.SetString("Greeting" + this.Bounds, value);
            this.Bounds++;
        }
    }
    public string AddGreeting(string helloMessage)
    {
        this.Greeting = helloMessage;
        return "Added '" + helloMessage + "' as a greeting.";
    }
    public string SayHello()
    {
        return this.Greeting;
    }
}

