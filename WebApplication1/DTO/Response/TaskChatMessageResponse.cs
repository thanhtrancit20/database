namespace WebApplication1.DTO.Response
{
    public class TaskChatMessageResponse
    {
        public int ChatMessageID { get; set; }
        public int UserID { get; set; }
        public string Avatar { get; set; }
        public DateTime DateCreated { get; set; }
        public string Message { get; set; }
        public bool IsEdited { get; set; }
        public DateTime DateEdited { get; set; }
        public IEnumerable<AppFileResponse> Files { get; set; }
    }
}
