using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Model;

public class ChatHub : Hub
{
    private readonly AppDbContext _myContext;

    public ChatHub(AppDbContext myContext)
    {
        _myContext = myContext;
    }

    public async Task SendMessage(int taskID, int userID, string message, string fileName_Actual)
    {
        var dateCreated = DateTime.UtcNow;

        var chatMessage = new TaskChatMessage
        {
            TaskID_FK = taskID,
            UserID_FK = userID,
            DateCreated = dateCreated,
            DateEdited = dateCreated,
            Message = message,
        };
        _myContext.TaskChatMessages.Add(chatMessage);
        await _myContext.SaveChangesAsync();

        if (!string.IsNullOrEmpty(fileName_Actual))
        {
            var appFile = new AppFile
            {
                UserID_FK = userID,
                DateUploaded = dateCreated,
                FileName_Actual = fileName_Actual,
                FileName_Stored = fileName_Actual,
                FileSize = 0,
                FileExtension = System.IO.Path.GetExtension(fileName_Actual),
                FileType = 4,
                FileTo = chatMessage.ChatMessageID,
                IsDeleted = false
            };
            _myContext.AppFiles.Add(appFile);
            await _myContext.SaveChangesAsync();
        }

        var user = await _myContext.UserAccounts.FirstOrDefaultAsync(u => u.UserId == userID);
        var avatar = user.AvatarPath;
        var email = user.EmailAddress;
        var isNew = true;
        await Clients.Group(taskID.ToString()).SendAsync("ReceiveMessage", userID, avatar, email, dateCreated, message, fileName_Actual, isNew);
    }

    public async Task JoinGroup(int taskID)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, taskID.ToString());
    }

    public async Task LeaveGroup(int taskID)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, taskID.ToString());
    }
}