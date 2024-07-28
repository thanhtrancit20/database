using WebApplication1.DTO.Response;
using WebApplication1.Model;

namespace WebApplication1.Services
{
    public interface ITaskService
    {
        public Task<IEnumerable<TaskResponse>> GetTasksByUserId(int userId);
        public Task<IEnumerable<TaskChatMessageResponse>> GetChatMessagesByTaskId(int taskId);
    }
}
