using hrms_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
    /*[HttpPost("calculatePayroll")]
    public IActionResult CalculateAndSavePayroll([FromBody] PayrollRequest request)
    {
        if (request == null) return BadRequest("Invalid Request");
        // :white_check_mark: Validate month range (1 to 12)
        if (request.Month < 1 || request.Month > 12)
        {
            return BadRequest("Invalid month. Month should be between 1 and 12.");
        }
        // :white_check_mark: Validate year (reasonable range)
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
    }*/

    [HttpPost("calculatePayroll")]
    public IActionResult CalculateAndSavePayroll([FromBody] PayrollRequest request)
    {
        if (request == null) return BadRequest("Invalid Request");

        // Validate month range (1 to 12)
        if (request.Month < 1 || request.Month > 12)
        {
            return BadRequest("Invalid month. Month should be between 1 and 12.");
        }

        // Validate year (reasonable range)
        if (request.Year < 2000 || request.Year > DateTime.Now.Year)
        {
            return BadRequest("Invalid year.");
        }

        // Step 1: Pay Calculation
        decimal payPerDay = request.GrossSalary / 25;

        // Step 2: Convert Half Days into Full Leaves
        int fullLeavesFromHalfDays = request.HalfDayLeaves / 2;
        int remainingHalfDays = request.HalfDayLeaves % 2; // If 1 half-day remains, it will be counted separately
        
        // Step 3: Total Leaves After Conversion
        int totalEffectiveLeaves = request.TotalLeaves + fullLeavesFromHalfDays;


        // Step 4: Deduct Paid Leaves
        int unpaidLeaves = Math.Max(totalEffectiveLeaves - request.PaidLeaves, 0); // Leaves that are unpaid
                                                                                   // 🔹 Fix: Check if remaining half-day can be covered by paid leave
        if (remainingHalfDays == 1 && request.PaidLeaves > totalEffectiveLeaves)
        {
            remainingHalfDays = 0; // Cover the half-day using paid leave
        }

        // Step 5: Calculate Salary Deduction
        decimal leaveDeduction = unpaidLeaves * payPerDay;  // Deduction for full unpaid leaves
        decimal halfDayDeduction = remainingHalfDays * (payPerDay / 2); // Deduction for any remaining half-day

        // Step 6: Final Salary Calculation
        decimal netSalary = request.GrossSalary
                            - (leaveDeduction + halfDayDeduction + request.ProfessionalTax + request.IncomeTax)
                            + (request.Bonus + request.Adjustments);

        // Step 7: Check if Payroll Exists
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
}
// Model to Accept Data from Frontend
public class PayrollRequest
{
    public int EmployeeId { get; set; }
    public decimal GrossSalary { get; set; }
    public int TotalDays { get; set; }
    public int TotalLeaves { get; set; }
    public int PaidLeaves { get; set; }
    public int HalfDayLeaves { get; set; }  // :white_check_mark: Changed from object to int
    public decimal ProfessionalTax { get; set; }
    public decimal IncomeTax { get; set; }
    public decimal Bonus { get; set; }
    public decimal Adjustments { get; set; }
    public int Month { get; set; }  // :white_check_mark: Added missing Month property
    public int Year { get; set; }   // :white_check_mark: Added missing Year property
}