namespace ASC_TEST;

public record SigninDTO
{
    public string Email{get;set;}
    public string Name{get;set;}
    public string Password{get;set;}
    public SigninDTO(string email, string name, string password){
        Email = email;
        Name = name;
        Password = password;
    }
}
