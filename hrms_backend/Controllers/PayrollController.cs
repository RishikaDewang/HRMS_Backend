using hrms_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

[ApiController]
[Route("api/payroll")]
public class PayrollController : ControllerBase
{
    private readonly HrmsDbContext _context;

    //  Single Constructor (Fix applied)
    public PayrollController(HrmsDbContext context)
    {
        _context = context;
    }

    /*   [HttpPost("calculate")]
       public IActionResult CalculatePayroll([FromBody] PayrollRequest request)
       {
           if (request == null) return BadRequest("Invalid Request");

           // Step 1: Calculate Pay Per Day
           decimal payPerDay = request.GrossSalary / 25;

           // Step 2: Calculate Leave Deduction (only unpaid leaves)
           decimal unpaidLeaves = Math.Max(request.TotalLeaves - request.PaidLeaves, 0);
           decimal leaveDeduction = unpaidLeaves * payPerDay;

           // Step 3: Apply Payroll Formula
           decimal netSalary = request.GrossSalary
                               - (leaveDeduction + request.ProfessionalTax + request.IncomeTax)
                               + (request.Bonus + request.Adjustments);

           // Step 4: Return Response
           return Ok(new { employeeId = request.EmployeeId, netSalary = netSalary });
       }

       [HttpGet("{id}")]
       public IActionResult GetEmployeeById(int id)
       {
           var employee = _context.Employees
               .Where(e => e.EmployeeId == id)
               .Select(e => new
               {
                   e.EmployeeId,
                   e.FullName,
                   e.Email,
                   e.MobileNo,
                   e.GrossSalary,
                   e.ProfessionalTax,
                   e.IncomeTax,
                   e.PaidLeaves
               })
               .FirstOrDefault();

           if (employee == null)
               return NotFound(new { message = "Employee not found" });

           return Ok(employee);
       }*/
    [HttpPost("calculatePayroll")]
    public IActionResult CalculateAndSavePayroll([FromBody] PayrollRequest request)
    {
        if (request == null) return BadRequest("Invalid Request");

        // ✅ Validate month range (1 to 12)
        if (request.Month < 1 || request.Month > 12)
        {
            return BadRequest("Invalid month. Month should be between 1 and 12.");
        }

        // ✅ Validate year (reasonable range)
        if (request.Year < 2000 || request.Year > DateTime.Now.Year)
        {
            return BadRequest("Invalid year.");
        }

        // Step 1: Pay Calculation
        decimal payPerDay = request.GrossSalary / 25;
        decimal unpaidLeaves = Math.Max(request.TotalLeaves - request.PaidLeaves, 0);
        decimal halfDayDeduction = request.HalfDayLeaves * (payPerDay / 2);
        decimal leaveDeduction = (unpaidLeaves * payPerDay) + halfDayDeduction;

        // Step 2: Final Salary Calculation
        decimal netSalary = request.GrossSalary
                            - (leaveDeduction + request.ProfessionalTax + request.IncomeTax)
                            + (request.Bonus + request.Adjustments);

        // Step 3: Check if Payroll Exists
        var existingPayroll = _context.Payrolls
            .FirstOrDefault(p => p.EmployeeId == request.EmployeeId && p.Month == request.Month && p.Year == request.Year);

        if (existingPayroll != null)
        {
            // Update existing payroll
            existingPayroll.TotalLeaves = request.TotalLeaves;
            existingPayroll.HalfDayLeaves = request.HalfDayLeaves;
            existingPayroll.PaidLeaves = request.PaidLeaves;
            existingPayroll.ProfessionalTax = request.ProfessionalTax;
            existingPayroll.IncomeTax = request.IncomeTax;
            existingPayroll.Bonus = request.Bonus;
            existingPayroll.Adjustments = request.Adjustments;
            existingPayroll.NetSalary = netSalary;

            _context.SaveChanges();
            return Ok(new { message = "Payroll updated successfully", netSalary = netSalary });
        }
        else
        {
            // Create a new payroll entry
            var newPayroll = new Payroll
            {
                EmployeeId = request.EmployeeId,
                Month = request.Month,
                Year = request.Year,
                GrossSalary = request.GrossSalary,
                TotalLeaves = request.TotalLeaves,
                HalfDayLeaves = request.HalfDayLeaves,
                PaidLeaves = request.PaidLeaves,
                ProfessionalTax = request.ProfessionalTax,
                IncomeTax = request.IncomeTax,
                Bonus = request.Bonus,
                Adjustments = request.Adjustments,
                NetSalary = netSalary
            };

            _context.Payrolls.Add(newPayroll);
            _context.SaveChanges();
            return Ok(new { message = "Payroll saved successfully", netSalary = netSalary });
        }
    }
    [HttpPost("calculatePayrollBatch")]
    public IActionResult CalculateAndSavePayrollBatch([FromBody] List<PayrollRequest> requests)
    {
        if (requests == null || !requests.Any()) return BadRequest("Invalid Request");

        var existingEmployeeIds = _context.Employees.Select(e => e.EmployeeId).ToHashSet(); // Get valid EmployeeIds

        foreach (var request in requests)
        {
            if (!existingEmployeeIds.Contains(request.EmployeeId))
            {
                return BadRequest($"EmployeeId {request.EmployeeId} does not exist in Employees table.");
            }

            decimal payPerDay = request.GrossSalary / 25;
            decimal unpaidLeaves = Math.Max(request.TotalLeaves - request.PaidLeaves, 0);
            decimal halfDayDeduction = request.HalfDayLeaves * (payPerDay / 2);
            decimal leaveDeduction = (unpaidLeaves * payPerDay) + halfDayDeduction;
            decimal netSalary = request.GrossSalary - (leaveDeduction + request.ProfessionalTax + request.IncomeTax)
                + (request.Bonus + request.Adjustments);

            var existingPayroll = _context.Payrolls
                .FirstOrDefault(p => p.EmployeeId == request.EmployeeId && p.Month == request.Month && p.Year == request.Year);

            if (existingPayroll != null)
            {
                // Update existing payroll record
                existingPayroll.TotalLeaves = request.TotalLeaves;
                existingPayroll.HalfDayLeaves = request.HalfDayLeaves;
                existingPayroll.PaidLeaves = request.PaidLeaves;
                existingPayroll.ProfessionalTax = request.ProfessionalTax;
                existingPayroll.IncomeTax = request.IncomeTax;
                existingPayroll.Bonus = request.Bonus;
                existingPayroll.Adjustments = request.Adjustments;
                existingPayroll.NetSalary = netSalary;
            }
            else
            {
                // Create a new payroll entry only if the EmployeeId exists
                var newPayroll = new Payroll
                {
                    EmployeeId = request.EmployeeId,
                    Month = request.Month,
                    Year = request.Year,
                    GrossSalary = request.GrossSalary,
                    TotalLeaves = request.TotalLeaves,
                    HalfDayLeaves = request.HalfDayLeaves,
                    PaidLeaves = request.PaidLeaves,
                    ProfessionalTax = request.ProfessionalTax,
                    IncomeTax = request.IncomeTax,
                    Bonus = request.Bonus,
                    Adjustments = request.Adjustments,
                    NetSalary = netSalary

                };

                _context.Payrolls.Add(newPayroll);
            }
        }

        _context.SaveChanges();
        return Ok(new { message = "Payroll saved successfully" });
    }




