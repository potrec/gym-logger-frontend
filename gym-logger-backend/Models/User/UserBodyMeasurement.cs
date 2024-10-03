namespace gym_logger_backend.Models.User
{
    public class UserBodyMeasurement
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public double Weight { get; set; } = 0.0;
        public double Height { get; set; } = 0.0;
        public double BodyFatPercentage { get; set; } = 0.0;
        public double LeanBodyMass { get; set; } = 0.0;
        public double BodyMassIndex { get; set; } = 0.0;
        public double WaistCircumference { get; set; } = 0.0;
        public double HipCircumference { get; set; } = 0.0;
        public double NeckCircumference { get; set; } = 0.0;
        public double ChestCircumference { get; set; } = 0.0;
        public double RightArmCircumference { get; set; } = 0.0;
        public double LeftArmCircumference { get; set; } = 0.0;
        public double RightThighCircumference { get; set; } = 0.0;
        public double LeftThighCircumference { get; set; } = 0.0;
        public double RightCalfCircumference { get; set; } = 0.0;
        public double LeftCalfCircumference { get; set; } = 0.0;
        public DateTime Date { get; set; } = DateTime.MinValue;
        public int Status { get; set; } = 0;
    }
}
