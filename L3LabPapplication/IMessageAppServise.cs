using L3Lab.EntityFrameworkCore.Entities;

    public interface IMessageAppService 
{
    //Non async
    void AddMessage(L3LabMessage input);
    List<L3LabMessage> GetMessages();
    public L3LabMessage GetMessageById(int id);
    public void DeleteMessage(int id);
    public L3LabMessage UpdateMessage(L3LabMessage m);
    //async
    /*Task<ListResultDto<MMessageDto>> GetMessagesAsync();*/
    /*Task<L2LabMessage> AddMessageAsync(CreateMessageInput input);
    Task<L2LabMessage> GetMessageByIdAsync(int id);*/
    //Task DeleteMessageAsync(int id);
    //Task<L2LabMessage> UpdateMessageAsync(L2LabMessage m);


}
