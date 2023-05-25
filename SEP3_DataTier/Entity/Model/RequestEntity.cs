﻿using System.ComponentModel.DataAnnotations;

namespace Entity.Model;

public class RequestEntity
{
    [Key] public long Id { get; set; }
    public UserEntity? RequestSender { get; set; }
    public UserEntity? RequestReceiver { get; set; }
    public string? RequestedDate { get; set; }
    public int Amount { get; set; }
    public string? Comment { get; set; }
    
    public bool IsApproved { get; set; }
    public string? Status { get; set; }
}