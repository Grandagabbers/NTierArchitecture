using System;

namespace RetroTool.Models
{
    /// <summary>
    /// The errorviewmodel class with its properties
    /// This model is used when an error occurs
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}