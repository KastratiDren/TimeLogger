﻿namespace TimeLogger.Application.Features.Attendances.Queries
{   
    public record GetAttendanceByDate(DateOnly date) : IRequest<List<Attendance>>;
}
