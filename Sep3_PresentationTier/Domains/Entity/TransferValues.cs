﻿namespace Domains.Entity;

public class TransferValues
{
    public static UserEntity? RequestSender { get; set; }
    public static int RequestedAmount { get; set; }
    public static long RequestId { get; set; }
}