using System;

namespace TestsApi.Models
{
    public class ResponseModel
    {
        public string? copyright { get; set; }
        public string? date { get; set; }
        public string? explanation { get; set;}
        public string? hdurl { get; set; }
        public string? media_type { get; set; }
        public string? service_version { get; set; }
        public string? title { get; set; }
        public string? url { get; set; }
        public validity_checks? validity_checks { get; set; }
    }

    public class validity_checks
    {
        public int sol_hours_required { get; set; }
        public int sols_checked { get; set; }
    }
}
