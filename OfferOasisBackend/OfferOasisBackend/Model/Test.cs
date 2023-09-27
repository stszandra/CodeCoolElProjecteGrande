namespace OfferOasisBackend.Model;

public class Test
{
    public int Id { get; init; }
    public string StringTest { get; set; }
    public int IntTest { get; set; }

    public Test(string stringTest, int intTest)
    {
        StringTest = stringTest;
        IntTest = intTest;
    }
}