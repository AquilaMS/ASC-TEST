namespace ASC_TEST;

public class PasswordService
{
    public static string GenerateHash(string password)
    {
        string hashPassword =  BCrypt.Net.BCrypt.EnhancedHashPassword(password,10);
        return hashPassword;
    }
    public bool DecodeHashPassword(string plainPassword,string hashedPassword){
        bool isEqual = BCrypt.Net.BCrypt.EnhancedVerify(plainPassword,hashedPassword) ;
        return isEqual;
    }
}