    /*[HttpGet]
    public IActionResult GetAllEmployees()
    {
        var employees = _context.Employees
            .Select(e => new
            {
                e.EmployeeId,
                e.FullName,
                e.Email,
                e.MobileNo,
                e.GrossSalary,
                e.ProfessionalTax,
                e.IncomeTax,
                e.PaidLeaves
            })
            .ToList();

        if (employees.Count == 0)
            return NotFound(new { message = "No employees found" });

        return Ok(employees);
    }*/
    [HttpGet("getPayroll")]
    public IActionResult GetPayrollData(int month, int year)
    {
        var payrolls = _context.Payrolls
            .Where(p => p.Month == month && p.Year == year)
            .ToList();

        var employees = _context.Employees.ToList();

        if (!employees.Any())
        {
            return NotFound("No employees found.");
        }

        var response = employees.Select(employee =>
        {
            var payroll = payrolls.FirstOrDefault(p => p.EmployeeId == employee.EmployeeId);
            bool isEditable = payroll == null; // If payroll exists, make it non-editable

            return new
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.FullName,
                Month = month,
                Year = year,
                GrossSalary = employee.GrossSalary,
                PaidLeaves = employee.PaidLeaves,
                TotalLeaves = payroll?.TotalLeaves ?? 0,
                HalfDayLeaves = payroll?.HalfDayLeaves ?? 0,
                ProfessionalTax = payroll?.ProfessionalTax ?? 0,
                IncomeTax = payroll?.IncomeTax ?? 0,
                Bonus = payroll?.Bonus ?? 0,
                Adjustments = payroll?.Adjustments ?? 0,
                NetSalary = payroll?.NetSalary ?? 0, // Include net salary if it exists
                IsEditable = isEditable // New flag to control UI editability
            };
        }).ToList();

        return Ok(response);
    }
    /*  [HttpGet("generateSalarySlip/{employeeId}")]
      public IActionResult GenerateSalarySlip(int employeeId)
      {
          var payroll = _context.Payrolls.FirstOrDefault(p => p.EmployeeId == employeeId);

          if (payroll == null)
          {
              return NotFound(new { message = "Payroll data not found." });
          }

          try
          {
              byte[] pdfBytes = GeneratePdf(payroll);

              if (pdfBytes == null || pdfBytes.Length == 0)
              {
                  return BadRequest(new { message = "Failed to generate PDF." });
              }

              return File(pdfBytes, "application/pdf", $"SalarySlip_{employeeId}.pdf");
          }
          catch (Exception ex)
          {
              return StatusCode(500, new { message = "Error generating PDF", error = ex.Message });
          }
      }

      private byte[] GeneratePdf(Payroll payroll)
      {
          using (var stream = new MemoryStream())
          {
              var writer = new PdfWriter(stream);
              var pdf = new PdfDocument(writer);
              var document = new Document(pdf);

              document.Add(new Paragraph("Salary Slip").SetBold().SetFontSize(18));
              document.Add(new Paragraph($"Employee ID: {payroll.EmployeeId}"));
              document.Add(new Paragraph($"Employee Name: {payroll.EmployeeName}"));
              document.Add(new Paragraph($"Gross Salary: ₹{payroll.GrossSalary}"));
              document.Add(new Paragraph($"Net Salary: ₹{payroll.NetSalary}"));

              document.Close();
              return stream.ToArray();
          }*/



    // Model to Accept Data from Frontend
    public class PayrollRequest
    {
        public int EmployeeId { get; set; }
        public decimal GrossSalary { get; set; }
        public int TotalDays { get; set; }
        public int TotalLeaves { get; set; }
        public int PaidLeaves { get; set; }
        public int HalfDayLeaves { get; set; }  // ✅ Changed from object to int
        public decimal ProfessionalTax { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal Bonus { get; set; }
        public decimal Adjustments { get; set; }
        public int Month { get; set; }  // ✅ Added missing Month property
        public int Year { get; set; }   // ✅ Added missing Year property

    }

}
