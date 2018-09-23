using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelmesAssignment.Entities.Models
{
    public enum MessageType
    {
        Success,
        Info,
        Warning,
        Danger
    }

    public class FlashMessage
    {
        public string Message { get; set; }
        public MessageType MessageType { get; set; }
    }
}