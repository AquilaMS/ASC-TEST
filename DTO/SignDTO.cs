namespace ASC_TEST;

public record SignDTO
{
    public string Name{get;set;}
    public string Password{get;set;}
    public SignDTO( string name, string password){
        Name = name;
        Password = password;
    }
}
