namespace MongoDB_CRUD.Models
{
    public class DbConfiguration
    {
        public string accountCollectionName { get; set; }
        public string skillCollectionName { get; set; }

        public string courseCollectionName { get; set; }
        public string administratorCollectionName { get; set; }
        public string classCollectionName { get; set; }
        public string departmentCollectionName { get; set; }
        public string roleCollectionName { get; set; }
        public string traineeCourseManagementCollectionName { get; set; }
        public string traineeCollectionName { get; set; }
        public string trainerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
