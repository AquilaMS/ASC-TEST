namespace ASC_TEST;

public record SignupDTO
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public SignupDTO(string email, string name, string password)
    {
        Email = email;
        Name = name;
        Password = password;
    }
}