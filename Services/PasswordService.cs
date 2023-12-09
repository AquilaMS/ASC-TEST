namespace ASC_TEST;

public class PasswordService
{
    public static string GenerateHash(String password)
    {
        BCrypt.Net.BCrypt.GenerateSalt(Configs.SecretPasswordHash);
        string hashPassword =  BCrypt.Net.BCrypt.EnhancedHashPassword(password,10);
        return hashPassword;
    }
    public bool DecodeHashPassword(string hashedPassword, string plainPassword){
        bool isEqual = BCrypt.Net.BCrypt.EnhancedVerify(plainPassword,hashedPassword) ;
        return isEqual;
    }
}
