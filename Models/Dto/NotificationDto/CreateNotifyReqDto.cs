#nullable disable
using System;

namespace apekade.Models.Dto.NotificationDto;

public class CreateNotifyReqDto
{
  public string Title { get; set; }
  public string Message { get; set; }
  public string NotificationType { get; set; }
  public string VendorId { get; set; }
}