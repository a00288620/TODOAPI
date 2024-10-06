using System;

namespace TodoApi.Models
{
    public class TodoItem
    {
        public int Id { get; set; }             // Unique identifier for the ToDo item
        public string Title { get; set; }
        // Title or name of the task
        public string Task { get; set; }
        public string Description { get; set; } // A detailed description of the task
        public bool IsCompleted { get; set; }   // Flag indicating if the task is completed

        public DateTime CreatedAt { get; set; } // Timestamp when the item was created
    }
}

