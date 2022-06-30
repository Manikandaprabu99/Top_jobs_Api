﻿namespace PostJob.Api.Models.Entities
{
    public class Post
    {
        public Guid Id { get; set; }

        public string? CompanyName { get; set; }
        public string? JobTitle { get; set; }

        public string? Location { get; set; }

        public string? Summary { get; set; }

        public double? Salary { get; set; }

        public string? UrlHandle { get; set; }

        public string? FeatureImageUrl { get; set; }

        public bool Visible { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}
