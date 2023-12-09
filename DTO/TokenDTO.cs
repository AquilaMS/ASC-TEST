namespace ASC_TEST;

public record TokenDTO
{
    public string token{get;set;}
    public TokenDTO(string token){
        this.token = token;
    }
}
