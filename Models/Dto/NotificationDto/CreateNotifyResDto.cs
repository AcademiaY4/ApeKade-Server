#nullable disable
using System;

namespace apekade.Models.Dto.NotificationDto;

public class CreateNotifyResDto
{
  public string Id { get; set; }
  public string Title { get; set; }
  public string Message { get; set; }
  public DateTime CreatedAt { get; set; }
  public string NotificationType { get; set; }
  public bool IsRead { get; set; }
  public string VendorId { get; set; }
}