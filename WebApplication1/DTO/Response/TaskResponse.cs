namespace WebApplication1.DTO.Response
{
    public class TaskResponse
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte TaskStatus { get; set; }
    }
}
