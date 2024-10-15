using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Dto
{
    public class ServiceActionResult
    {
        public object? Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string? Message { get; set; } = null;

        public ServiceActionResult() { }
        public ServiceActionResult(string message) { 
            this.IsSuccess = false;
            this.Message = message;
        }
    }
}
