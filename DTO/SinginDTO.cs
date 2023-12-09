namespace ASC_TEST;

public record SigninDTO
{
    public string Email{get;set;}
    public string Name{get;set;}
    public SigninDTO(string email, string name){
        Email = email;
        Name = name;
    }
}
