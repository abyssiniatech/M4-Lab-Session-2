
public interface IEnrollmentService
{
    Task<EnrollmentRecord> EnrollAsync(string studentId, string courseCode);

    Task<EnrollmentRecord?> GetByIdAsync(string id);

    Task<IReadOnlyList<EnrollmentRecord>> GetAllAsync();

    Task<bool> DeleteAsync(string id);
}



public class EnrollmentService : IEnrollmentService
{
    private readonly Dictionary<string, EnrollmentRecord> hi = new();
    private readonly ILogger<EnrollmentService> _logger;

    public EnrollmentService(ILogger<EnrollmentService> logger)
    {
        _logger = logger;
    }

    public Task<EnrollmentRecord> EnrollAsync(string studentId, string courseCode)
    {
        var id = Guid.NewGuid().ToString("N")[..8];

        var record = new EnrollmentRecord(
            id,
            studentId,
            courseCode,
            DateTime.UtcNow);

        hi[id] = record;


        _logger.LogInformation(
            "Enrolled {StudentId} in {CourseCode} record {EnrollmentId}",
            studentId,
            courseCode,
            id);

        return Task.FromResult(record);
    }

    public Task<EnrollmentRecord?> GetByIdAsync(string id)
    {
        hi.TryGetValue(id, out var record);
        return Task.FromResult(record);
    }

    public Task<IReadOnlyList<EnrollmentRecord>> GetAllAsync()
    {
        IReadOnlyList<EnrollmentRecord> all = hi.Values.ToList();
        return Task.FromResult(all);
    }

    public Task<bool> DeleteAsync(string id)
    {
        var removed = hi.Remove(id);
        return Task.FromResult(removed);
    }
}

public record EnrollmentRecord(
    string Id,
    string StudentId,
    string CourseCode,
    DateTime EnrolledAt);