using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System;


namespace MongoDB_CRUD.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("CourseName")]
        public string CourseName { get; set; }
        [BsonElement("Duration")]
        public double Duration { get; set; }
        [BsonElement("HoursOfTheory")]
        public double HoursOfTheory { get; set; }
        [BsonElement("HoursOfPractice")]
        public double HoursOfPractice { get; set; }
        [BsonElement("TrainerInfo")]
        public string TrainerInfo { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("ListOfSkills")]
        public List<string> ListOfSkills { get; set; }
        [BsonElement("NumberOfEnrollment")]
        public int NumberOfEnrollment { get; set; }
        [BsonElement("StartDate")]
        public DateTime StartDate { get; set; }
        [BsonElement("EndDate")]
        public DateTime EndDate { get; set; }
        [BsonElement("Type")]
        public string Type { get; set; }
        [BsonElement("ListOfPreCourses")]
        public List<string> ListOfPreCourses { get; set; }



    }
}
