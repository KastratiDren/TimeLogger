using MediatR;
using TimeLogger.Application.IRepositories;

namespace TimeLogger.Application.Features.Checkouts.Queries
{
    public class GetUserAverageCheckOutTimeHandler : IRequestHandler<GetUserAverageCheckOutTime, TimeSpan?>
    {
        private readonly ICheckOutRepository _repository;

        public GetUserAverageCheckOutTimeHandler(ICheckOutRepository repository)
        {
            _repository = repository;
        }

        public async Task<TimeSpan?> Handle(GetUserAverageCheckOutTime request, CancellationToken cancellationToken)
        {
            // Retrieve the average check-in time using the repository
            var checkOuts = await _repository.GetByUserIdAsync(request.userId);

            if (checkOuts == null || !checkOuts.Any())
                return null;

            var averageCheckOutTime = new TimeSpan((long)checkOuts.Average(c => c.CheckOutTime.Ticks));

            // Return the result
            return averageCheckOutTime;
        }
    }
}
