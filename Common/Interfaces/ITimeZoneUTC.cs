namespace HRSystem.Common.Interfaces
{
    public interface ITimeZoneUTC
    {
        Guid EmpId { get; }
        DateTimeOffset? CheckInTime { get; set; }
        DateTimeOffset? CheckOutTime { get; set; }
    }
}
