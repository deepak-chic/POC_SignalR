using System;

namespace POC_SignalR.Model
{
    public class Project
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string Name { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime? FinishedDate { get; set; }
    }
}
