using System;
using System.Collections.Generic;

namespace libreria_api.Models
{
    public partial class AuditLog
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string Type { get; set; } = null!;
        public string TableName { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public string? OldValues { get; set; }
        public string NewValues { get; set; } = null!;
        public string? AffectedColumns { get; set; }
        public string PrimaryKey { get; set; } = null!;
    }
}
