namespace ASC_TEST;

public record SignDTO
{
    public string Email{get;set;}
    public string Name{get;set;}
    public string Password{get;set;}
    public SignDTO(string email, string name, string password){
        Email = email;
        Name = name;
        Password = password;
    }
}
