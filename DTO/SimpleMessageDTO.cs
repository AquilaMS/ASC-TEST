namespace ASC_TEST;

public record SimpleMessageDTO
{
    public string Message{get;set;}
    public SimpleMessageDTO(string message){
        Message = message;
    }
}
