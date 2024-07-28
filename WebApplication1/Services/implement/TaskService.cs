using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTO.Response;
using WebApplication1.Model;

namespace WebApplication1.Services.implement
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        public TaskService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TaskResponse>> GetTasksByUserId(int userId)
        {
            return await _context.SuiteTasks
                .Where(task => _context.SuiteTaskUsers
                    .Any(taskUser => taskUser.UserID_FK == userId && taskUser.TaskID_FK == task.TaskID))
                .Select(task => new TaskResponse
                {
                    TaskID = task.TaskID,
                    TaskName = task.TaskName,
                    TaskDescription = task.TaskDescription,
                    StartDate = task.StartDate,
                    EndDate = task.EndDate,
                    TaskStatus = task.TaskStatus
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<TaskChatMessageResponse>> GetChatMessagesByTaskId(int taskId)
        {
            var chatMessages = await _context.TaskChatMessages
                .Where(chat => chat.TaskID_FK == taskId && !chat.IsDeleted)
                .Select(chat => new TaskChatMessageResponse
                {
                    ChatMessageID = chat.ChatMessageID,
                    UserID = chat.UserID_FK,
                    DateCreated = chat.DateCreated,
                    Message = chat.Message,
                    IsEdited = chat.IsEdited,
                    DateEdited = chat.DateEdited,
                    Files = _context.AppFiles
                        .Where(file => file.FileType == 4 && file.FileTo == chat.ChatMessageID && !file.IsDeleted)
                        .Select(file => new AppFileResponse
                        {
                            FileID = file.FileID,
                            FileName_Actual = file.FileName_Actual,
                        }).ToList(),
                    Avatar = _context.UserAccounts
                                .Where(user => user.UserId == chat.UserID_FK)
                                .Select(user => user.AvatarPath)
                                .FirstOrDefault()
                })
                .ToListAsync();

            return chatMessages;
        }
    }
}
