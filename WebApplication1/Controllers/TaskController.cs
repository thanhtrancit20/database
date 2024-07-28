using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Response;
using WebApplication1.Model;
using WebApplication1.Services.implement;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("GetTasksByUser/{userId}")]
        public async Task<ActionResult<IEnumerable<SuiteTask>>> GetTasksByUser(int userId)
        {
            var tasks = await _taskService.GetTasksByUserId(userId);
            if (tasks == null || !tasks.Any())
            {
                return NotFound();
            }
            return Ok(tasks);
        }

        [HttpGet("GetChatMessagesByTask/{taskId}")]
        public async Task<ActionResult<IEnumerable<TaskChatMessageResponse>>> GetChatMessagesByTask(int taskId)
        {
            var messages = await _taskService.GetChatMessagesByTaskId(taskId);
            if (messages == null || !messages.Any())
            {
                return NotFound();
            }
            return Ok(messages);
        }
    }
}