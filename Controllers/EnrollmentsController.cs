using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class EnrollmentsController(IEnrollmentService enrolementService
 ) : ControllerBase
{
    private IEnrollmentService enrollmentService;

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
var record = await enrolementService.EnrollAsync(request.StudentId, request.CourseCode);
return CreatedAtAction(nameof(GetById), new { id = record.Id }, record);
}



// DELETE /api/enrollments/{id} returns 204 or 404
[HttpDelete("{id}")]
public async Task<IActionResult> Delete(string id)
{
var deleted = await enrollmentService.DeleteAsync(id);
return deleted ? NoContent() : NotFound();



}






}

public class CreateEnrollmentRequest
{
    public string CourseCode { get; internal set; }
    public string StudentId { get; internal set; }
}