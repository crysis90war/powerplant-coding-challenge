using CodingChallenge.Models;

namespace CodingChallenge.Services
{
    public interface IPowerplantService
    {
        /// <summary>
        /// Calculates and generates a list of result from a payload.
        /// </summary>
        /// <param name="payload">Takes in the payload</param>
        /// <returns>Returns a list of <see cref="Result"/>.</returns>
        public IEnumerable<Result> CalculateResult(Payload paylaod);
    }
}
