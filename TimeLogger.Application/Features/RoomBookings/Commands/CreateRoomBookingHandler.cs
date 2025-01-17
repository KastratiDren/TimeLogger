﻿using AutoMapper;
using MediatR;
using TimeLogger.Application.Features.RoomBookings.Commands;
using TimeLogger.Application.Features.RoomBookings.Dtos;
using TimeLogger.Application.IRepositories;
using TimeLogger.Domain.Entites;

namespace TimeLogger.Application.Features.RoomBookings.Handlers
{
    public class CreateRoomBookingHandler : IRequestHandler<CreateRoomBooking, bool>
    {
        private readonly IRoomBookingRepository _roomBookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public CreateRoomBookingHandler(IRoomBookingRepository roomBookingRepository, IRoomRepository roomRepository, IMapper mapper)
        {
            _roomBookingRepository = roomBookingRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateRoomBooking request, CancellationToken cancellationToken)
        {
            var dto = request.RoomBookingsDto;

            // Validate Room Existence
            var roomExists = await _roomRepository.IsValidRoomAsync(dto.RoomId);
            if (!roomExists)
                throw new ArgumentException($"Room with ID {dto.RoomId} does not exist.");

            // Validate Overlapping Bookings
            var existingBookings = await _roomBookingRepository.GetByRoomIdAsync(dto.RoomId);
            var hasConflict = existingBookings.Any(b =>
                (dto.StartTime >= b.StartTime && dto.StartTime < b.EndTime) ||
                (dto.EndTime > b.StartTime && dto.EndTime <= b.EndTime) ||
                (dto.StartTime <= b.StartTime && dto.EndTime >= b.EndTime)
            );

            if (hasConflict)
                throw new InvalidOperationException("The room is already booked for the specified timeframe.");

            // Create the RoomBooking
            var roomBooking = _mapper.Map<RoomBooking>(dto);

            await _roomBookingRepository.AddAsync(roomBooking);
            return true;
        }
    }
}
