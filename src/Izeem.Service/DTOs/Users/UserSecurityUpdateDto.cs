﻿namespace Izeem.Service.DTOs.Users;

public class UserSecurityUpdateDto
{
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }
}
