using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;

public class DIClass
{
    private IDataProtectionProvider provider;

    public DIClass(IDataProtectionProvider provider) => this.provider = provider;
    public IDataProtector GetProtector(string[] purpose) => provider.CreateProtector(purpose);
}

public class Start
{
    public static void Main()
    {
        string test = "some text to protect";

        var services = new ServiceCollection();
        services.AddDataProtection();
        var provider = services.BuildServiceProvider();

        var instance = ActivatorUtilities.CreateInstance<DIClass>(provider);
        var protector = instance.GetProtector(new string[] { "abcd", "a2" });

        string save = protector.Protect(test);
        Console.WriteLine(save);
        Console.WriteLine(protector.Unprotect(save));
    }
}
