using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
#pragma warning disable CA1050 // Declare types in namespaces
public class EnrollmentsController(IEnrollmentService enrolementService
#pragma warning restore CA1050 // Declare types in namespaces
 ) : ControllerBase
{
    private readonly IEnrollmentService? enrollmentService;

    [HttpGet] 
    public async Task<IActionResult> GetAll()
    {
     var enrollments = await enrolementService.GetAllAsync();
     return Ok(enrollments);
    }
//   get/api/enrollments/{id} return one or 404





    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var record = await enrolementService.GetByIdAsync(id);
       return record is not null ? Ok(record) : NotFound();
    }





    // post/api/enrollments create new record
    [HttpPost]
public async Task<IActionResult> Create([FromBody] CreateEnrollmentRequest request)
{
// #pragma warning disable CS8604 // Possible null reference argument.
        var record = await enrolementService.EnrollAsync(request.StudentId, request.CourseCode);
// #pragma warning restore CS8604 // Possible null reference argument.
        return CreatedAtAction(nameof(GetById), new { id = record.Id }, record);
}







// DELETE /api/enrollments/{id} returns 204 or 404
[HttpDelete("{id}")]
public async Task<IActionResult> Delete(string id)
{
        // #pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        var deleted = await enrollmentService.DeleteAsync(id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                              // #pragma warning restore CS8602 // Dereference of a possibly null reference.
        return deleted ? NoContent() : NotFound();



}






}

public class CreateEnrollmentRequest
{
    public string? CourseCode { get; internal set; }
    public string? StudentId { get; internal set; }
}