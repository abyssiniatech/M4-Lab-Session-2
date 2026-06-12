
// public class EnrollmentWorker
// {
//     private readonly EnrollmentService _service;

//     public EnrollmentWorker(EnrollmentService service)
//     {
//         _service = service;
//     }
// }


public class EnrollmentWorker
{
    private readonly IServiceScopeFactory _scopeFactory;

    public EnrollmentWorker(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public void ProcessBatch()
    {
        using var scope = _scopeFactory.CreateScope();

        var service =
            scope.ServiceProvider
                 .GetRequiredService<IEnrollmentService>();

        
    }
}