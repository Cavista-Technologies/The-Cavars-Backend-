namespace CavistaLaptopLifecycleManagement.Api.Database.Entities
{
    public class AuditTrail : BaseEntity
    {
        public string Action { get; set; }

        public string ActionBy { get; set; }

        public string ActionOn { get; set; }

        public DateTimeOffset ActionAt { get; set; }
    }
}
