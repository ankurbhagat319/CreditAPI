using CreditApplication.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CreditApplication.Controllers
{
    [ApiController]
    [Route("/creditRequest")]
    public class CreditRequestController : ControllerBase
    {
        [HttpGet("creditCheck")]
        public ActionResult<CreditRequestDto> GetCreditInfo(int creditAmountRequested, int termsInMonths, int preExistingCreditAmount)
        {
            // Invalid Parameter
            if (creditAmountRequested <= 0 || termsInMonths <= 0)
                return BadRequest();

            // When Customer is not eligible
            if (creditAmountRequested < 2000 || creditAmountRequested > 69000)
                return new CreditRequestDto { AreYouEligible = false };

            // When Customer is eligible
            int interestRate = (creditAmountRequested + preExistingCreditAmount)
            switch
            {
                (>= 20000) and (<= 39000) => 4,
                (>= 40000) and (<= 59000) => 5,
                (> 60000) => 6,
                _ => 3
            };
            return new CreditRequestDto { AreYouEligible = true, InterestRate = interestRate };
        }

    }
}
