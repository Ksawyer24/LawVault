namespace LawVault.Enum;

public enum NotificationEventType
{
    // File operations
    FileUploadSuccess,
    FileUploadFailed,
    FileDeleteSuccess,
    FileDeleteFailed,
    
    // Reminder operations
    ReminderDue,
    ReminderCreated,
    ReminderCompleted,
    
    // Client operations
    ClientAdded,
    ClientUpdated,
    ClientDeleted,
    
    // Case operations
    CaseCreated,
    CaseUpdated,
    CaseStatusChanged
}