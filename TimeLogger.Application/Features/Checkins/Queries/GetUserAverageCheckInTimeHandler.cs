﻿using MediatR;
using TimeLogger.Application.IRepositories;

namespace TimeLogger.Application.Features.Checkins.Queries
{
    public class GetUserAverageCheckInTimeHandler : IRequestHandler<GetUserAverageCheckInTime, TimeSpan?>
    {
        private readonly ICheckInRepository _repository;

        public GetUserAverageCheckInTimeHandler(ICheckInRepository repository)
        {
            _repository = repository;
        }

        public async Task<TimeSpan?> Handle(GetUserAverageCheckInTime request, CancellationToken cancellationToken)
        {
            // Retrieve the average check-in time using the repository
            var checkIns = await _repository.GetByUserIdAsync(request.userId);

            if (checkIns == null || !checkIns.Any())
                return null;

            var averageCheckInTime = new TimeSpan((long)checkIns.Average(c => c.CheckInTime.Ticks));

            // Return the result
            return averageCheckInTime;
        }
    }
}
